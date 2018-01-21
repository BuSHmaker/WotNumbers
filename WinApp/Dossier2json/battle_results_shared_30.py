# uncompyle6 version 2.14.0
# Python bytecode 2.7 (62211)
# Decompiled from: Python 2.7.14 (v2.7.14:84471935ed, Sep 16 2017, 20:19:30) [MSC v.1500 32 bit (Intel)]
# Embedded file name: scripts/common/battle_results_shared.py
import struct
from itertools import izip
from dictpackers_29 import *

class FLAG_ACTION:
    PICKED_UP_FROM_BASE = 0
    PICKED_UP_FROM_GROUND = 1
    CAPTURED = 2
    LOST = 3
    RANGE = (PICKED_UP_FROM_BASE, PICKED_UP_FROM_GROUND, CAPTURED, LOST)


VEHICLE_DEVICE_TYPE_NAMES = (
'engine', 'ammoBay', 'fuelTank', 'radio', 'track', 'gun', 'turretRotator', 'surveyingDevice')
VEHICLE_TANKMAN_TYPE_NAMES = ('commander', 'driver', 'radioman', 'gunner', 'loader')

VEH_INTERACTION_DETAILS = (
 ('spotted', 'B', 1, 0),
 ('deathReason', 'b', 10, -1),
 ('directHits', 'H', 65535, 0),
 ('explosionHits', 'H', 65535, 0),
 ('piercings', 'H', 65535, 0),
 ('damageDealt', 'H', 65535, 0),
 ('damageAssistedTrack', 'H', 65535, 0),
 ('damageAssistedRadio', 'H', 65535, 0),
 ('damageAssistedStun', 'H', 65535, 0),
 ('crits', 'I', 4294967295L, 0),
 ('fire', 'H', 65535, 0),
 ('stunNum', 'H', 65535, 0),
 ('stunDuration', 'f', 65535.0, 0.0),
 ('damageBlockedByArmor', 'I', 4294967295L, 0),
 ('damageReceived', 'H', 65535, 0),
 ('rickochetsReceived', 'H', 65535, 0),
 ('noDamageDirectHitsReceived', 'H', 65535, 0),
 ('targetKills', 'B', 255, 0))
VEH_INTERACTION_DETAILS_NAMES = [ x[0] for x in VEH_INTERACTION_DETAILS ]
VEH_INTERACTION_DETAILS_MAX_VALUES = dict(((x[0], x[2]) for x in VEH_INTERACTION_DETAILS))
VEH_INTERACTION_DETAILS_INIT_VALUES = [ x[3] for x in VEH_INTERACTION_DETAILS ]
VEH_INTERACTION_DETAILS_LAYOUT = ('').join([ x[1] for x in VEH_INTERACTION_DETAILS ])
VEH_INTERACTION_DETAILS_INDICES = dict(((x[1][0], x[0]) for x in enumerate(VEH_INTERACTION_DETAILS)))
VEH_INTERACTION_DETAILS_TYPES = dict(((x[0], x[1]) for x in VEH_INTERACTION_DETAILS))

def _buildMapsForExt(*fields):
    return (
     Meta(*fields),
     tuple(((v[0], v[2]) for v in fields)), {v[0]:i for i, v in enumerate(fields)})


VEH_CELL_RESULTS_EXTS = {'extPublic': {'example': _buildMapsForExt((
                           'stat1', int, 0, None, 'sum'), (
                           'stat2', int, 0, None, 'max'))
                 }
   }
