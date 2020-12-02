using System;
using TUNING;
using UnityEngine;
using KSerialization;
using static RainbowFarts.RainbowFartsTuning;

namespace RainbowFarts
{
    // Mostly adapted from the Flatulence class
    [SerializationConfig(MemberSerialization.OptIn)]
    public class RainbowFlatulence : StateMachineComponent<RainbowFlatulence.StatesInstance>
    {
        private static readonly HashedString[] WorkLoopAnims = new HashedString[3]
        {
            "working_pre",
            "working_loop",
            "working_pst"
        };
        [SerializeField]
        public SimHashes EmitElement = (SimHashes) RAINBOW;
        private float EmitMass = 0.1f;
        private float EmissionRadius = 1.5f;
        private float MaxDistanceSq = 2.25f;

        protected override void OnSpawn()
        {
            this.smi.StartSM();
        }

        private void Emit(object data)
        {
            SimHashes elementToEmit = EmitElement == (SimHashes) RAINBOW ? GetRandomFlatulence().element : EmitElement; ;
            GameObject gameObject = (GameObject) data;
            float temperature = Db.Get().Amounts.Temperature.Lookup(this).value;
            Equippable equippable = this.GetComponent<SuitEquipper>().IsWearingAirtightSuit();
            if (equippable != null)
            {
                equippable.GetComponent<Storage>().AddGasChunk(elementToEmit, EmitMass, temperature, byte.MaxValue, 0, false, true);
            }
            else
            {
                Components.Cmps<MinionIdentity> minionIdentities = Components.LiveMinionIdentities;
                Vector2 position1 = gameObject.transform.GetPosition();
                for (int index = 0; index < minionIdentities.Count; ++index)
                {
                    MinionIdentity minionIdentity = minionIdentities[index];
                    if (minionIdentity.gameObject != gameObject.gameObject)
                    {
                        Vector2 position2 = minionIdentity.transform.GetPosition();
                        if (Vector2.SqrMagnitude(position1 - position2) <= MaxDistanceSq)
                        {
                            minionIdentity.Trigger((int) GameHashes.Cringe, Strings.Get("STRINGS.DUPLICANTS.DISEASES.PUTRIDODOUR.CRINGE_EFFECT").String);
                            minionIdentity.gameObject.GetSMI<ThoughtGraph.Instance>().AddThought(Db.Get().Thoughts.PutridOdour);
                        }
                    }
                }
                SimMessages.AddRemoveSubstance(Grid.PosToCell(gameObject.transform.GetPosition()), elementToEmit, CellEventLogger.Instance.ElementConsumerSimUpdate, EmitMass, temperature, byte.MaxValue, 0, true, -1);
                KBatchedAnimController effect = FXHelpers.CreateEffect("odor_fx_kanim", gameObject.transform.GetPosition(), gameObject.transform, true, Grid.SceneLayer.Front, false);
                effect.Play(WorkLoopAnims, KAnim.PlayMode.Once);
                effect.destroyOnAnimComplete = true;
            }
            GameObject go = gameObject;
            bool objectIsSelectedAndVisible = SoundEvent.ObjectIsSelectedAndVisible(go);
            Vector3 vector3 = go.GetComponent<Transform>().GetPosition();
            vector3.z = 0.0f;
            float volume = 1f;
            if (objectIsSelectedAndVisible)
            {
                vector3 = SoundEvent.AudioHighlightListenerPosition(vector3);
                volume = SoundEvent.GetVolume(objectIsSelectedAndVisible);
            }
            else
                vector3.z = 0.0f;
            KFMOD.PlayOneShot(GlobalAssets.GetSound("Dupe_Flatulence", false), vector3, volume);
        }

        public class StatesInstance : GameStateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.GameInstance
        {
            public StatesInstance(RainbowFlatulence master) : base(master)
            {
            }
        }

        public class States : GameStateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence>
        {
            public GameStateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.State idle;
            public GameStateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.State emit;

            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                default_state = (StateMachine.BaseState) this.idle;
                this.root.TagTransition(GameTags.Dead, (GameStateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.State) null, false);
                this.idle.Enter("ScheduleNextFart", (StateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.State.Callback) (smi => smi.ScheduleGoTo(this.GetNewInterval(), (StateMachine.BaseState) this.emit)));
                this.emit.Enter("Fart", (StateMachine<RainbowFlatulence.States, RainbowFlatulence.StatesInstance, RainbowFlatulence, object>.State.Callback) (smi => smi.master.Emit((object) smi.master.gameObject))).ToggleExpression(Db.Get().Expressions.Relief, (Func<RainbowFlatulence.StatesInstance, bool>) null).ScheduleGoTo(3f, (StateMachine.BaseState) this.idle);
            }

            private float GetNewInterval()
            {
                return Mathf.Min(Mathf.Max(Util.GaussianRandom(TRAITS.FLATULENCE_EMIT_INTERVAL_MAX - TRAITS.FLATULENCE_EMIT_INTERVAL_MIN, 1f), TRAITS.FLATULENCE_EMIT_INTERVAL_MIN), TRAITS.FLATULENCE_EMIT_INTERVAL_MAX);
            }
        }
    }
}
