using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using GameLogic.Battles;

namespace Client.PokemonBattle
{
    internal class BattleEventsHandler
    {
        private readonly ScreenBattle screen;

        public BattleEventsHandler(ScreenBattle screen)
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
            battle.BattleOver += BattleOverEventHandler;
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
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Battle has begun!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void BattleOverEventHandler(object sender, BattleEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage($"Battle over! {Environment.NewLine} " + (args.thisBattle.IsPlayerDefeated ? "You lost!" : "You won!") , new InputKeyboard(), ScreenBattle.Window));
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
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was burned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was burned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was frozen!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was frozen!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was paralyzed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was paralyzed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was poisoned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was poisoned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was badly poisoned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was badly poisoned!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " fell asleep!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " fell asleep!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + "'s status was cleared!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + "'s status was cleared!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " fainted!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " fainted!", new InputKeyboard(), ScreenBattle.Window));
        }



        //===================================================================================//
        //                           MOVE EVENT HANDLERS                                     //
        //===================================================================================//
        private void MyMoveUsedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " used " + args.move.Name + "!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyMoveUsedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " used " + args.move.Name + "!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveFailedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("... but it failed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveMissedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("but it missed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveHadNoEffectEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("but it had no effect!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveSuperEffectiveEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("It's super effective!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveNotVeryEffectiveEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("It's not very effective!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveCriticalHitEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Critical hit!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MoveOneHitKOEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("One-hit KO!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void PayDayTriggeredEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Coins scattered everywhere!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " took in sunlight!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " took in sunlight!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " made a whirlwind!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " made a whirlwind!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyBidingTimeEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is biding its time!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyBidingTimeEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is biding its time!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyBideUnleashedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " unleased bide!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyBideUnleashedEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " unleased bide!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " flew up high!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " flew up high!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyAttackContinuesEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + "'s attack continues!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyAttackContinuesEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + "'s attack continues!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyCrashDamageEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was hurt by crash damage!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyCrashDamageEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was hurt by crash damage!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was hurt by recoil damage!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was hurt by recoil damage!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyThrashingAboutEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is thrashing about!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyThrashingAboutEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is thrashing about!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is recharging!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is recharging!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MySuckedHealthEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " sucked health!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySuckedHealthEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " sucked health!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyDugAHoleEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " dug a hole!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyDugAHoleEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " dug a hole!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " withdrew its head!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " withdrew its head!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " is glowing!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " is glowing!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyRegainedHealthEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " regained health!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyRegainedHealthEventHandler(MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " regained health!", new InputKeyboard(), ScreenBattle.Window));
        }



        //===================================================================================//
        //                       BATTLE POKEMON EVENT HANDLERS                               //
        //===================================================================================//
        private void MySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Come back " + args.pokemon.Nickname + "!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " was withdrawn!" + Environment.NewLine + "Go " + args.switchIn.Nickname + "!", new InputKeyboard(), ScreenBattle.Window));
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
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + "'s " + stat + " stat " + change, new InputKeyboard(), ScreenBattle.Window));
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
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + "'s " + stat + " stat " + change, new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.battlePokemon.Name + " was seeded!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.battlePokemon.Name + " was seeded!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Leech seed saps " + args.pokemon.Nickname, new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Leech seed saps enemy " + args.pokemon.Nickname, new InputKeyboard(), ScreenBattle.Window));
        }
        private void MySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " created a substitute!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " created a substitute!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " changed type!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " changed type!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void HurtFromConfusionEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("It hurt itself in confusion!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " flinched!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " flinched!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is fully paralyzed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is fully paralyzed!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is frozen solid!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is frozen solid!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is fast asleep!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is fast asleep!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " woke up!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " woke up!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " is disabled!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " is disabled!", new InputKeyboard(), ScreenBattle.Window));
        }
        private void MyMimicEventHandler(object sender, MimicMoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage(args.pokemon.Nickname + " copied enemy " + args.opponent.Name + "'s " + args.moveMimiced.Name, new InputKeyboard(), ScreenBattle.Window));
        }
        private void EnemyMimicEventHandler(object sender,MimicMoveEventArgs args)
        {
            screen.windowQueuer.QueueWindow(new WindowBattleMessage("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name, new InputKeyboard(), ScreenBattle.Window));
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }
    }
}