_VEH_CELL_RESULTS_PUBLIC = Meta((
 'health', int, 0, None, 'skip'), (
 'credits', int, 0, None, 'sum'), (
 'xp', int, 0, None, 'sum'), (
 'achievementCredits', int, 0, None, 'skip'), (
 'achievementXP', int, 0, None, 'skip'), (
 'achievementFreeXP', int, 0, None, 'skip'), (
 'shots', int, 0, None, 'sum'), (
 'directHits', int, 0, None, 'sum'), (
 'directTeamHits', int, 0, None, 'sum'), (
 'explosionHits', int, 0, None, 'sum'), (
 'piercings', int, 0, None, 'sum'), (
 'damageDealt', int, 0, None, 'sum'), (
 'sniperDamageDealt', int, 0, None, 'sum'), (
 'damageAssistedRadio', int, 0, None, 'sum'), (
 'damageAssistedTrack', int, 0, None, 'sum'), (
 'damageAssistedStun', int, 0, None, 'sum'), (
 'stunNum', int, 0, None, 'sum'), (
 'stunDuration', float, 0.0, None, 'sum'), (
 'damageReceived', int, 0, None, 'sum'), (
 'damageReceivedFromInvisibles', int, 0, None, 'sum'), (
 'damageBlockedByArmor', int, 0, None, 'sum'), (
 'directHitsReceived', int, 0, None, 'sum'), (
 'noDamageDirectHitsReceived', int, 0, None, 'sum'), (
 'explosionHitsReceived', int, 0, None, 'sum'), (
 'piercingsReceived', int, 0, None, 'sum'), (
 'tdamageDealt', int, 0, None, 'sum'), (
 'tdestroyedModules', int, 0, None, 'sum'), (
 'tkills', int, 0, None, 'sum'), (
 'isTeamKiller', bool, False, None, 'max'), (
 'capturePoints', int, 0, None, 'sum'), ('capturingBase', None, None, None, 'any'), (
 'droppedCapturePoints', int, 0, None, 'sum'), (
 'mileage', int, 0, None, 'sum'), (
 'lifeTime', int, 0, None, 'sum'), (
 'killerID', int, 0, None, 'any'), (
 'achievements', list, [], None, 'extend'), (
 'potentialDamageReceived', int, 0, None, 'sum'), (
 'rolloutsCount', int, 0, None, 'sum'), (
 'deathCount', int, 0, None, 'sum'), (
 'flagActions', list, [0] * len(FLAG_ACTION.RANGE), None, 'sumInEachPos'), (
 'soloFlagCapture', int, 0, None, 'sum'), (
 'flagCapture', int, 0, None, 'sum'), (
 'winPoints', int, 0, None, 'sum'), (
 'resourceAbsorbed', int, 0, None, 'sum'), (
 'stopRespawn', bool, False, None, 'max'), (
 'extPublic', dict, {}, BunchProxyPacker(VEH_CELL_RESULTS_EXTS['extPublic']), 'joinExts'))
_VEH_CELL_RESULTS_PRIVATE = Meta((
 'repair', int, 0, None, 'sum'), (
 'freeXP', int, 0, None, 'sum'), ('details', None, '', None, 'skip'))
