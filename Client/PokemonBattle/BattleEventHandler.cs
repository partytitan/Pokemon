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
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was burned!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was burned!", screen.Input, ScreenBattle.Window));
        }
        private void MyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was frozen!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was frozen!", screen.Input, ScreenBattle.Window));
        }
        private void MyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was paralyzed!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was paralyzed!", screen.Input, ScreenBattle.Window));
        }
        private void MyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was poisoned!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was poisoned!", screen.Input, ScreenBattle.Window));
        }
        private void MyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was badly poisoned!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was badly poisoned!", screen.Input, ScreenBattle.Window));
        }
        private void MyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " fell asleep!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " fell asleep!", screen.Input, ScreenBattle.Window));
        }
        private void MyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + "'s status was cleared!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + "'s status was cleared!", screen.Input, ScreenBattle.Window));
        }
        private void MyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " fainted!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " fainted!", screen.Input, ScreenBattle.Window));
        }



        //===================================================================================//
        //                           MOVE EVENT HANDLERS                                     //
        //===================================================================================//
        private void MyMoveUsedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " used " + args.move.Name + "!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyMoveUsedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " used " + args.move.Name + "!", screen.Input, ScreenBattle.Window));
        }
        private void MoveFailedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("... but it failed!", screen.Input, ScreenBattle.Window));
        }
        private void MoveMissedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("but it missed!", screen.Input, ScreenBattle.Window));
        }
        private void MoveHadNoEffectEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("but it had no effect!", screen.Input, ScreenBattle.Window));
        }
        private void MoveSuperEffectiveEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("It's super effective!", screen.Input, ScreenBattle.Window));
        }
        private void MoveNotVeryEffectiveEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("It's not very effective!", screen.Input, ScreenBattle.Window));
        }
        private void MoveCriticalHitEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Critical hit!", screen.Input, ScreenBattle.Window));
        }
        private void MoveOneHitKOEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("One-hit KO!", screen.Input, ScreenBattle.Window));
        }
        private void PayDayTriggeredEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Coins scattered everywhere!", screen.Input, ScreenBattle.Window));
        }
        private void MySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " took in sunlight!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " took in sunlight!", screen.Input, ScreenBattle.Window));
        }
        private void MyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " made a whirlwind!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " made a whirlwind!", screen.Input, ScreenBattle.Window));
        }
        private void MyBidingTimeEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is biding its time!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyBidingTimeEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is biding its time!", screen.Input, ScreenBattle.Window));
        }
        private void MyBideUnleashedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " unleased bide!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyBideUnleashedEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " unleased bide!", screen.Input, ScreenBattle.Window));
        }
        private void MyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " flew up high!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " flew up high!", screen.Input, ScreenBattle.Window));
        }
        private void MyAttackContinuesEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + "'s attack continues!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyAttackContinuesEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + "'s attack continues!", screen.Input, ScreenBattle.Window));
        }
        private void MyCrashDamageEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was hurt by crash damage!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyCrashDamageEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was hurt by crash damage!", screen.Input, ScreenBattle.Window));
        }
        private void MyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was hurt by recoil damage!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was hurt by recoil damage!", screen.Input, ScreenBattle.Window));
        }
        private void MyThrashingAboutEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is thrashing about!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyThrashingAboutEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is thrashing about!", screen.Input, ScreenBattle.Window));
        }
        private void MyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is recharging!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is recharging!", screen.Input, ScreenBattle.Window));
        }
        private void MySuckedHealthEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " sucked health!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySuckedHealthEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " sucked health!", screen.Input, ScreenBattle.Window));
        }
        private void MyDugAHoleEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " dug a hole!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyDugAHoleEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " dug a hole!", screen.Input, ScreenBattle.Window));
        }
        private void MySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " withdrew its head!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " withdrew its head!", screen.Input, ScreenBattle.Window));
        }
        private void MySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is glowing!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is glowing!", screen.Input, ScreenBattle.Window));
        }
        private void MyRegainedHealthEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " regained health!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyRegainedHealthEventHandler(MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " regained health!", screen.Input, ScreenBattle.Window));
        }



        //===================================================================================//
        //                       BATTLE POKEMON EVENT HANDLERS                               //
        //===================================================================================//
        private void MySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Come back " + args.pokemon.Nickname + "!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " was withdrawn!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!", screen.Input, ScreenBattle.Window));
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
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + "'s " + stat + " stat " + change, screen.Input, ScreenBattle.Window));
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
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + "'s " + stat + " stat " + change, screen.Input, ScreenBattle.Window));
        }
        private void MyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was seeded!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was seeded!", screen.Input, ScreenBattle.Window));
        }
        private void MyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Leech seed saps " + args.pokemon.Nickname, screen.Input, ScreenBattle.Window));
        }
        private void EnemyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Leech seed saps enemy " + args.pokemon.Nickname, screen.Input, ScreenBattle.Window));
        }
        private void MySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " created a substitute!", screen.Input, ScreenBattle.Window));
        }
        private void EnemySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " created a substitute!", screen.Input, ScreenBattle.Window));
        }
        private void MyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " changed type!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " changed type!", screen.Input, ScreenBattle.Window));
        }
        private void MyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!", screen.Input, ScreenBattle.Window));
        }
        private void HurtFromConfusionEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("It hurt itself in confusion!", screen.Input, ScreenBattle.Window));
        }
        private void MyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " flinched!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " flinched!", screen.Input, ScreenBattle.Window));
        }
        private void MyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is fully paralyzed!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is fully paralyzed!", screen.Input, ScreenBattle.Window));
        }
        private void MyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is frozen solid!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is frozen solid!", screen.Input, ScreenBattle.Window));
        }
        private void MyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is fast asleep!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is fast asleep!", screen.Input, ScreenBattle.Window));
        }
        private void MyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " woke up!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " woke up!", screen.Input, ScreenBattle.Window));
        }
        private void MyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!", screen.Input, ScreenBattle.Window));
        }
        private void MyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is disabled!", screen.Input, ScreenBattle.Window));
        }
        private void EnemyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is disabled!", screen.Input, ScreenBattle.Window));
        }
        private void MyMimicEventHandler(object sender, MimicMoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " copied enemy " + args.opponent.Name + "'s " + args.moveMimiced.Name, screen.Input, ScreenBattle.Window));
        }
        private void EnemyMimicEventHandler(object sender,MimicMoveEventArgs args)
        {
            screen.WindowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name, screen.Input, ScreenBattle.Window));
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }
    }
}
