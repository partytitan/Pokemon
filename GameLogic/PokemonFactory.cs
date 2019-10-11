using System;
using System.Collections.Generic;
using System.Text;
using GameLogic.Moves;
using GameLogic.Moves.Reflexive;
using GameLogic.Moves.Transitive.Attack.MultiTurn;
using GameLogic.Moves.Transitive.Attack.OneTurnMultiHit;
using GameLogic.Moves.Transitive.Attack.OneTurnOneHit;
using GameLogic.Moves.Transitive.Status;
using GameLogic.PokemonData;

namespace GameLogic
{
    public static class PokemonFactory
    {
        private static Pokemon Create(int number, float level, Move move1, Move move2, Move move3, Move move4)
        {
            return Pokemon.Builder.Init(number, level)
                .Move1(move1)
                .Move2(move2)
                .Move3(move3)
                .Move4(move4)
                .Create();
        }

        public static Pokemon PokemonMaker(string name, int level)
        {
            switch (name)
            {
                case "Bulbasaur": // Bulbasaur
                    return Create(1, level, new RazorLeaf(), new LeechSeed(), new BodySlam(), new Growth());

                case "Ivysaur": // Ivysaur
                    return Create(2, level, new LeechSeed(), new RazorLeaf(), new Growth(), new MegaDrain());

                case "Venusaur": // Venusaur
                    return Create(3, level, new Growth(), new LeechSeed(), new SolarBeam(), new SleepPowder());

                case "Charmander": // Charmander
                    return Create(4, level, new SeismicToss(), new Flamethrower(), new Dig(), new BodySlam());

                case "Charmeleon": // Charmeleon
                    return Create(5, level, new Slash(), new Flamethrower(), new Dig(), new Submission());

                case "Charizard": // Charizard
                    return Create(6, level, new FireBlast(), new Fly(), new FireSpin(), new SwordsDance());

                case "Squirtle": // Squirtle
                    return Create(7, level, new Dig(), new Surf(), new BodySlam(), new Blizzard());

                case "Wartortle": // Wartortle
                    return Create(8, level, new SeismicToss(), new Surf(), new Toxic(), new Dig());

                case "Blastoise": // Blastoise
                    return Create(9, level, new TailWhip(), new HydroPump(), new Withdraw(), new SkullBash());

                case "Caterpie": // Caterpie
                    return Create(10, level, new StringShot(), new Tackle(), null, null);

                case "Metapod": // Metapod
                    return Create(11, level, new StringShot(), new Tackle(), null, null);

                case "Butterfree": // Butterfree
                    return Create(12, level, new StunSpore(), new Psychic(), new MegaDrain(), new Swift());

                case "Weedle": // Weedle
                    return Create(13, level, new StringShot(), new PoisonSting(), null, null);

                case "Kakuna": // Kakuna
                    return Create(14, level, new StringShot(), new PoisonSting(), null, null);

                case "Beedrill": // Beedrill
                    return Create(15, level, new FocusEnergy(), new Twineedle(), new MegaDrain(), new HyperBeam());

                case "Pidgey": // Pidgey
                    return Create(16, level, new Tackle(), new Fly(), new SandAttack(), new MirrorMove());

                case "Pidgeotto": // Pidgeotto
                    return Create(17, level, new Swift(), new Fly(), new SandAttack(), new Toxic());

                case "Pidgeot": // Pidgeot
                    return Create(18, level, new SandAttack(), new MirrorMove(), new QuickAttack(), new Fly());

                case "Rattata": // Rattata
                    return Create(19, level, new Dig(), new SuperFang(), new BodySlam(), new Toxic());

                case "Raticate": // Raticate
                    return Create(20, level, new Toxic(), new HyperFang(), new QuickAttack(), new SuperFang());

                case "Spearow": // Spearow
                    return Create(21, level, new Swift(), new DrillPeck(), new DoubleTeam(), new Fly());

                case "Fearow": // Fearow
                    return Create(22, level, new Growl(), new DrillPeck(), new HyperBeam(), new MirrorMove());

                case "Ekans": // Ekans
                    return Create(23, level, new DoubleEdge(), new Earthquake(), new Glare(), new MegaDrain());

                case "Arbok": // Arbok
                    return Create(24, level, new Strength(), new Glare(), new Dig(), new Acid());

                case "Pikachu": // Pikachu
                    return Create(25, level, new Reflect(), new Thunderbolt(), new ThunderWave(), new Swift());

                case "Raichu": // Raichu
                    return Create(26, level, new MegaKick(), new Thunder(), new QuickAttack(), new ThunderWave());

                case "Sandshrew": // Sandshrew
                    return Create(27, level, new SandAttack(), new Earthquake(), new RockSlide(), new Slash());

                case "Sandslash": // Sandslash
                    return Create(28, level, new SandAttack(), new Dig(), new RockSlide(), new Strength());

                case "Nidoran Female": // Nidoran Female
                    return Create(29, level, new Blizzard(), new Toxic(), new BodySlam(), new Thunderbolt());

                case "Nidorina": // Nidorina
                    return Create(30, level, new BubbleBeam(), new Toxic(), new BodySlam(), new Thunder());

                case "Nidoqueen": // Nidoqueen
                    return Create(31, level, new Earthquake(), new Toxic(), new RockSlide(), new DoubleKick());

                case "Nidoran Male": // Nidoran Male
                    return Create(32, level, new Thunder(), new Blizzard(), new HornDrill(), new BodySlam());

                case "Nidorino": // Nidorino
                    return Create(33, level, new Thunderbolt(), new IceBeam(), new BodySlam(), new HornDrill());

                case "Nidoking": // Nidoking
                    return Create(34, level, new Bide(), new Earthquake(), new HornAttack(), new HornDrill());

                case "Clefairy": // Clefairy
                    return Create(35, level, new Blizzard(), new ThunderWave(), new BodySlam(), new Metronome());

                case "Clefable": // Clefable
                    return Create(36, level, new Metronome(), new Thunder(), new Strength(), new ThunderWave());

                case "Vulpix": // Vulpix
                    return Create(37, level, new Toxic(), new Flamethrower(), new ConfuseRay(), new Dig());

                case "Ninetails": // Ninetails
                    return Create(38, level, new TailWhip(), new FireBlast(), new ConfuseRay(), new QuickAttack());

                case "Jigglypuff": // Jigglypuff
                    return Create(39, level, new Flash(), new Sing(), new SeismicToss(), new BodySlam());

                case "Wigglytuff": // Wigglytuff
                    return Create(40, level, new Strength(), new Sing(), new Disable(), new HyperBeam());

                case "Zubat": // Zubat
                    return Create(41, level, new Swift(), new ConfuseRay(), new Haze(), new MegaDrain());

                case "Golbat": // Golbat
                    return Create(42, level, new Haze(), new HyperBeam(), new Supersonic(), new MegaDrain());

                case "Oddish": // Oddish
                    return Create(43, level, new DoubleEdge(), new PetalDance(), new MegaDrain(), new StunSpore());

                case "Gloom": // Gloom
                    return Create(44, level, new StunSpore(), new PetalDance(), new MegaDrain(), new Acid());

                case "Vileplume": // Vileplume
                    return Create(45, level, new SolarBeam(), new MegaDrain(), new Acid(), new StunSpore());

                case "Paras": // Paras
                    return Create(46, level, new MegaDrain(), new Spore(), new Dig(), new Slash());

                case "Parasect": // Parasect
                    return Create(47, level, new MegaDrain(), new Spore(), new Growth(), new Slash());

                case "Venonat": // Venonat
                    return Create(48, level, new Toxic(), new Psychic(), new DoubleEdge(), new MegaDrain());

                case "Venomoth": // Venomoth
                    return Create(49, level, new Flash(), new Psychic(), new MegaDrain(), new SleepPowder());

                case "Diglett": // Diglett
                    return Create(50, level, new Fissure(), new Earthquake(), new SandAttack(), new Slash());

                case "Dugtrio": // Dugtrio
                    return Create(51, level, new Growl(), new Dig(), new RockSlide(), new SandAttack());

                case "Meowth": // Meowth
                    return Create(52, level, new Screech(), new Slash(), new BubbleBeam(), new Thunderbolt());

                case "Persian": // Persian
                    return Create(53, level, new HyperBeam(), new Thunder(), new Screech(), new Bite());

                case "Psyduck": // Psyduck
                    return Create(54, level, new Blizzard(), new HydroPump(), new Dig(), new Disable());

                case "Golduck": // Golduck
                    return Create(55, level, new Disable(), new IceBeam(), new Confusion(), new BubbleBeam());

                case "Mankey": // Mankey
                    return Create(56, level, new Thrash(), new Submission(), new Counter(), new Dig());

                case "Primeape": // Primeape
                    return Create(57, level, new Thrash(), new SeismicToss(), new LowKick(), new Counter());

                case "Growlithe": // Growlithe
                    return Create(58, level, new Dig(), new Flamethrower(), new DoubleTeam(), new BodySlam());

                case "Arcanine": // Arcanine
                    return Create(59, level, new Leer(), new FireBlast(), new Agility(), new Dig());

                case "Poliwag": // Poliwag
                    return Create(60, level, new HydroPump(), new Amnesia(), new Blizzard(), new Psychic());

                case "Poliwhirl": // Poliwhirl
                    return Create(61, level, new Surf(), new IceBeam(), new Psychic(), new Amnesia());

                case "Poliwrath": // Poliwrath
                    return Create(62, level, new BubbleBeam(), new Amnesia(), new Submission(), new Hypnosis());

                case "Abra": // Abra
                    return Create(63, level, new Psychic(), new BodySlam(), new ThunderWave(), new DoubleTeam());

                case "Kadabra": // Kadabra
                    return Create(64, level, new Psychic(), new Reflect(), new Dig(), new Recover());

                case "Alakazam": // Alakazam
                    return Create(65, level, new Psybeam(), new Reflect(), new HyperBeam(), new Kinesis());

                case "Machop": // Machop
                    return Create(66, level, new Submission(), new FocusEnergy(), new BodySlam(), new SeismicToss());

                case "Machoke": // Machoke
                    return Create(67, level, new Submission(), new FocusEnergy(), new Dig(), new SeismicToss());

                case "Machamp": // Machamp
                    return Create(68, level, new FocusEnergy(), new LowKick(), new MegaPunch(), new Leer());

                case "Bellsprout": // Bellsprout
                    return Create(69, level, new RazorLeaf(), new DoubleEdge(), new Toxic(), new Wrap());

                case "Weepinbell": // Weepinbell
                    return Create(70, level, new RazorLeaf(), new StunSpore(), new MegaDrain(), new Growth());

                case "Victreebel": // Victreebel
                    return Create(71, level, new RazorLeaf(), new SleepPowder(), new Acid(), new Wrap());

                case "Tentacool": // Tentacool
                    return Create(72, level, new Surf(), new Toxic(), new Blizzard(), new MegaDrain());

                case "Tentacruel": // Tentacruel
                    return Create(73, level, new BubbleBeam(), new Toxic(), new Wrap(), new Screech());

                case "Geodude": // Geodude
                    return Create(74, level, new RockSlide(), new FireBlast(), new Earthquake(), new SeismicToss());

                case "Graveler": // Graveler
                    return Create(75, level, new RockSlide(), new Metronome(), new Earthquake(), new FireBlast());

                case "Golem": // Golem
                    return Create(76, level, new RockThrow(), new Dig(), new DefenseCurl(), new FireBlast());

                case "Ponyta": // Ponyta
                    return Create(77, level, new FireSpin(), new Toxic(), new Agility(), new HornDrill());

                case "Rapidash": // Rapidash
                    return Create(78, level, new FireBlast(), new TailWhip(), new Stomp(), new Reflect());

                case "Slowpoke": // Slowpoke
                    return Create(79, level, new Surf(), new MegaPunch(), new Psychic(), new Disable());

                case "Slowbro": // Slowbro
                    return Create(80, level, new Surf(), new MegaPunch(), new Psychic(), new Disable());

                case "Magnemite": // Magnemite
                    return Create(81, level, new Thunderbolt(), new ThunderWave(), new Flash(), new Swift());

                case "Magneton": // Magneton
                    return Create(82, level, new ThunderWave(), new Supersonic(), new Thunder(), new Flash());

                case "Farfetch'd": // Farfetch'd
                    return Create(83, level, new Slash(), new Toxic(), new SandAttack(), new Fly());

                case "Doduo": // Doduo
                    return Create(84, level, new DrillPeck(), new BodySlam(), new DoubleTeam(), new Reflect());

                case "Dodrio": // Dodrio
                    return Create(85, level, new TriAttack(), new Agility(), new Fly(), new Growl());

                case "Seel": // Seel
                    return Create(86, level, new Surf(), new DoubleTeam(), new Blizzard(), new BodySlam());

                case "Dewgong": // Dewgong
                    return Create(87, level, new AuroraBeam(), new HornDrill(), new Surf(), new Headbutt());

                case "Grimer": // Grimer
                    return Create(88, level, new Sludge(), new AcidArmor(), new BodySlam(), new Thunderbolt());

                case "Muk": // Muk
                    return Create(89, level, new Sludge(), new AcidArmor(), new FireBlast(), new Screech());

                case "Shellder": // Shellder
                    return Create(90, level, new Blizzard(), new Supersonic(), new Surf(), new Swift());

                case "Cloyster": // Cloyster
                    return Create(91, level, new IceBeam(), new Supersonic(), new BubbleBeam(), new Clamp());

                case "Gastly": // Gastly
                    return Create(92, level, new Psychic(), new NightShade(), new Hypnosis(), new ConfuseRay());

                case "Haunter": // Haunter
                    return Create(93, level, new Psychic(), new Hypnosis(), new DreamEater(), new ConfuseRay());

                case "Gengar": // Gengar
                    return Create(94, level, new Hypnosis(), new NightShade(), new DreamEater(), new Metronome());

                case "Onix": // Onix
                    return Create(95, level, new RockSlide(), new Selfdestruct(), new Earthquake(), new Fissure());

                case "Drowzee": // Drowzee
                    return Create(96, level, new Hypnosis(), new Psychic(), new DreamEater(), new SeismicToss());

                case "Hypno": // Hypno
                    return Create(97, level, new Hypnosis(), new Psychic(), new PoisonGas(), new Headbutt());

                case "Krabby": // Krabby
                    return Create(98, level, new Surf(), new Guillotine(), new BodySlam(), new Blizzard());

                case "Kingler": // Kingler
                    return Create(99, level, new Crabhammer(), new Toxic(), new Strength(), new Guillotine());

                case "Voltorb": // Voltorb
                    return Create(level, level, new Thunderbolt(), new Reflect(), new ThunderWave(), new TakeDown());

                case "Electrode": // Electrode
                    return Create(101, level, new Thunder(), new ThunderWave(), new Swift(), new Flash());

                case "Exeggcute": // Exeggcute
                    return Create(102, level, new LeechSeed(), new Selfdestruct(), new Toxic(), new Psychic());

                case "Exeggutor": // Exeggutor
                    return Create(103, level, new Stomp(), new SleepPowder(), new Psychic(), new SolarBeam());

                case "Cubone": // Cubone
                    return Create(104, level, new Bonemerang(), new FocusEnergy(), new Blizzard(), new Thrash());

                case "Marowak": // Marowak
                    return Create(105, level, new BoneClub(), new FocusEnergy(), new Headbutt(), new Thrash());

                case "Hitmonlee": // Hitmonlee
                    return Create(106, level, new RollingKick(), new FocusEnergy(), new JumpKick(), new HiJumpKick());

                case "Hitmonchan": // Hitmonchan
                    return Create(107, level, new MegaPunch(), new ThunderPunch(), new FirePunch(), new IcePunch());

                case "Lickitung": // Lickitung
                    return Create(108, level, new BodySlam(), new Blizzard(), new Thunder(), new Earthquake());

                case "Koffing": // Koffing
                    return Create(109, level, new Sludge(), new Toxic(), new Thunder(), new Haze());

                case "Weezing": // Weezing
                    return Create(110, level, new Sludge(), new Mimic(), new Thunder(), new Haze());

                case "Rhyhorn": // Rhyhorn
                    return Create(111, level, new BodySlam(), new Fissure(), new Earthquake(), new RockSlide());

                case "Rhydon": // Rhydon
                    return Create(112, level, new HornAttack(), new Fissure(), new Earthquake(), new Thunder());

                case "Chansey": // Chansey
                    return Create(113, level, new EggBomb(), new SeismicToss(), new Rest(), new Metronome());

                case "Tangela": // Tangela
                    return Create(114, level, new StunSpore(), new SolarBeam(), new MegaDrain(), new Growth());

                case "Kangaskhan": // Kangaskhan
                    return Create(115, level, new DizzyPunch(), new Substitute(), new RockSlide(), new Surf());

                case "Horsea": // Horsea
                    return Create(116, level, new HydroPump(), new Smokescreen(), new IceBeam(), new Toxic());

                case "Seadra": // Seadra
                    return Create(117, level, new Smokescreen(), new Surf(), new DoubleEdge(), new Toxic());

                case "Goldeen": // Goldeen
                    return Create(118, level, new Surf(), new Agility(), new HornDrill(), new DoubleTeam());

                case "Seaking": // Seaking
                    return Create(119, level, new Waterfall(), new FuryAttack(), new HornDrill(), new Supersonic());

                case "Staryu": // Staryu
                    return Create(120, level, new Minimize(), new Recover(), new Surf(), new Psychic());

                case "Starmie": // Starmie
                    return Create(121, level, new BubbleBeam(), new Thunder(), new Swift(), new Minimize());

                case "Mr. Mime": // Mr. Mime
                    return Create(122, level, new Barrier(), new HyperBeam(), new LightScreen(), new Psychic());

                case "Scyther": // Scyther
                    return Create(123, level, new FocusEnergy(), new DoubleTeam(), new HyperBeam(), new Swift());

                case "Jynx": // Jynx
                    return Create(124, level, new LovelyKiss(), new BodySlam(), new IcePunch(), new Psychic());

                case "Electabuzz": // Electabuzz
                    return Create(125, level, new ThunderPunch(), new Metronome(), new ThunderWave(), new Reflect());

                case "Magmar": // Magmar
                    return Create(126, level, new ConfuseRay(), new FirePunch(), new MegaPunch(), new Psychic());

                case "Pinsir": // Pinsir
                    return Create(127, level, new Slash(), new SeismicToss(), new Toxic(), new Guillotine());

                case "Tauros": // Tauros
                    return Create(128, level, new Stomp(), new FireBlast(), new SkullBash(), new Bide());

                case "Magikarp": // Magikarp
                    return Create(129, level, new Splash(), new Tackle(), null, null);

                case "Gyarados": // Gyarados
                    return Create(130, level, new BubbleBeam(), new Leer(), new Bite(), new FireBlast());

                case "Lapras": // Lapras
                    return Create(131, level, new BubbleBeam(), new IceBeam(), new Mist(), new Sing());

                case "Ditto": // Ditto
                    return Create(132, level, new Transform(), null, null, null);

                case "Eevee": // Eevee
                    return Create(133, level, new DoubleEdge(), new QuickAttack(), new FocusEnergy(), new SandAttack());

                case "Vaporeon": // Vaporeon
                    return Create(134, level, new HydroPump(), new QuickAttack(), new AcidArmor(), new Haze());

                case "Jolteon": // Jolteon
                    return Create(135, level, new Thunder(), new QuickAttack(), new PinMissile(), new SandAttack());

                case "Flareon": // Flareon
                    return Create(136, level, new FireBlast(), new QuickAttack(), new Smog(), new SandAttack());

                case "Porygon": // Porygon
                    return Create(137, level, new Psybeam(), new Recover(), new TriAttack(), new Conversion());

                case "Omanyte": // Omanyte
                    return Create(138, level, new HydroPump(), new Toxic(), new BodySlam(), new IceBeam());

                case "Omastar": // Omastar
                    return Create(139, level, new Surf(), new Toxic(), new SpikeCannon(), new HornDrill());

                case "Kabuto": // Kabuto
                    return Create(140, level, new Surf(), new DoubleTeam(), new Blizzard(), new Slash());

                case "Kabutops": // Kabutops
                    return Create(141, level, new HydroPump(), new SwordsDance(), new MegaKick(), new IceBeam());

                case "Aerodactyl": // Aerodactyl
                    return Create(142, level, new Supersonic(), new Bite(), new FireBlast(), new Fly());

                case "Snorlax": // Snorlax
                    return Create(143, level, new TakeDown(), new Bide(), new Metronome(), new Rest());

                case "Articuono": // Articuono
                    return Create(144, level, new IceBeam(), new Agility(), new SkyAttack(), new Mist());

                case "Zapdos": // Zapdos
                    return Create(145, level, new Thunder(), new Flash(), new SkyAttack(), new Bide());

                case "Moltres": // Moltres
                    return Create(146, level, new FireBlast(), new Reflect(), new SkyAttack(), new Agility());

                case "Dratini": // Dratini
                    return Create(147, level, new Blizzard(), new FireBlast(), new Thunderbolt(), new BodySlam());

                case "Dragonair": // Dragonair
                    return Create(148, level, new BodySlam(), new Thunderbolt(), new FireBlast(), new IceBeam());

                case "Dragonite": // Dragonite
                    return Create(149, level, new Thunder(), new FireBlast(), new Wrap(), new Slam());

                //=============================
                // THERE IS NO MEWTWO (No. 150)
                //=============================

                case "Mew": // Mew
                    return Create(151, level, new Psychic(), new Metronome(), new MegaPunch(), new Flash());

                default: throw new ArgumentException("The given index " + name + " is an invalid pokemon name");
            }
        }
    }
}