_VEH_CELL_RESULTS_SERVER = Meta((
 'canStun', bool, False, None, 'any'), (
 'potentialDamageDealt', int, 0, None, 'sum'), (
 'soloHitsAssisted', int, 0, None, 'sum'), (
 'isEnemyBaseCaptured', bool, False, None, 'max'), (
 'stucks', list, [], DeltaPacker(roundToInt), 'extend'), (
 'autoAimedShots', int, 0, None, 'sum'), (
 'presenceTime', int, 0, None, 'max'), (
 'spotList', list, [], None, 'extend'), (
 'ammo', list, [], None, 'skip'), (
 'crewActivityFlags', list, [], None, 'skip'), (
 'series', dict, {}, None, 'skip'), (
 'tkillRating', float, 0.0, None, 'sum'), (
 'thitPenalties', dict, {}, None, 'joinTHitPenalties'), (
 'destroyedObjects', dict, {}, None, 'sumByEackKey'), (
 'discloseShots', list, [], DeltaPacker(), 'extend'), (
 'critsCount', int, 0, None, 'sum'), (
 'aimerSeries', int, 0, None, 'max'), (
 'observedByEnemyTime', int, -1, None, 'any'), (
 'critsByType', dict, {},
 DictPacker((
  'destroyed', dict, {}, SimpleDictPacker(int, VEHICLE_DEVICE_TYPE_NAMES), 'skip'), (
  'critical', dict, {}, SimpleDictPacker(int, VEHICLE_DEVICE_TYPE_NAMES), 'skip'), (
  'tankman', dict, {}, SimpleDictPacker(int, VEHICLE_TANKMAN_TYPE_NAMES), 'skip')),
 'joinCritsByType'), (
 'innerModuleCritCount', int, 0, None, 'sum'), (
 'innerModuleDestrCount', int, 0, None, 'sum'), (
 'isAnyOurCrittedInnerModules', int, 0, None, 'max'), (
 'killsAssistedTrack', int, 0, None, 'sum'), (
 'killsAssistedRadio', int, 0, None, 'sum'), (
 'killsAssistedStun', int, 0, None, 'sum'), (
 'damagedVehicleCntAssistedTrack', int, 0, None, 'sum'), (
 'damagedVehicleCntAssistedRadio', int, 0, None, 'sum'), (
 'damagedVehicleCntAssistedStun', int, 0, None, 'sum'), (
 'isNotSpotted', bool, True, None, 'max'), (
 'isAnyHitReceivedWhileCapturing', bool, False, None, 'max'), (
 'damageAssistedRadioWhileInvisible', int, 0, None, 'sum'), (
 'damageAssistedTrackWhileInvisible', int, 0, None, 'sum'), (
 'damageAssistedStunWhileInvisible', int, 0, None, 'sum'), (
 'damageEventList', dict, {}, None, 'joinTargetEventLists'), (
 'stunEventList', dict, {}, None, 'joinTargetEventLists'), (
 'multiDamageEvents', dict, {}, None, 'joinDicts'), (
 'multiStunEvents', dict, {}, None, 'joinDicts'), (
 'inBattleMaxSniperSeries', int, 0, None, 'max'), (
 'inBattleMaxKillingSeries', int, 0, None, 'max'), (
 'inBattleMaxPiercingSeries', int, 0, None, 'max'), (
 'firstDamageTime', int, 0, None, 'min'), ('consumedAmmo', None, None, None, 'skip'), (
 'directEnemyHits', int, 0, None, 'sum'), (
 'explosionEnemyHits', int, 0, None, 'sum'), (
 'piercingEnemyHits', int, 0, None, 'sum'), (
 'indirectEnemyHits', int, 0, None, 'sum'), (
 'enemyHits', int, 0, None, 'sum'))
VEH_CELL_RESULTS = _VEH_CELL_RESULTS_PUBLIC + _VEH_CELL_RESULTS_PRIVATE + _VEH_CELL_RESULTS_SERVER
_VEH_BASE_RESULTS_PUBLIC = Meta((
 'accountDBID', int, 0, None, 'any'), (
 'typeCompDescr', int, 0, None, 'skip'), (
 'index', int, 0, None, 'skip'), (
 'deathReason', int, -1, None, 'skip'), (
 'team', int, 1, None, 'skip'), (
 'kills', int, 0, None, 'sum'), (
 'spotted', int, 0, None, 'sum'), (
 'damaged', int, 0, None, 'sum'), (
 'stunned', int, 0, None, 'sum'))
_VEH_BASE_RESULTS_PRIVATE = Meta((
 'xpPenalty', int, 0, None, 'sum'), (
 'creditsPenalty', int, 0, None, 'sum'), (
 'creditsContributionIn', int, 0, None, 'sum'), (
 'creditsContributionOut', int, 0, None, 'sum'), (
 'originalCreditsToDraw', int, 0, None, 'sum'), (
 'creditsToDraw', int, 0, None, 'sum'), (
 'damageBeforeTeamWasDamaged', int, 0, None, 'sum'), (
 'killsBeforeTeamWasDamaged', int, 0, None, 'sum'), (
 'percentFromTotalTeamDamage', float, 0.0, None, 'sum'), (
 'percentFromSecondBestDamage', float, 0.0, None, 'sum'), (
 'killedAndDamagedByAllSquadmates', int, 0, None, 'any'), (
 'damagedWhileMoving', int, 0, None, 'sum'), (
 'damagedWhileEnemyMoving', int, 0, None, 'sum'), (
 'committedSuicide', bool, False, None, 'max'), (
 'crystal', int, 0, None, 'sum'))
