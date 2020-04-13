using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using KSerialization;
using STRINGS;
//using UnityEngine;
using UnityEngine;

namespace SharlesPlants
{
    public class BasePlant : StateMachineComponent<StatesInstance>
    {
        protected void DestroySelf(object callbackParam)
        {
            CreatureHelpers.DeselectCreature(gameObject);
            Util.KDestroyGameObject(gameObject);
        }
        
        public Notification CreateDeathNotification()
        {
            return new Notification(CREATURES.STATUSITEMS.PLANTDEATH.NOTIFICATION, NotificationType.Bad, HashedString.Invalid, (notificationList, data) => CREATURES.STATUSITEMS.PLANTDEATH.NOTIFICATION_TOOLTIP + notificationList.ReduceMessages(false), "/t• " + gameObject.GetProperName());
        }
        
    }

    public class StatesInstance : GameStateMachine<States, StatesInstance, BasePlant, object>.GameInstance
    {
        public StatesInstance(BasePlant master) : base(master) {}
    }

    public class States : GameStateMachine<States, StatesInstance, BasePlant>
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

        }

        public class AliveStates : PlantAliveSubState
        {
            public State MyAlive;
        }
    }
}
