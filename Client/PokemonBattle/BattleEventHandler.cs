using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.Screens;
using Client.Services.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using GameLogic.Battles;

namespace Client.PokemonBattle
{
    internal class BattleEventsHandler
    {
        private readonly ScreenBattle screen;
        private int OpenWindows = 0;

        public BattleEventsHandler(ScreenBattle screen, IScreenLoader screenLoader)
        {
            this.screen = screen;
        }
        public void AttachMyBattlePokemonEventHandlers(BattlePokemon myPoke)
        {
            //pokemon events
            myPoke.Burned += MyBurnedEventHandler;
            myPoke.Frozen += MyFrozenEventHandler;
            myPoke.Paralyzed += MyParalyzedEventHandler;
            myPoke.Poisoned += MyPoisonedEventHandler;
            myPoke.BadlyPoisoned += MyBadlyPoisonedEventHandler;
            myPoke.FellAsleep += MyFellAsleepEventHandler;
            myPoke.StatusCleared += MyStatusClearedEventHandler;
            myPoke.Fainted += MyFaintedEventHandler;

            //move events
            myPoke.MoveUsed += MyMoveUsedEventHandler;
            myPoke.MoveFailed += MoveFailedEventHandler;
            myPoke.MoveMissed += MoveMissedEventHandler;
            myPoke.MoveHadNoEffect += MoveHadNoEffectEventHandler;
            myPoke.MoveSuperEffective += MoveSuperEffectiveEventHandler;
            myPoke.MoveNotVeryEffective += MoveNotVeryEffectiveEventHandler;
            myPoke.MoveCriticalHit += MoveCriticalHitEventHandler;
            myPoke.MoveOneHitKO += MoveOneHitKOEventHandler;
            myPoke.PayDayTriggered += PayDayTriggeredEventHandler;
            myPoke.SolarBeamFirstTurn += MySolarBeamFirstTurnEventHandler;
            myPoke.RazorWindFirstTurn += MyRazorWindFirstTurnEventHandler;
            myPoke.BidingTime += MyBidingTimeEventHandler;
            myPoke.BideUnleased += MyBideUnleashedEventHandler;
            myPoke.FlyFirstTurn += MyFlyFirstTurnEventHandler;
            myPoke.AttackContinues += MyAttackContinuesEventHandler;
            myPoke.CrashDamage += MyCrashDamageEventHandler;
            myPoke.HurtByRecoilDamage += MyHurtByRecoilDamageEventHandler;
            myPoke.ThrashingAbout += MyThrashingAboutEventHandler;
            myPoke.HyperBeamRecharging += MyHyperBeamRechargingEventHandler;
            myPoke.SuckedHealth += MySuckedHealthEventHandler;
            myPoke.DugAHole += MyDugAHoleEventHandler;
            myPoke.SkullBashFirstTurn += MySkullBashFirstTurnEventHandler;
            myPoke.SkyAttackFirstTurn += MySkyAttackFirstTurnEventHandler;
            myPoke.RegainedHealth += MyRegainedHealthEventHandler;

            //battlePokemon events
            myPoke.SwitchedOut += MySwitchedOutEventHandler;
            myPoke.StatStageChanged += MyStatStageChangedEventHandler;
            myPoke.SubstituteActivated += MySubstituteActivatedEventHandler;
            myPoke.ConversionActivated += MyConversionActivatedEventHandler;
            myPoke.TransformActivated += MyTransformActivatedEventHandler;
            myPoke.LeechSeedActivated += MyLeechSeedActivatedEventHandler;
            myPoke.LeechSeedSaps += MyLeechSeedSapsEventHandler;
            myPoke.HurtFromConfusion += HurtFromConfusionEventHandler;
            myPoke.Flinched += MyFlinchedEventHandler;
            myPoke.FullyParalyzed += MyFullyParalyzedEventHandler;
            myPoke.FrozenSolid += MyFrozenSolidEventHandler;
            myPoke.FastAsleep += MyFastAsleepEventHandler;
            myPoke.WokeUp += MyWokeUpEventHandler;
            myPoke.Disabled += MyDisabledEventHandler;
            myPoke.MoveAttemptedButIsDisabled += MyMoveAttemptedButIsDisabledEventHandler;
            myPoke.Mimic += MyMimicEventHandler;
        }
        public void AttachOpponentBattlePokemonEventHandlers(BattlePokemon enemyPoke)
        {
            //pokemon events
            enemyPoke.SwitchedOut += EnemySwitchedOutEventHandler;
            enemyPoke.Burned += EnemyBurnedEventHandler;
            enemyPoke.Frozen += EnemyFrozenEventHandler;
            enemyPoke.Paralyzed += EnemyParalyzedEventHandler;
            enemyPoke.Poisoned += EnemyPoisonedEventHandler;
            enemyPoke.BadlyPoisoned += EnemyBadlyPoisonedEventHandler;
            enemyPoke.FellAsleep += EnemyFellAsleepEventHandler;
            enemyPoke.StatusCleared += EnemyStatusClearedEventHandler;
            enemyPoke.Fainted += EnemyFaintedEventHandler;

            //move events
            enemyPoke.MoveUsed += EnemyMoveUsedEventHandler;
            enemyPoke.MoveFailed += MoveFailedEventHandler;
            enemyPoke.MoveMissed += MoveMissedEventHandler;
            enemyPoke.MoveHadNoEffect += MoveHadNoEffectEventHandler;
            enemyPoke.MoveSuperEffective += MoveSuperEffectiveEventHandler;
            enemyPoke.MoveNotVeryEffective += MoveNotVeryEffectiveEventHandler;
            enemyPoke.MoveCriticalHit += MoveCriticalHitEventHandler;
            enemyPoke.MoveOneHitKO += MoveOneHitKOEventHandler;
            enemyPoke.PayDayTriggered += PayDayTriggeredEventHandler;
            enemyPoke.SolarBeamFirstTurn += EnemySolarBeamFirstTurnEventHandler;
            enemyPoke.RazorWindFirstTurn += EnemyRazorWindFirstTurnEventHandler;
            enemyPoke.BidingTime += EnemyBidingTimeEventHandler;
            enemyPoke.BideUnleased += EnemyBideUnleashedEventHandler;
            enemyPoke.FlyFirstTurn += EnemyFlyFirstTurnEventHandler;
            enemyPoke.AttackContinues += EnemyAttackContinuesEventHandler;
            enemyPoke.CrashDamage += EnemyCrashDamageEventHandler;
            enemyPoke.HurtByRecoilDamage += EnemyHurtByRecoilDamageEventHandler;
            enemyPoke.ThrashingAbout += EnemyThrashingAboutEventHandler;
            enemyPoke.HyperBeamRecharging += EnemyHyperBeamRechargingEventHandler;
            enemyPoke.SuckedHealth += EnemySuckedHealthEventHandler;
            enemyPoke.DugAHole += EnemyDugAHoleEventHandler;
            enemyPoke.SkullBashFirstTurn += EnemySkullBashFirstTurnEventHandler;
            enemyPoke.SkyAttackFirstTurn += EnemySkyAttackFirstTurnEventHandler;
            enemyPoke.RegainedHealth += EnemyRegainedHealthEventHandler;

            //battlePokemon events
            enemyPoke.StatStageChanged += EnemyStatStageChangedEventHandler;
            enemyPoke.SubstituteActivated += EnemySubstituteActivatedEventHandler;
            enemyPoke.ConversionActivated += EnemyConversionActivatedEventHandler;
            enemyPoke.TransformActivated += EnemyTransformActivatedEventHandler;
            enemyPoke.LeechSeedActivated += EnemyLeechSeedActivatedEventHandler;
            enemyPoke.LeechSeedSaps += EnemyLeechSeedSapsEventHandler;
            enemyPoke.HurtFromConfusion += HurtFromConfusionEventHandler;
            enemyPoke.Flinched += EnemyFlinchedEventHandler;
            enemyPoke.FullyParalyzed += EnemyFullyParalyzedEventHandler;
            enemyPoke.FrozenSolid += EnemyFrozenSolidEventHandler;
            enemyPoke.FastAsleep += EnemyFastAsleepEventHandler;
            enemyPoke.WokeUp += EnemyWokeUpEventHandler;
            enemyPoke.Disabled += EnemyDisabledEventHandler;
            enemyPoke.MoveAttemptedButIsDisabled += EnemyMoveAttemptedButIsDisabledEventHandler;
            enemyPoke.Mimic += EnemyMimicEventHandler;
        }
        public void AttachBattleEventHandlers(Battle battle)
        {
            battle.BattleBegun += BattleBegunEventHandler;
            battle.MakingSelections += MakingSelectionsEventHandler;
            battle.FirstExecutionBegun += FirstExecutionBegunHandler;
            battle.FirstExecutionOver += FirstExecutionOverHandler;
            battle.SecondExecutionBegun += SecondExecutionBegunHandler;
            battle.SecondExecutionOver += SecondExecutionOverHandler;
        }