_VEH_BASE_RESULTS_SERVER = Meta((
 'spottedBeforeWeBecameSpotted', int, 0, None, 'sum'), (
 'spottedAndDamagedSPG', int, 0, None, 'sum'), (
 'damageList', list, [], None, 'extend'), (
 'killList', list, [], None, 'extend'), (
 'vehLockTimeFactor', float, 0.0, None, 'skip'), (
 'misc', dict, {}, None, 'any'), (
 'vehsByClass', dict, {}, None, 'any'))
VEH_BASE_RESULTS = _VEH_CELL_RESULTS_PUBLIC + _VEH_BASE_RESULTS_PUBLIC + _VEH_CELL_RESULTS_PRIVATE + _VEH_BASE_RESULTS_PRIVATE + _VEH_CELL_RESULTS_SERVER + _VEH_BASE_RESULTS_SERVER
_AVATAR_CELL_RESULTS_PRIVATE = Meta((
 'avatarAmmo', list, [], None, 'skip'), (
 'avatarDamageEventList', set, set(), None, 'skip'))
_AVATAR_CELL_RESULTS_PUBLIC = Meta((
 'avatarDamageDealt', int, 0, None, 'skip'), (
 'avatarKills', int, 0, None, 'skip'))
_AVATAR_BASE_SERVER_RESULTS = Meta((
 'cybersportRatingDeltas', tuple, (0.0, 0.0), None, 'skip'), (
 'vehRankRaised', int, 0, None, 'skip'))
_AVATAR_BASE_PRIVATE_RESULTS = Meta((
 'accountDBID', int, 0, None, 'any'), (
 'team', int, 1, None, 'skip'), (
 'clanDBID', int, 0, None, 'skip'), (
 'fortClanDBIDs', list, [], None, 'skip'), (
 'winnerIfDraw', int, 0, None, 'skip'), (
 'isPrematureLeave', bool, False, None, 'skip'), (
 'watchedBattleToTheEnd', bool, False, None, 'skip'), ('squadBonusInfo', None, None,
                                                       None, 'skip'), (
 'rankChange', int, 0, None, 'skip'), (
 'accRank', tuple, (0, 0), None, 'skip'), (
 'vehRank', tuple, (0, 0), None, 'skip'), (
 'prevAccRank', tuple, (0, 0), None, 'skip'), (
 'prevVehRank', tuple, (0, 0), None, 'skip'), (
 'shields', dict, {}, None, 'skip'), (
 'prevShields', dict, {}, None, 'skip'), (
 'rankedSeason', tuple, (0, 0), None, 'skip'), (
 'eligibleForCrystalRewards', bool, False, None, 'skip'))
_AVATAR_BASE_PUBLIC_RESULTS = Meta((
 'avatarDamaged', int, 0, None, 'skip'), (
 'totalDamaged', int, 0, None, 'skip'), (
 'fairplayViolations', tuple, (0, 0, 0), None, 'skip'), (
 'prevAccRank', tuple, (0, 0), None, 'skip'), (
 'rankedBadge', int, 0, None, 'skip'))
_AVATAR_FULL_RESULTS_PRIVATE = Meta((
 'questsProgress', dict, {}, None, 'skip'))
_PRIVATE_EVENT_RESULTS = Meta((
 'eventCredits', int, 0, None, 'sum'), (
 'eventXP', int, 0, None, 'sum'), (
 'eventFreeXP', int, 0, None, 'sum'), (
 'eventTMenXP', int, 0, None, 'sum'), (
 'eventGold', int, 0, None, 'sum'), (
 'eventCrystal', int, 0, None, 'sum'))
_AVATAR_DELETE_ME = Meta((
 'credits', int, 0, None, 'skip'), (
 'xp', int, 0, None, 'skip'), (
 'freeXP', int, 0, None, 'skip'), (
 'crystal', int, 0, None, 'skip'))
