class_name AK

class EVENTS:

	const IMPACT_FIRE = 3520695494
	const AMBIENT_SFX_PLAY = 2210022288
	const IMPACT_ICE = 744817815
	const STONE_PLATFORM_EMERGE = 1398573350
	const FREEZE = 3285814624
	const ELECTRICITY = 2917121896
	const UI_SPELL_PICKUP = 2097876167
	const UI_ERROR = 1009189048
	const MUSIC_STOP = 3227181061
	const BUTTON_MOUSEOVER = 673585283
	const BRIDGE_CREAKING_PLAY = 52860350
	const AMBIENT_SFX_STOP = 558607410
	const CORRUPTION_IMPACT = 1738147771
	const GHOST_AMBIENCE_PLAY = 429240274
	const PLAYER_SPELL_SHOOT = 3599838629
	const PLAYER_CHARGE_STOP = 2258820276
	const CORRUPTION_SOFT = 2166756653
	const GHOST_SCREAM = 1536175086
	const MUSIC_PLAY = 202194903
	const STONE_EXPLOSION = 3655901332
	const FOOTSTEP = 1866025847
	const STONE_IMPACT = 1069050017
	const BUTTON_PRESS = 2698747613
	const UI_SPELL_DROP = 2589123588
	const BRIDGE_CREAKING_STOP = 1049176448
	const GHOST_AMBIENCE_STOP = 2099324236
	const ENEMY_THROW = 1804917506
	const PLAYER_CHARGE_START = 2823384552
	const DOOR_LOCKED = 3333554874
	const DOOR_OPENING = 2589897592
	const PYLON_CHARGE = 1470625830

	const _dict = {
		"Impact_Fire": IMPACT_FIRE,
		"Ambient_SFX_Play": AMBIENT_SFX_PLAY,
		"Impact_Ice": IMPACT_ICE,
		"Stone_Platform_Emerge": STONE_PLATFORM_EMERGE,
		"Freeze": FREEZE,
		"Electricity": ELECTRICITY,
		"UI_Spell_Pickup": UI_SPELL_PICKUP,
		"UI_Error": UI_ERROR,
		"Music_Stop": MUSIC_STOP,
		"Button_Mouseover": BUTTON_MOUSEOVER,
		"Bridge_Creaking_Play": BRIDGE_CREAKING_PLAY,
		"Ambient_SFX_Stop": AMBIENT_SFX_STOP,
		"Corruption_Impact": CORRUPTION_IMPACT,
		"Ghost_Ambience_Play": GHOST_AMBIENCE_PLAY,
		"Player_Spell_Shoot": PLAYER_SPELL_SHOOT,
		"Player_Charge_Stop": PLAYER_CHARGE_STOP,
		"Corruption_Soft": CORRUPTION_SOFT,
		"Ghost_Scream": GHOST_SCREAM,
		"Music_Play": MUSIC_PLAY,
		"Stone_Explosion": STONE_EXPLOSION,
		"Footstep": FOOTSTEP,
		"Stone_Impact": STONE_IMPACT,
		"Button_Press": BUTTON_PRESS,
		"UI_Spell_Drop": UI_SPELL_DROP,
		"Bridge_Creaking_Stop": BRIDGE_CREAKING_STOP,
		"Ghost_Ambience_Stop": GHOST_AMBIENCE_STOP,
		"Enemy_Throw": ENEMY_THROW,
		"Player_Charge_Start": PLAYER_CHARGE_START,
		"Door_Locked": DOOR_LOCKED,
		"Door_Opening": DOOR_OPENING,
		"Pylon_Charge": PYLON_CHARGE
	}

class STATES:

	class SPELL_TYPE:
		const GROUP = 3830273964

		class STATE:
			const NONE = 748895195
			const FIRE = 2678880713
			const LIGHTNING = 3334464137
			const ICE = 344481046

	class SCENE:
		const GROUP = 1926883983

		class STATE:
			const NONE = 748895195
			const CAVES = 749373321
			const MAINMENU = 3604647259
			const CUTSCENE = 1182958561

	class STEP_TYPE:
		const GROUP = 2817994306

		class STATE:
			const STONE = 1216965916
			const GRAVEL = 2185786256
			const ICE = 344481046
			const NONE = 748895195

	const _dict = {
		"Spell_Type": {
			"GROUP": 3830273964,
			"STATE": {
				"None": 748895195,
				"Fire": 2678880713,
				"Lightning": 3334464137,
				"Ice": 344481046,
			}
		},
		"Scene": {
			"GROUP": 1926883983,
			"STATE": {
				"None": 748895195,
				"Caves": 749373321,
				"MainMenu": 3604647259,
				"Cutscene": 1182958561
			}
		},
		"Step_Type": {
			"GROUP": 2817994306,
			"STATE": {
				"Stone": 1216965916,
				"Gravel": 2185786256,
				"Ice": 344481046,
				"None": 748895195,
			}
		}
	}

class SWITCHES:

	const _dict = {}

class GAME_PARAMETERS:

	const SS_AIR_SIZE = 3074696722
	const SS_AIR_RPM = 822163944
	const SS_AIR_TURBULENCE = 4160247818
	const SS_AIR_FREEFALL = 3002758120
	const SS_AIR_MONTH = 2648548617
	const SS_AIR_PRESENCE = 3847924954
	const SS_AIR_TIMEOFDAY = 3203397129
	const SS_AIR_FURY = 1029930033
	const SS_AIR_FEAR = 1351367891
	const SS_AIR_STORM = 3715662592

	const _dict = {
		"SS_Air_Size": SS_AIR_SIZE,
		"SS_Air_RPM": SS_AIR_RPM,
		"SS_Air_Turbulence": SS_AIR_TURBULENCE,
		"SS_Air_Freefall": SS_AIR_FREEFALL,
		"SS_Air_Month": SS_AIR_MONTH,
		"SS_Air_Presence": SS_AIR_PRESENCE,
		"SS_Air_TimeOfDay": SS_AIR_TIMEOFDAY,
		"SS_Air_Fury": SS_AIR_FURY,
		"SS_Air_Fear": SS_AIR_FEAR,
		"SS_Air_Storm": SS_AIR_STORM
	}

class TRIGGERS:

	const _dict = {}

class BANKS:

	const INIT = 1355168291
	const MAIN = 3161908922

	const _dict = {
		"Init": INIT,
		"Main": MAIN
	}

class BUSSES:

	const MASTER_AUDIO_BUS = 3803692087

	const _dict = {
		"Master Audio Bus": MASTER_AUDIO_BUS
	}

class AUX_BUSSES:

	const _dict = {}

class AUDIO_DEVICES:

	const NO_OUTPUT = 2317455096
	const SYSTEM = 3859886410

	const _dict = {
		"No_Output": NO_OUTPUT,
		"System": SYSTEM
	}

class EXTERNAL_SOURCES:

	const _dict = {}