        //===================================================================================//
        //                          BATTLE EVENT HANDLERS                                    //
        //===================================================================================//
        private void BattleBegunEventHandler(object sender, BattleEventArgs args)
        {
        }
        private void MakingSelectionsEventHandler(object sender, BattleEventArgs args)
        {
        }
        private void FirstExecutionBegunHandler(object sender, BattleEventArgs args)
        {
        }
        private void FirstExecutionOverHandler(object sender, BattleEventArgs args)
        {
        }
        private void SecondExecutionBegunHandler(object sender, BattleEventArgs args)
        {
        }
        private void SecondExecutionOverHandler(object sender, BattleEventArgs args)
        { 
        }


        //===================================================================================//
        //                         POKEMON EVENT HANDLERS                                    //
        //===================================================================================//
        private void MyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was burned!");
        }
        private void QueueMessage(string message)
        {
            OpenWindows++;
            var window = new WindowBattleMessage(message, screen.Input, ScreenBattle.Window);
            window.OnClose += Window_OnClose;
            screen.WindowQueuer.QueueWindow(window);
        }

        private void Window_OnClose(object sender, EventArgs e)
        {
            OpenWindows--;
            if (OpenWindows == 0)
            {
                Battle.busy = false;
            }
        }

        private void EnemyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was burned!");
        }
        private void MyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was frozen!");
        }
        private void EnemyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was frozen!");
        }
        private void MyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was paralyzed!");
        }
        private void EnemyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was paralyzed!");
        }
        private void MyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was poisoned!");
        }
        private void EnemyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was poisoned!");
        }
        private void MyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was badly poisoned!");
        }
        private void EnemyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was badly poisoned!");
        }
        private void MyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " fell asleep!");
        }
        private void EnemyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " fell asleep!");
        }
        private void MyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + "'s status was cleared!");
        }
        private void EnemyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + "'s status was cleared!");
        }
        private void MyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " fainted!");
        }
        private void EnemyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " fainted!");
        }



        //===================================================================================//
        //                           MOVE EVENT HANDLERS                                     //
        //===================================================================================//
        private void MyMoveUsedEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " used " + args.move.Name + "!");
        }
        private void EnemyMoveUsedEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " used " + args.move.Name + "!");
        }
        private void MoveFailedEventHandler(MoveEventArgs args)
        {
            QueueMessage("... but it failed!");
        }
        private void MoveMissedEventHandler(MoveEventArgs args)
        {
            QueueMessage("but it missed!");
        }
        private void MoveHadNoEffectEventHandler(MoveEventArgs args)
        {
            QueueMessage("but it had no effect!");
        }
        private void MoveSuperEffectiveEventHandler(MoveEventArgs args)
        {
            QueueMessage("It's super effective!");
        }
        private void MoveNotVeryEffectiveEventHandler(MoveEventArgs args)
        {
            QueueMessage("It's not very effective!");
        }
        private void MoveCriticalHitEventHandler(MoveEventArgs args)
        {
            QueueMessage("Critical hit!");
        }
        private void MoveOneHitKOEventHandler(MoveEventArgs args)
        {
            QueueMessage("One-hit KO!");
        }
        private void PayDayTriggeredEventHandler(MoveEventArgs args)
        {
            QueueMessage("Coins scattered everywhere!");
        }
        private void MySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " took in sunlight!");
        }
        private void EnemySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " took in sunlight!");
        }
        private void MyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " made a whirlwind!");
        }
        private void EnemyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " made a whirlwind!");
        }
        private void MyBidingTimeEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " is biding its time!");
        }
        private void EnemyBidingTimeEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " is biding its time!");
        }
        private void MyBideUnleashedEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " unleased bide!");
        }
        private void EnemyBideUnleashedEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " unleased bide!");
        }
        private void MyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " flew up high!");
        }
        private void EnemyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " flew up high!");
        }
        private void MyAttackContinuesEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + "'s attack continues!");
        }
        private void EnemyAttackContinuesEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + "'s attack continues!");
        }
        private void MyCrashDamageEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was hurt by crash damage!");
        }
        private void EnemyCrashDamageEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was hurt by crash damage!");
        }
        private void MyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was hurt by recoil damage!");
        }
        private void EnemyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was hurt by recoil damage!");
        }
        private void MyThrashingAboutEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " is thrashing about!");
        }
        private void EnemyThrashingAboutEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " is thrashing about!");
        }
        private void MyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " is recharging!");
        }
        private void EnemyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " is recharging!");
        }
        private void MySuckedHealthEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " sucked health!");
        }
        private void EnemySuckedHealthEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " sucked health!");
        }
        private void MyDugAHoleEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " dug a hole!");
        }
        private void EnemyDugAHoleEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " dug a hole!");
        }
        private void MySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " withdrew its head!");
        }
        private void EnemySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " withdrew its head!");
        }
        private void MySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " is glowing!");
        }
        private void EnemySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " is glowing!");
        }
        private void MyRegainedHealthEventHandler(MoveEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " regained health!");
        }
        private void EnemyRegainedHealthEventHandler(MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " regained health!");
        }



        //===================================================================================//
        //                       BATTLE POKEMON EVENT HANDLERS                               //
        //===================================================================================//
        private void MySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            QueueMessage("Come back " + args.pokemon.Nickname + "!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!");
        }
        private void EnemySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " was withdrawn!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!");
        }
        private void MyStatStageChangedEventHandler(object sender, StatStageChangedEventArgs args)
        {
            string stat = args.statChanged.ToString();
            string change;
            if (args.change == 2)
            {
                change = "sharply rose!";
            }
            else if (args.change == 1)
            {
                change = "rose!";
            }
            else if (args.change == -1)
            {
                change = "decreased!";
            }
            else
            {
                change = "sharply decreased!";
            }
            QueueMessage(args.pokemon.Nickname + "'s " + stat + " stat " + change);
        }
        private void EnemyStatStageChangedEventHandler(object sender, StatStageChangedEventArgs args)
        {
            string stat = args.statChanged.ToString();
            string change;
            if (args.change == 2)
            {
                change = "sharply rose!";
            }
            else if (args.change == 1)
            {
                change = "rose!";
            }
            else if (args.change == -1)
            {
                change = "decreased!";
            }
            else
            {
                change = "sharply decreased!";
            }
            QueueMessage("Enemy " + args.pokemon.Nickname + "'s " + stat + " stat " + change);
        }
        private void MyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.battlePokemon.Name + " was seeded!");
        }
        private void EnemyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.battlePokemon.Name + " was seeded!");
        }
        private void MyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Leech seed saps " + args.pokemon.Nickname);
        }
        private void EnemyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Leech seed saps enemy " + args.pokemon.Nickname);
        }
        private void MySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " created a substitute!");
        }
        private void EnemySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " created a substitute!");
        }
        private void MyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " changed type!");
        }
        private void EnemyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " changed type!");
        }
        private void MyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!");
        }
        private void EnemyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!");
        }
        private void HurtFromConfusionEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("It hurt itself in confusion!");
        }
        private void MyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " flinched!");
        }
        private void EnemyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " flinched!");
        }
        private void MyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " is fully paralyzed!");
        }
        private void EnemyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " is fully paralyzed!");
        }
        private void MyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " is frozen solid!");
        }
        private void EnemyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " is frozen solid!");
        }
        private void MyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " is fast asleep!");
        }
        private void EnemyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " is fast asleep!");
        }
        private void MyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " woke up!");
        }
        private void EnemyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " woke up!");
        }
        private void MyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!");
        }
        private void EnemyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!");
        }
        private void MyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " is disabled!");
        }
        private void EnemyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " is disabled!");
        }
        private void MyMimicEventHandler(object sender, MimicMoveEventArgs args)
        {
            QueueMessage(args.pokemon.Nickname + " copied enemy " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }
        private void EnemyMimicEventHandler(object sender,MimicMoveEventArgs args)
        {
            QueueMessage("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name);
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }


    }
}