AVATAR_CELL_RESULTS = _AVATAR_CELL_RESULTS_PUBLIC + _AVATAR_CELL_RESULTS_PRIVATE
AVATAR_BASE_RESULTS = AVATAR_CELL_RESULTS + _AVATAR_BASE_PUBLIC_RESULTS + _AVATAR_BASE_SERVER_RESULTS + _AVATAR_BASE_PRIVATE_RESULTS
AVATAR_PUBLIC_RESULTS = _AVATAR_CELL_RESULTS_PUBLIC + _AVATAR_BASE_PUBLIC_RESULTS
AVATAR_FULL_RESULTS = AVATAR_CELL_RESULTS + _AVATAR_BASE_PUBLIC_RESULTS + _AVATAR_BASE_PRIVATE_RESULTS + _AVATAR_FULL_RESULTS_PRIVATE + _PRIVATE_EVENT_RESULTS + _AVATAR_DELETE_ME
VEH_PUBLIC_RESULTS = _VEH_CELL_RESULTS_PUBLIC + _VEH_BASE_RESULTS_PUBLIC
VEH_FULL_RESULTS_UPDATE = Meta((
 'originalCredits', int, 0, None, 'sum'), (
 'creditsReplay', str, '', ValueReplayPacker(), 'skip'), (
 'originalXP', int, 0, None, 'sum'), (
 'xpReplay', str, '', ValueReplayPacker(), 'skip'), (
 'originalFreeXP', int, 0, None, 'sum'), (
 'freeXPReplay', str, '', ValueReplayPacker(), 'skip'), (
 'originalTMenXP', int, 0, None, 'sum'), (
 'tmenXPReplay', str, '', ValueReplayPacker(), 'skip'), (
 'tmenXP', int, 0, None, 'sum'), (
 'originalGold', int, 0, None, 'sum'), (
 'goldReplay', str, '', ValueReplayPacker(), 'skip'), (
 'gold', int, 0, None, 'sum'), (
 'originalCrystal', int, 0, None, 'sum'), (
 'crystalReplay', str, '', ValueReplayPacker(), 'skip'), (
 'factualXP', int, 0, None, 'sum'), (
 'factualFreeXP', int, 0, None, 'sum'), (
 'factualCredits', int, 0, None, 'sum'), (
 'subtotalCredits', int, 0, None, 'sum'), (
 'subtotalXP', int, 0, None, 'sum'), (
 'subtotalFreeXP', int, 0, None, 'sum'), (
 'subtotalTMenXP', int, 0, None, 'sum'), (
 'subtotalGold', int, 0, None, 'sum'), (
 'subtotalCrystal', int, 0, None, 'sum'), (
 'eventCreditsList', list, [], None, 'skip'), (
 'eventXPList', list, [], None, 'skip'), (
 'eventFreeXPList', list, [], None, 'skip'), (
 'eventTMenXPList', list, [], None, 'skip'), (
 'eventGoldList', list, [], None, 'skip'), (
 'eventCrystalList', list, [], None, 'skip'), (
 'eventCreditsFactor100List', list, [], None, 'skip'), (
 'eventXPFactor100List', list, [], None, 'skip'), (
 'eventFreeXPFactor100List', list, [], None, 'skip'), (
 'eventTMenXPFactor100List', list, [], None, 'skip'), (
 'eventGoldFactor100List', list, [], None, 'skip'), (
 'originalXPPenalty', int, 0, None, 'skip'), (
 'originalCreditsPenalty', int, 0, None, 'skip'), (
 'originalCreditsContributionIn', int, 0, None, 'skip'), (
 'originalCreditsContributionOut', int, 0, None, 'sum'), (
 'premiumVehicleXP', int, 0, None, 'sum'), (
 'premiumVehicleXPFactor100', int, 0, None, 'skip'), (
 'squadXP', int, 0, None, 'sum'), (
 'squadXPFactor100', int, 0, None, 'skip'), (
 'premiumXPFactor10', int, 0, None, 'any'), (
 'appliedPremiumXPFactor10', int, 0, None, 'any'), (
 'premiumCreditsFactor10', int, 0, None, 'any'), (
 'appliedPremiumCreditsFactor10', int, 0, None, 'any'), (
 'dailyXPFactor10', int, 0, None, 'max'), (
 'igrXPFactor10', int, 0, None, 'max'), (
 'aogasFactor10', int, 0, None, 'max'), (
 'refSystemXPFactor10', int, 0, None, 'any'), (
 'fairplayFactor10', int, 0, None, 'skip'), (
 'newYearXPFactor100', int, 0, None, 'any'), (
 'newYearTmenXPFactor100', int, 0, None, 'any'), (
 'newYearFreeXPFactor100', int, 0, None, 'any'), (
 'newYearCreditsFactor100', int, 0, None, 'any'), (
 'orderCredits', int, 0, None, 'sum'), (
 'orderXP', int, 0, None, 'sum'), (
 'orderFreeXP', int, 0, None, 'sum'), (
 'orderTMenXP', int, 0, None, 'sum'), (
 'orderCreditsFactor100', int, 0, None, 'any'), (
 'orderXPFactor100', int, 0, None, 'any'), (
 'orderFreeXPFactor100', int, 0, None, 'any'), (
 'orderTMenXPFactor100', int, 0, None, 'any'), (
 'boosterCredits', int, 0, None, 'sum'), (
 'boosterXP', int, 0, None, 'sum'), (
 'boosterFreeXP', int, 0, None, 'sum'), (
 'boosterTMenXP', int, 0, None, 'sum'), (
 'boosterCreditsFactor100', int, 0, None, 'any'), (
 'boosterXPFactor100', int, 0, None, 'any'), (
 'boosterFreeXPFactor100', int, 0, None, 'any'), (
 'boosterTMenXPFactor100', int, 0, None, 'any'), (
 'isPremium', bool, False, None, 'any'), (
 'xpByTmen', list, [], None, 'skip'), (
 'autoRepairCost', int, 0, None, 'skip'), (
 'autoLoadCost', tuple, (0, 0), None, 'skip'), (
 'autoEquipCost', tuple, (0, 0, 0), None, 'skip'), (
 'prevMarkOfMastery', int, 0, None, 'skip'), (
 'markOfMastery', int, 0, None, 'skip'), (
 'dossierPopUps', list, [], None, 'skip'), (
 'vehTypeLockTime', int, 0, None, 'skip'), (
 'serviceProviderID', int, 0, None, 'skip'), (
 'marksOnGun', int, 0, None, 'skip'), (
 'movingAvgDamage', int, 0, None, 'skip'), (
 'damageRating', int, 0, None, 'skip'), (
 'battleNum', int, 0, None, 'skip')) + _PRIVATE_EVENT_RESULTS
