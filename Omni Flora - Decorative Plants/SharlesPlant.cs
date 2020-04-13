using System.Collections.Generic;
using UnityEngine;
using STRINGS;
using static SharlesPlants.SharlesPlantsTuning;

namespace SharlesPlants
{
    class SharlesPlant : StateMachineComponent<SharlesPlant.StatesInstance>, IGameObjectEffectDescriptor
    {
        public enum Condition
        {
            Juvenile,
            Mature,
            Flourishing
        }

        [MyCmpGet]
        private Light2D lightSource;

        [MyCmpReq]
        private ReceptacleMonitor rm;

        [MyCmpReq]
        private WiltCondition wiltCondition;

        public EffectorValues wiltDecor = WiltDecor,
            juvenileDecor,
            matureDecor,
            flourishingDecor;

        protected override void OnSpawn()
        {
            base.OnSpawn();

            if (lightSource != null)
                lightSource.enabled = false;

            smi.StartSM();
        }

        protected void DestroySelf(object callbackParam)
        {
            CreatureHelpers.DeselectCreature(gameObject);
            Util.KDestroyGameObject(gameObject);
        }

        public Notification CreateDeathNotification()
        {
            return new Notification(CREATURES.STATUSITEMS.PLANTDEATH.NOTIFICATION, NotificationType.Bad, HashedString.Invalid, 
                (notificationList, data) => CREATURES.STATUSITEMS.PLANTDEATH.NOTIFICATION_TOOLTIP + notificationList.ReduceMessages(false), "/t• " + gameObject.GetProperName());
        }

        public virtual Condition GetCondition() 
        {
            return Condition.Juvenile;
        }

        public virtual List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> descriptors = new List<Descriptor>();
            return descriptors;
        }

        public class StatesInstance : GameStateMachine<States, StatesInstance, SharlesPlant, object>.GameInstance
        {
            public StatesInstance(SharlesPlant master) : base(master) { }
        }

        public class States : GameStateMachine<States, StatesInstance, SharlesPlant>
        {
            public AliveStates Alive;
            public State Dead;

            public override void InitializeStates(out BaseState defaultState)
            {
                serializable = true;
                defaultState = Alive;

                var plantname = CREATURES.STATUSITEMS.DEAD.NAME;
                var tooltip = CREATURES.STATUSITEMS.DEAD.TOOLTIP;
                var main = Db.Get().StatusItemCategories.Main;

                Dead
                    .ToggleStatusItem(plantname, tooltip, string.Empty, StatusItem.IconType.Info, 0, false, OverlayModes.None.ID, category: main)
                    .Enter(smi =>
                    {
                        if (smi.master.rm.Replanted && !smi.master.GetComponent<KPrefabID>().HasTag(GameTags.Uprooted))
                            smi.master.gameObject.AddOrGet<Notifier>().Add(smi.master.CreateDeathNotification());

                        GameUtil.KInstantiate(Assets.GetPrefab(EffectConfigs.PlantDeathId), smi.master.transform.GetPosition(), Grid.SceneLayer.FXFront).SetActive(true);

                        smi.master.Trigger((int)GameHashes.Died);
                        smi.master.GetComponent<KBatchedAnimController>().StopAndClear();
                        Destroy(smi.master.GetComponent<KBatchedAnimController>());
                        smi.Schedule(0.5f, smi.master.DestroySelf);
                    });

                Alive
                    .InitializeStates(masterTarget, Dead)
                    .DefaultState(Alive.Juvenile)
                    .EventTransition(GameHashes.Wilt, Alive.Wilt, smi => smi.master.wiltCondition.IsWilting())
                    .Transition(Alive.Juvenile, smi => !smi.master.wiltCondition.IsWilting() && smi.master.GetCondition() == Condition.Juvenile, UpdateRate.SIM_1000ms)
                    .Transition(Alive.Mature, smi => !smi.master.wiltCondition.IsWilting() && smi.master.GetCondition() == Condition.Mature, UpdateRate.SIM_1000ms)
                    .Transition(Alive.Flourishing, smi => !smi.master.wiltCondition.IsWilting() && smi.master.GetCondition() == Condition.Flourishing, UpdateRate.SIM_1000ms);

                Alive.Wilt
                    .PlayAnim("wilt")
                    .Enter(smi => updateDecor(smi.master, smi.master.wiltDecor));

                Alive.Juvenile
                    .PlayAnim("juvenile")
                    .Enter(smi => updateDecor(smi.master, smi.master.juvenileDecor));

                Alive.Mature
                    .PlayAnim("mature")
                    .Enter(smi => updateDecor(smi.master, smi.master.matureDecor));

                Alive.Flourishing
                    .PlayAnim("flourishing")
                    .Enter(smi =>
                    {
                        updateDecor(smi.master, smi.master.flourishingDecor);
                        if (smi.master.lightSource != null)
                            smi.master.lightSource.enabled = true;
                    })
                    .Exit(smi =>
                    {
                        if (smi.master.lightSource != null)
                            smi.master.lightSource.enabled = false;
                    });
            }

            public class AliveStates : PlantAliveSubState
            {
                public State Wilt,
                    Juvenile,
                    Mature,
                    Flourishing;
            }

            public void updateDecor(SharlesPlant plant, EffectorValues decorEffect)
            {
                plant.GetComponent<DecorProvider>().SetValues(decorEffect);
                plant.GetComponent<DecorProvider>().Refresh();
                if(decorEffect.amount > 0)
                    plant.AddTag(GameTags.Decoration);
                else
                    plant.RemoveTag(GameTags.Decoration);
            }
        }
    }
}