_VEH_FULL_RESULTS_PRIVATE = Meta((
 'questsProgress', dict, {}, None, 'joinDicts'))
VEH_FULL_RESULTS_SERVER = Meta((
 'eventGoldByEventID', dict, {}, None, 'skip'))
VEH_FULL_RESULTS = _VEH_CELL_RESULTS_PUBLIC + _VEH_BASE_RESULTS_PUBLIC + _VEH_CELL_RESULTS_PRIVATE + _VEH_BASE_RESULTS_PRIVATE + VEH_FULL_RESULTS_UPDATE + _VEH_FULL_RESULTS_PRIVATE
PLAYER_INFO = Meta((
 'name', str, '', None, 'skip'), (
 'clanDBID', int, 0, None, 'skip'), (
 'clanAbbrev', str, '', None, 'skip'), (
 'prebattleID', int, 0, None, 'skip'), (
 'team', int, 1, None, 'skip'), (
 'igrType', int, 0, None, 'skip'))
COMMON_RESULTS = Meta((
 'arenaTypeID', int, 0, None, 'skip'), (
 'arenaCreateTime', int, 0, None, 'skip'), (
 'winnerTeam', int, 0, None, 'skip'), (
 'finishReason', int, 0, None, 'skip'), (
 'gasAttackWinnerTeam', int, -1, None, 'skip'), (
 'duration', int, 0, None, 'skip'), (
 'bonusType', int, 0, None, 'skip'), (
 'guiType', int, 0, None, 'skip'), (
 'vehLockMode', int, 0, None, 'skip'), ('division', None, None, None, 'skip'), (
 'bots', dict, {}, None, 'skip'))
assert not set(VEH_FULL_RESULTS.names()) & set(COMMON_RESULTS.names())
VEH_INTERACTIVE_STATS = ('xp', 'damageDealt', 'capturePts', 'flagActions', 'winPoints',
                         'deathCount', 'resourceAbsorbed', 'stopRespawn', 'equipmentDamage',
                         'equipmentKills')
VEH_INTERACTIVE_STATS_INDICES = dict(((x[1], x[0]) for x in enumerate(VEH_INTERACTIVE_STATS)))
AVATAR_PRIVATE_STATS = ('ragePoints', )
AVATAR_PRIVATE_STATS_INDICES = dict(((x[1], x[0]) for x in enumerate(AVATAR_PRIVATE_STATS)))

class UNIT_CLAN_MEMBERSHIP:
    NONE = 0
    ANY = 1
    SAME = 2


def dictToList(indices, d):
    l = [
     None] * len(indices)
    for name, index in indices.iteritems():
        l[index] = d[name]

    return l


def listToDict(names, l):
    d = {}
    for x in enumerate(names):
        d[x[1]] = l[x[0]]

    return d


class _VehicleInteractionDetailsItem(object):

    @staticmethod
    def __fmt2py(format):
        if format in ('f', ):
            return float
        return int

    def __init__(self, values, offset):
        self.__values = values
        self.__offset = offset

    def __getitem__(self, key):
        return self.__values[self.__offset + VEH_INTERACTION_DETAILS_INDICES[key]]

    def __setitem__(self, key, value):
        self.__values[self.__offset + VEH_INTERACTION_DETAILS_INDICES[key]] = min(self.__fmt2py(VEH_INTERACTION_DETAILS_TYPES[key])(value), VEH_INTERACTION_DETAILS_MAX_VALUES[key])

    def __str__(self):
        return str(dict(self))

    def __iter__(self):
        return izip(VEH_INTERACTION_DETAILS_NAMES, self.__values[self.__offset:])


class VehicleInteractionDetails(object):

    def __init__(self, uniqueVehIDs, values):
        self.__uniqueVehIDs = uniqueVehIDs
        self.__values = values
        size = len(VEH_INTERACTION_DETAILS)
        self.__offsets = dict(((x[1], x[0] * size) for x in enumerate(uniqueVehIDs)))

    @staticmethod
    def fromPacked(packed):
        count = len(packed) / struct.calcsize(('').join(['<2I', VEH_INTERACTION_DETAILS_LAYOUT]))
        packedVehIDsLayout = '<%dI' % (2 * count,)
        packedVehIDsLen = struct.calcsize(packedVehIDsLayout)
        flatIDs = struct.unpack(packedVehIDsLayout, packed[:packedVehIDsLen])
        uniqueVehIDs = []
        for i in xrange(0, len(flatIDs), 2):
            uniqueVehIDs.append((flatIDs[i], flatIDs[i + 1]))

        values = struct.unpack('<' + VEH_INTERACTION_DETAILS_LAYOUT * count, packed[packedVehIDsLen:])
        return VehicleInteractionDetails(uniqueVehIDs, values)

    def __getitem__(self, uniqueVehID):
        assert type(uniqueVehID) == tuple
        offset = self.__offsets.get(uniqueVehID, None)
        if offset is None:
            self.__uniqueVehIDs.append(uniqueVehID)
            offset = len(self.__values)
            self.__values += VEH_INTERACTION_DETAILS_INIT_VALUES
            self.__offsets[uniqueVehID] = offset
        return _VehicleInteractionDetailsItem(self.__values, offset)

    def __contains__(self, uniqueVehID):
        assert type(uniqueVehID) == tuple
        return uniqueVehID in self.__offsets

    def __str__(self):
        return str(self.toDict())

    def pack(self):
        count = len(self.__uniqueVehIDs)
        flatIDs = []
        for uniqueID in self.__uniqueVehIDs:
            flatIDs.append(uniqueID[0])
            flatIDs.append(uniqueID[1])

        packed = struct.pack(('<%dI' % (2 * count)), *flatIDs) + struct.pack(('<' + VEH_INTERACTION_DETAILS_LAYOUT * count), *self.__values)
        return packed

    def toDict(self):
        return dict([ ((vehID, vehIdx), dict(_VehicleInteractionDetailsItem(self.__values, offset))) for (vehID, vehIdx), offset in self.__offsets.iteritems()
                    ])