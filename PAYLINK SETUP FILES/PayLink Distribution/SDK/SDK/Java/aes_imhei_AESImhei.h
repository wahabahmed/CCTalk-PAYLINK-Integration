/* DO NOT EDIT THIS FILE - it is machine generated */
#include <jni.h>
/* Header for class aes_imhei_AESImhei */

#ifndef _Included_aes_imhei_AESImhei
#define _Included_aes_imhei_AESImhei
#ifdef __cplusplus
extern "C" {
#endif
#undef aes_imhei_AESImhei_ORIGINAL_VERSION
#define aes_imhei_AESImhei_ORIGINAL_VERSION 65537L
#undef aes_imhei_AESImhei_DISPENSER_UPDATE
#define aes_imhei_AESImhei_DISPENSER_UPDATE 65538L
#undef aes_imhei_AESImhei_STRINGS_RETURNED
#define aes_imhei_AESImhei_STRINGS_RETURNED 65541L
#undef aes_imhei_AESImhei_BARCODE_ACCEPTOR
#define aes_imhei_AESImhei_BARCODE_ACCEPTOR 65542L
#undef aes_imhei_AESImhei_INTERFACE_VERSION
#define aes_imhei_AESImhei_INTERFACE_VERSION 65542L
#undef aes_imhei_AESImhei_SYSTEM_MASK
#define aes_imhei_AESImhei_SYSTEM_MASK -268435456L
#undef aes_imhei_AESImhei_INTERFACE_FAILED
#define aes_imhei_AESImhei_INTERFACE_FAILED -2147483648L
#undef aes_imhei_AESImhei_DISPENSER_MASK
#define aes_imhei_AESImhei_DISPENSER_MASK 268369920L
#undef aes_imhei_AESImhei_ACCEPTOR_MASK
#define aes_imhei_AESImhei_ACCEPTOR_MASK 65535L
#undef aes_imhei_AESImhei_ACCEPTOR_DEAD
#define aes_imhei_AESImhei_ACCEPTOR_DEAD 1L
#undef aes_imhei_AESImhei_ACCEPTOR_DISABLED
#define aes_imhei_AESImhei_ACCEPTOR_DISABLED 4L
#undef aes_imhei_AESImhei_ACCEPTOR_INHIBIT
#define aes_imhei_AESImhei_ACCEPTOR_INHIBIT 8L
#undef aes_imhei_AESImhei_ACCEPTOR_FRAUD
#define aes_imhei_AESImhei_ACCEPTOR_FRAUD 16L
#undef aes_imhei_AESImhei_ACCEPTOR_BUSY
#define aes_imhei_AESImhei_ACCEPTOR_BUSY 32L
#undef aes_imhei_AESImhei_ACCEPTOR_FAULT
#define aes_imhei_AESImhei_ACCEPTOR_FAULT 64L
#undef aes_imhei_AESImhei_MAX_DISPENSERS
#define aes_imhei_AESImhei_MAX_DISPENSERS 16L
#undef aes_imhei_AESImhei_DISPENSER_COIN_NONE
#define aes_imhei_AESImhei_DISPENSER_COIN_NONE 0L
#undef aes_imhei_AESImhei_DISPENSER_COIN_LOW
#define aes_imhei_AESImhei_DISPENSER_COIN_LOW 1L
#undef aes_imhei_AESImhei_DISPENSER_COIN_MID
#define aes_imhei_AESImhei_DISPENSER_COIN_MID 2L
#undef aes_imhei_AESImhei_DISPENSER_COIN_HIGH
#define aes_imhei_AESImhei_DISPENSER_COIN_HIGH 3L
#undef aes_imhei_AESImhei_DISPENSER_ACCURATE
#define aes_imhei_AESImhei_DISPENSER_ACCURATE -1L
#undef aes_imhei_AESImhei_DISPENSER_ACCURATE_FULL
#define aes_imhei_AESImhei_DISPENSER_ACCURATE_FULL -2L
#undef aes_imhei_AESImhei_DISPENSER_REASSIGN_VALUE
#define aes_imhei_AESImhei_DISPENSER_REASSIGN_VALUE 100L
#undef aes_imhei_AESImhei_DISPENSER_VALUE_REASSIGNED
#define aes_imhei_AESImhei_DISPENSER_VALUE_REASSIGNED 101L
#undef aes_imhei_AESImhei_DISPENSER_CASHBOX_DUMP
#define aes_imhei_AESImhei_DISPENSER_CASHBOX_DUMP 120L
#undef aes_imhei_AESImhei_DISPENSER_PARTIAL_DUMP
#define aes_imhei_AESImhei_DISPENSER_PARTIAL_DUMP 121L
#undef aes_imhei_AESImhei_DISPENSER_DUMP_FINISHED
#define aes_imhei_AESImhei_DISPENSER_DUMP_FINISHED 122L
#undef aes_imhei_AESImhei_DP_GENERIC_MASK
#define aes_imhei_AESImhei_DP_GENERIC_MASK -16777216L
#undef aes_imhei_AESImhei_DP_COIN_ACCEPT_DEVICE
#define aes_imhei_AESImhei_DP_COIN_ACCEPT_DEVICE 33554432L
#undef aes_imhei_AESImhei_DP_NOTE_ACCEPT_DEVICE
#define aes_imhei_AESImhei_DP_NOTE_ACCEPT_DEVICE 301989888L
#undef aes_imhei_AESImhei_DP_CARD_ACCEPT_DEVICE
#define aes_imhei_AESImhei_DP_CARD_ACCEPT_DEVICE 570425344L
#undef aes_imhei_AESImhei_DP_COIN_PAYOUT_DEVICE
#define aes_imhei_AESImhei_DP_COIN_PAYOUT_DEVICE 16777216L
#undef aes_imhei_AESImhei_DP_NOTE_PAYOUT_DEVICE
#define aes_imhei_AESImhei_DP_NOTE_PAYOUT_DEVICE 285212672L
#undef aes_imhei_AESImhei_DP_CARD_PAYOUT_DEVICE
#define aes_imhei_AESImhei_DP_CARD_PAYOUT_DEVICE 553648128L
#undef aes_imhei_AESImhei_DP_INTERFACE_MASK
#define aes_imhei_AESImhei_DP_INTERFACE_MASK 16711680L
#undef aes_imhei_AESImhei_DP_INTERFACE_UNIT
#define aes_imhei_AESImhei_DP_INTERFACE_UNIT 0L
#undef aes_imhei_AESImhei_DP_ONBOARD_PARALLEL_INTERFACE
#define aes_imhei_AESImhei_DP_ONBOARD_PARALLEL_INTERFACE 65536L
#undef aes_imhei_AESImhei_DP_CCTALK_INTERFACE
#define aes_imhei_AESImhei_DP_CCTALK_INTERFACE 131072L
#undef aes_imhei_AESImhei_DP_SSP_INTERFACE
#define aes_imhei_AESImhei_DP_SSP_INTERFACE 196608L
#undef aes_imhei_AESImhei_DP_HII_INTERFACE
#define aes_imhei_AESImhei_DP_HII_INTERFACE 262144L
#undef aes_imhei_AESImhei_DP_ARDAC_INTERFACE
#define aes_imhei_AESImhei_DP_ARDAC_INTERFACE 327680L
#undef aes_imhei_AESImhei_DP_JCM_INTERFACE
#define aes_imhei_AESImhei_DP_JCM_INTERFACE 393216L
#undef aes_imhei_AESImhei_DP_GPT_INTERFACE
#define aes_imhei_AESImhei_DP_GPT_INTERFACE 458752L
#undef aes_imhei_AESImhei_DP_MDB_INTERFACE
#define aes_imhei_AESImhei_DP_MDB_INTERFACE 524288L
#undef aes_imhei_AESImhei_DP_MDB_LEVEL_3_INTERFACE
#define aes_imhei_AESImhei_DP_MDB_LEVEL_3_INTERFACE 524288L
#undef aes_imhei_AESImhei_DP_MDB_LEVEL_2_INTERFACE
#define aes_imhei_AESImhei_DP_MDB_LEVEL_2_INTERFACE 589824L
#undef aes_imhei_AESImhei_DP_F56_INTERFACE
#define aes_imhei_AESImhei_DP_F56_INTERFACE 655360L
#undef aes_imhei_AESImhei_DP_CCNET_INTERFACE
#define aes_imhei_AESImhei_DP_CCNET_INTERFACE 720896L
#undef aes_imhei_AESImhei_DP_ID003_NOTE
#define aes_imhei_AESImhei_DP_ID003_NOTE 302383104L
#undef aes_imhei_AESImhei_DP_ID003_RECYCLER
#define aes_imhei_AESImhei_DP_ID003_RECYCLER 302383106L
#undef aes_imhei_AESImhei_DP_ID003_BOX
#define aes_imhei_AESImhei_DP_ID003_BOX 285605890L
#undef aes_imhei_AESImhei_DP_MDB_LEVEL_2
#define aes_imhei_AESImhei_DP_MDB_LEVEL_2 34144256L
#undef aes_imhei_AESImhei_DP_MDB_LEVEL_3
#define aes_imhei_AESImhei_DP_MDB_LEVEL_3 34078720L
#undef aes_imhei_AESImhei_DP_MDB_LEVEL_2_TUBE
#define aes_imhei_AESImhei_DP_MDB_LEVEL_2_TUBE 17367040L
#undef aes_imhei_AESImhei_DP_MDB_TYPE_3_PAYOUT
#define aes_imhei_AESImhei_DP_MDB_TYPE_3_PAYOUT 17301504L
#undef aes_imhei_AESImhei_DP_MDB_BILL
#define aes_imhei_AESImhei_DP_MDB_BILL 302514176L
#undef aes_imhei_AESImhei_DP_CC_GHOST_HOPPER
#define aes_imhei_AESImhei_DP_CC_GHOST_HOPPER 16908543L
#undef aes_imhei_AESImhei_DP_MANUFACTURER_MASK
#define aes_imhei_AESImhei_DP_MANUFACTURER_MASK 65280L
#undef aes_imhei_AESImhei_DP_MANU_UNKNOWN
#define aes_imhei_AESImhei_DP_MANU_UNKNOWN 0L
#undef aes_imhei_AESImhei_DP_MANU_MONEY_CONTROLS
#define aes_imhei_AESImhei_DP_MANU_MONEY_CONTROLS 256L
#undef aes_imhei_AESImhei_DP_MANU_INNOVATIVE_TECH
#define aes_imhei_AESImhei_DP_MANU_INNOVATIVE_TECH 512L
#undef aes_imhei_AESImhei_DP_MANU_MARS_ELECTRONICS
#define aes_imhei_AESImhei_DP_MANU_MARS_ELECTRONICS 768L
#undef aes_imhei_AESImhei_DP_MANU_AZKOYEN
#define aes_imhei_AESImhei_DP_MANU_AZKOYEN 1024L
#undef aes_imhei_AESImhei_DP_MANU_NRI
#define aes_imhei_AESImhei_DP_MANU_NRI 1280L
#undef aes_imhei_AESImhei_DP_MANU_ICT
#define aes_imhei_AESImhei_DP_MANU_ICT 1536L
#undef aes_imhei_AESImhei_DP_MANU_JCM
#define aes_imhei_AESImhei_DP_MANU_JCM 1792L
#undef aes_imhei_AESImhei_DP_MANU_GPT
#define aes_imhei_AESImhei_DP_MANU_GPT 2048L
#undef aes_imhei_AESImhei_DP_MANU_COINCO
#define aes_imhei_AESImhei_DP_MANU_COINCO 2304L
#undef aes_imhei_AESImhei_DP_MANU_ASAHI_SEIKO
#define aes_imhei_AESImhei_DP_MANU_ASAHI_SEIKO 2560L
#undef aes_imhei_AESImhei_DP_MANU_ASTROSYSTEMS
#define aes_imhei_AESImhei_DP_MANU_ASTROSYSTEMS 2816L
#undef aes_imhei_AESImhei_DP_MANU_MERKUR
#define aes_imhei_AESImhei_DP_MANU_MERKUR 3072L
#undef aes_imhei_AESImhei_DP_MANU_FUJITSU
#define aes_imhei_AESImhei_DP_MANU_FUJITSU 3328L
#undef aes_imhei_AESImhei_DP_MANU_CASHCODE
#define aes_imhei_AESImhei_DP_MANU_CASHCODE 3584L
#undef aes_imhei_AESImhei_DP_MANU_MFS
#define aes_imhei_AESImhei_DP_MANU_MFS 3840L
#undef aes_imhei_AESImhei_DP_SPECIFIC_DEVICE_MASK
#define aes_imhei_AESImhei_DP_SPECIFIC_DEVICE_MASK 255L
#undef aes_imhei_AESImhei_DP_MCL_SCH2
#define aes_imhei_AESImhei_DP_MCL_SCH2 16908545L
#undef aes_imhei_AESImhei_DP_MCL_SUH1
#define aes_imhei_AESImhei_DP_MCL_SUH1 16908546L
#undef aes_imhei_AESImhei_DP_MCL_SCH3A
#define aes_imhei_AESImhei_DP_MCL_SCH3A 16908547L
#undef aes_imhei_AESImhei_DP_MCL_SCH3
#define aes_imhei_AESImhei_DP_MCL_SCH3 16908548L
#undef aes_imhei_AESImhei_DP_MCL_SUH5
#define aes_imhei_AESImhei_DP_MCL_SUH5 16908549L
#undef aes_imhei_AESImhei_DP_MCL_SCH5
#define aes_imhei_AESImhei_DP_MCL_SCH5 16908550L
#undef aes_imhei_AESImhei_DP_MCL_BCR_HOPPER
#define aes_imhei_AESImhei_DP_MCL_BCR_HOPPER 16908551L
#undef aes_imhei_AESImhei_DP_MCL_CR100_HOPPER
#define aes_imhei_AESImhei_DP_MCL_CR100_HOPPER 16908552L
#undef aes_imhei_AESImhei_DP_MCL_NR2_HOPPER
#define aes_imhei_AESImhei_DP_MCL_NR2_HOPPER 16908554L
#undef aes_imhei_AESImhei_DP_MCL_SR3
#define aes_imhei_AESImhei_DP_MCL_SR3 33685762L
#undef aes_imhei_AESImhei_DP_MCL_SR5
#define aes_imhei_AESImhei_DP_MCL_SR5 33685763L
#undef aes_imhei_AESImhei_DP_MCL_CONDOR
#define aes_imhei_AESImhei_DP_MCL_CONDOR 33685766L
#undef aes_imhei_AESImhei_DP_MCL_BCR
#define aes_imhei_AESImhei_DP_MCL_BCR 33685767L
#undef aes_imhei_AESImhei_DP_MCL_CR100
#define aes_imhei_AESImhei_DP_MCL_CR100 33685768L
#undef aes_imhei_AESImhei_DP_MCL_BCS
#define aes_imhei_AESImhei_DP_MCL_BCS 33685769L
#undef aes_imhei_AESImhei_DP_MCL_NR2
#define aes_imhei_AESImhei_DP_MCL_NR2 33685770L
#undef aes_imhei_AESImhei_DP_MCL_LUMINA
#define aes_imhei_AESImhei_DP_MCL_LUMINA 302121221L
#undef aes_imhei_AESImhei_DP_MCL_7200
#define aes_imhei_AESImhei_DP_MCL_7200 302121222L
#undef aes_imhei_AESImhei_DP_MCL_ARDAC_ELITE
#define aes_imhei_AESImhei_DP_MCL_ARDAC_ELITE 302121223L
#undef aes_imhei_AESImhei_DP_MCL_WACS
#define aes_imhei_AESImhei_DP_MCL_WACS 302317825L
#undef aes_imhei_AESImhei_DP_MCL_ARDAC
#define aes_imhei_AESImhei_DP_MCL_ARDAC 302383361L
#undef aes_imhei_AESImhei_DP_COINCO_MDB
#define aes_imhei_AESImhei_DP_COINCO_MDB 34081024L
#undef aes_imhei_AESImhei_DP_COINCO_VORTEX
#define aes_imhei_AESImhei_DP_COINCO_VORTEX 34081025L
#undef aes_imhei_AESImhei_DP_COINCO_GLOBAL
#define aes_imhei_AESImhei_DP_COINCO_GLOBAL 34081026L
#undef aes_imhei_AESImhei_DP_COINCO_MDB_BILL
#define aes_imhei_AESImhei_DP_COINCO_MDB_BILL 302516480L
#undef aes_imhei_AESImhei_DP_COINCO_BILLPRO
#define aes_imhei_AESImhei_DP_COINCO_BILLPRO 302516481L
#undef aes_imhei_AESImhei_DP_AZK_HOPPER
#define aes_imhei_AESImhei_DP_AZK_HOPPER 16909312L
#undef aes_imhei_AESImhei_DP_AZK_HOPPER_U
#define aes_imhei_AESImhei_DP_AZK_HOPPER_U 16909313L
#undef aes_imhei_AESImhei_DP_AZK_HOPPER_UPL
#define aes_imhei_AESImhei_DP_AZK_HOPPER_UPL 16909314L
#undef aes_imhei_AESImhei_DP_AZK_MDB
#define aes_imhei_AESImhei_DP_AZK_MDB 34079744L
#undef aes_imhei_AESImhei_DP_AZK_A6
#define aes_imhei_AESImhei_DP_AZK_A6 33686528L
#undef aes_imhei_AESImhei_DP_MARS_CASHFLOW_126
#define aes_imhei_AESImhei_DP_MARS_CASHFLOW_126 33817345L
#undef aes_imhei_AESImhei_DP_MARS_CASHFLOW_9500
#define aes_imhei_AESImhei_DP_MARS_CASHFLOW_9500 33817346L
#undef aes_imhei_AESImhei_DP_MARS_MDB
#define aes_imhei_AESImhei_DP_MARS_MDB 34079488L
#undef aes_imhei_AESImhei_DP_MARS_CASHFLOW_690
#define aes_imhei_AESImhei_DP_MARS_CASHFLOW_690 34079489L
#undef aes_imhei_AESImhei_DP_INNOV_NV4
#define aes_imhei_AESImhei_DP_INNOV_NV4 302121476L
#undef aes_imhei_AESImhei_DP_INNOV_NV7
#define aes_imhei_AESImhei_DP_INNOV_NV7 302121479L
#undef aes_imhei_AESImhei_DP_INNOV_NV8
#define aes_imhei_AESImhei_DP_INNOV_NV8 302121480L
#undef aes_imhei_AESImhei_DP_INNOV_NV9
#define aes_imhei_AESImhei_DP_INNOV_NV9 302121481L
#undef aes_imhei_AESImhei_DP_INNOV_NV10
#define aes_imhei_AESImhei_DP_INNOV_NV10 302121482L
#undef aes_imhei_AESImhei_DP_INNOV_NV200
#define aes_imhei_AESImhei_DP_INNOV_NV200 302121483L
#undef aes_imhei_AESImhei_DP_SHOPPER_ACCEPT
#define aes_imhei_AESImhei_DP_SHOPPER_ACCEPT 33686028L
#undef aes_imhei_AESImhei_DP_INNOV_NV200_NOTE
#define aes_imhei_AESImhei_DP_INNOV_NV200_NOTE 285344257L
#undef aes_imhei_AESImhei_DP_INNOV_NV11
#define aes_imhei_AESImhei_DP_INNOV_NV11 302121474L
#undef aes_imhei_AESImhei_DP_INNOV_NV11_RC
#define aes_imhei_AESImhei_DP_INNOV_NV11_RC 285344258L
#undef aes_imhei_AESImhei_DP_SHOPPER_TOTAL
#define aes_imhei_AESImhei_DP_SHOPPER_TOTAL 16908803L
#undef aes_imhei_AESImhei_DP_SHOPPER
#define aes_imhei_AESImhei_DP_SHOPPER 16908804L
#undef aes_imhei_AESImhei_DP_NRI_G40
#define aes_imhei_AESImhei_DP_NRI_G40 33686785L
#undef aes_imhei_AESImhei_DP_NRI_PELICANO
#define aes_imhei_AESImhei_DP_NRI_PELICANO 33686786L
#undef aes_imhei_AESImhei_DP_NRI_CURRENZA_H2
#define aes_imhei_AESImhei_DP_NRI_CURRENZA_H2 16909569L
#undef aes_imhei_AESImhei_DP_ICT_U85
#define aes_imhei_AESImhei_DP_ICT_U85 302122497L
#undef aes_imhei_AESImhei_DP_AST_GBA
#define aes_imhei_AESImhei_DP_AST_GBA 302123777L
#undef aes_imhei_AESImhei_DP_JCM_CC_EBA
#define aes_imhei_AESImhei_DP_JCM_CC_EBA 302122752L
#undef aes_imhei_AESImhei_DP_JCM_CC_WBA
#define aes_imhei_AESImhei_DP_JCM_CC_WBA 302122753L
#undef aes_imhei_AESImhei_DP_JCM_VEGA
#define aes_imhei_AESImhei_DP_JCM_VEGA 302122754L
#undef aes_imhei_AESImhei_DP_JCM_VEGA_RC
#define aes_imhei_AESImhei_DP_JCM_VEGA_RC 285345538L
#undef aes_imhei_AESImhei_DP_JCM_NOTE
#define aes_imhei_AESImhei_DP_JCM_NOTE 302384896L
#undef aes_imhei_AESImhei_DP_GPT_NOTE
#define aes_imhei_AESImhei_DP_GPT_NOTE 302450688L
#undef aes_imhei_AESImhei_DP_AS_WH2
#define aes_imhei_AESImhei_DP_AS_WH2 16910848L
#undef aes_imhei_AESImhei_DP_MERKUR_100
#define aes_imhei_AESImhei_DP_MERKUR_100 302124033L
#undef aes_imhei_AESImhei_DP_MERKUR_100_PAY
#define aes_imhei_AESImhei_DP_MERKUR_100_PAY 285346817L
#undef aes_imhei_AESImhei_DP_FUJITSU_F56
#define aes_imhei_AESImhei_DP_FUJITSU_F56 285871366L
#undef aes_imhei_AESImhei_DP_FUJITSU_F53
#define aes_imhei_AESImhei_DP_FUJITSU_F53 285871363L
#undef aes_imhei_AESImhei_DP_FUJITSU_F400
#define aes_imhei_AESImhei_DP_FUJITSU_F400 285871364L
#undef aes_imhei_AESImhei_DP_CDM_4000
#define aes_imhei_AESImhei_DP_CDM_4000 285871873L
#undef aes_imhei_AESImhei_DP_CC_RECYCLER
#define aes_imhei_AESImhei_DP_CC_RECYCLER 302714369L
#undef aes_imhei_AESImhei_DP_CC_ACCEPTOR
#define aes_imhei_AESImhei_DP_CC_ACCEPTOR 302714370L
#undef aes_imhei_AESImhei_DP_CC_CASSETTE
#define aes_imhei_AESImhei_DP_CC_CASSETTE 285937153L
#undef aes_imhei_AESImhei_PAY_ONGOING
#define aes_imhei_AESImhei_PAY_ONGOING 0L
#undef aes_imhei_AESImhei_PAY_FINISHED
#define aes_imhei_AESImhei_PAY_FINISHED 1L
#undef aes_imhei_AESImhei_PAY_EMPTY
#define aes_imhei_AESImhei_PAY_EMPTY -1L
#undef aes_imhei_AESImhei_PAY_JAMMED
#define aes_imhei_AESImhei_PAY_JAMMED -2L
#undef aes_imhei_AESImhei_PAY_US
#define aes_imhei_AESImhei_PAY_US -3L
#undef aes_imhei_AESImhei_PAY_FRAUD
#define aes_imhei_AESImhei_PAY_FRAUD -4L
#undef aes_imhei_AESImhei_PAY_FAILED_BLOCKED
#define aes_imhei_AESImhei_PAY_FAILED_BLOCKED -5L
#undef aes_imhei_AESImhei_PAY_NO_HOPPER
#define aes_imhei_AESImhei_PAY_NO_HOPPER -6L
#undef aes_imhei_AESImhei_PAY_INHIBITED
#define aes_imhei_AESImhei_PAY_INHIBITED -7L
#undef aes_imhei_AESImhei_PAY_SECURITY_FAIL
#define aes_imhei_AESImhei_PAY_SECURITY_FAIL -8L
#undef aes_imhei_AESImhei_PAY_HOPPER_RESET
#define aes_imhei_AESImhei_PAY_HOPPER_RESET -9L
#undef aes_imhei_AESImhei_PAY_NOT_EXACT
#define aes_imhei_AESImhei_PAY_NOT_EXACT -10L
#undef aes_imhei_AESImhei_PAY_GHOST
#define aes_imhei_AESImhei_PAY_GHOST -11L
#undef aes_imhei_AESImhei_PAY_NO_KEY
#define aes_imhei_AESImhei_PAY_NO_KEY -12L
#undef aes_imhei_AESImhei_DES_UNLOCKED
#define aes_imhei_AESImhei_DES_UNLOCKED 0L
#undef aes_imhei_AESImhei_DES_MATCH
#define aes_imhei_AESImhei_DES_MATCH 1L
#undef aes_imhei_AESImhei_DES_NOT
#define aes_imhei_AESImhei_DES_NOT -1L
#undef aes_imhei_AESImhei_DES_WRONG
#define aes_imhei_AESImhei_DES_WRONG -2L
#undef aes_imhei_AESImhei_DES_CHECKING
#define aes_imhei_AESImhei_DES_CHECKING -3L
#undef aes_imhei_AESImhei_DES_APPLYING
#define aes_imhei_AESImhei_DES_APPLYING -4L
#undef aes_imhei_AESImhei_PRINTER_NONE
#define aes_imhei_AESImhei_PRINTER_NONE 0L
#undef aes_imhei_AESImhei_PRINTER_FAULT
#define aes_imhei_AESImhei_PRINTER_FAULT -2147483648L
#undef aes_imhei_AESImhei_PRINTER_IDLE
#define aes_imhei_AESImhei_PRINTER_IDLE 1L
#undef aes_imhei_AESImhei_PRINTER_BUSY
#define aes_imhei_AESImhei_PRINTER_BUSY 2L
#undef aes_imhei_AESImhei_PRINTER_PLATEN_UP
#define aes_imhei_AESImhei_PRINTER_PLATEN_UP 4L
#undef aes_imhei_AESImhei_PRINTER_PAPER_OUT
#define aes_imhei_AESImhei_PRINTER_PAPER_OUT 8L
#undef aes_imhei_AESImhei_PRINTER_HEAD_FAULT
#define aes_imhei_AESImhei_PRINTER_HEAD_FAULT 16L
#undef aes_imhei_AESImhei_PRINTER_VOLT_FAULT
#define aes_imhei_AESImhei_PRINTER_VOLT_FAULT 64L
#undef aes_imhei_AESImhei_PRINTER_TEMP_FAULT
#define aes_imhei_AESImhei_PRINTER_TEMP_FAULT 128L
#undef aes_imhei_AESImhei_PRINTER_INTERNAL_ERROR
#define aes_imhei_AESImhei_PRINTER_INTERNAL_ERROR 256L
#undef aes_imhei_AESImhei_PRINTER_PAPER_IN_CHUTE
#define aes_imhei_AESImhei_PRINTER_PAPER_IN_CHUTE 512L
#undef aes_imhei_AESImhei_PRINTER_OFFLINE
#define aes_imhei_AESImhei_PRINTER_OFFLINE 1024L
#undef aes_imhei_AESImhei_PRINTER_MISSING_SUPPY_INDEX
#define aes_imhei_AESImhei_PRINTER_MISSING_SUPPY_INDEX 2048L
#undef aes_imhei_AESImhei_PRINTER_CUTTER_FAULT
#define aes_imhei_AESImhei_PRINTER_CUTTER_FAULT 4096L
#undef aes_imhei_AESImhei_PRINTER_PAPER_JAM
#define aes_imhei_AESImhei_PRINTER_PAPER_JAM 8192L
#undef aes_imhei_AESImhei_PRINTER_PAPER_LOW
#define aes_imhei_AESImhei_PRINTER_PAPER_LOW 16384L
#undef aes_imhei_AESImhei_PRINTER_OPEN
#define aes_imhei_AESImhei_PRINTER_OPEN 32768L
#undef aes_imhei_AESImhei_PRINTER_TOP_OF_FORM
#define aes_imhei_AESImhei_PRINTER_TOP_OF_FORM 65536L
#undef aes_imhei_AESImhei_PRINTER_BARCODE_DONE
#define aes_imhei_AESImhei_PRINTER_BARCODE_DONE 131072L
#undef aes_imhei_AESImhei_PRINTER_JUST_RESET
#define aes_imhei_AESImhei_PRINTER_JUST_RESET 262144L
#undef aes_imhei_AESImhei_INTERFACE_NO_DATA
#define aes_imhei_AESImhei_INTERFACE_NO_DATA -5L
#undef aes_imhei_AESImhei_INTERFACE_TOO_LONG
#define aes_imhei_AESImhei_INTERFACE_TOO_LONG -4L
#undef aes_imhei_AESImhei_INTERFACE_NON_EXIST
#define aes_imhei_AESImhei_INTERFACE_NON_EXIST -3L
#undef aes_imhei_AESImhei_INTERFACE_OVERFLOW
#define aes_imhei_AESImhei_INTERFACE_OVERFLOW -2L
#undef aes_imhei_AESImhei_INTERFACE_TIMEOUT
#define aes_imhei_AESImhei_INTERFACE_TIMEOUT -1L
#undef aes_imhei_AESImhei_INTERFACE_BUSY
#define aes_imhei_AESImhei_INTERFACE_BUSY 0L
#undef aes_imhei_AESImhei_METER_OK
#define aes_imhei_AESImhei_METER_OK 0L
#undef aes_imhei_AESImhei_METER_MISSING
#define aes_imhei_AESImhei_METER_MISSING 1L
#undef aes_imhei_AESImhei_METER_DIED
#define aes_imhei_AESImhei_METER_DIED 2L
#undef aes_imhei_AESImhei_METER_FAILED
#define aes_imhei_AESImhei_METER_FAILED 3L
#undef aes_imhei_AESImhei_MAX_ESCROW
#define aes_imhei_AESImhei_MAX_ESCROW 64L
#undef aes_imhei_AESImhei_ESCROW_CURRENT_VERSION
#define aes_imhei_AESImhei_ESCROW_CURRENT_VERSION 0L
#undef aes_imhei_AESImhei_ESCROW_NOTE_HELD
#define aes_imhei_AESImhei_ESCROW_NOTE_HELD 0L
#undef aes_imhei_AESImhei_ESCROW_NOTE_STACKED
#define aes_imhei_AESImhei_ESCROW_NOTE_STACKED 1L
#undef aes_imhei_AESImhei_ESCROW_NOTE_RETURNED
#define aes_imhei_AESImhei_ESCROW_NOTE_RETURNED 2L
#undef aes_imhei_AESImhei_ESCROW_NOTE_PROBLEM
#define aes_imhei_AESImhei_ESCROW_NOTE_PROBLEM 3L
#undef aes_imhei_AESImhei_EXT_ESCROW_NONE
#define aes_imhei_AESImhei_EXT_ESCROW_NONE 0L
#undef aes_imhei_AESImhei_EXT_ESCROW_OFF
#define aes_imhei_AESImhei_EXT_ESCROW_OFF 1L
#undef aes_imhei_AESImhei_EXT_ESCROW_IDLE
#define aes_imhei_AESImhei_EXT_ESCROW_IDLE 2L
#undef aes_imhei_AESImhei_EXT_ESCROW_WAITING
#define aes_imhei_AESImhei_EXT_ESCROW_WAITING 3L
#undef aes_imhei_AESImhei_EXT_ESCROW_LOADING
#define aes_imhei_AESImhei_EXT_ESCROW_LOADING 4L
#undef aes_imhei_AESImhei_EXT_ESCROW_STORED
#define aes_imhei_AESImhei_EXT_ESCROW_STORED 5L
#undef aes_imhei_AESImhei_EXT_ESCROW_PAUSED
#define aes_imhei_AESImhei_EXT_ESCROW_PAUSED 6L
#undef aes_imhei_AESImhei_EXT_ESCROW_STACKING
#define aes_imhei_AESImhei_EXT_ESCROW_STACKING 7L
#undef aes_imhei_AESImhei_EXT_ESCROW_RETURNING
#define aes_imhei_AESImhei_EXT_ESCROW_RETURNING 8L
#undef aes_imhei_AESImhei_EXT_ESCROW_RETURNED_OK
#define aes_imhei_AESImhei_EXT_ESCROW_RETURNED_OK 9L
#undef aes_imhei_AESImhei_EXT_ESCROW_RETURNING_PROBLEM
#define aes_imhei_AESImhei_EXT_ESCROW_RETURNING_PROBLEM 10L
#undef aes_imhei_AESImhei_EXT_ESCROW_STACKED_OK
#define aes_imhei_AESImhei_EXT_ESCROW_STACKED_OK 11L
#undef aes_imhei_AESImhei_EXT_ESCROW_STACKING_PROBLEM
#define aes_imhei_AESImhei_EXT_ESCROW_STACKING_PROBLEM 12L
#undef aes_imhei_AESImhei_EXT_ESCROW_FULL
#define aes_imhei_AESImhei_EXT_ESCROW_FULL 13L
#undef aes_imhei_AESImhei_EXT_ESCROW_POWER_ACTIVE
#define aes_imhei_AESImhei_EXT_ESCROW_POWER_ACTIVE 14L
#undef aes_imhei_AESImhei_EXT_ESCROW_COMPLETE
#define aes_imhei_AESImhei_EXT_ESCROW_COMPLETE 0L
#undef aes_imhei_AESImhei_EXT_ESCROW_BUSY
#define aes_imhei_AESImhei_EXT_ESCROW_BUSY 1L
#undef aes_imhei_AESImhei_EXT_ESCROW_WRONGSTATE
#define aes_imhei_AESImhei_EXT_ESCROW_WRONGSTATE 2L
#undef aes_imhei_AESImhei_EXT_ESCROW_ERROR
#define aes_imhei_AESImhei_EXT_ESCROW_ERROR 3L
#undef aes_imhei_AESImhei_EXT_ESCROW_START
#define aes_imhei_AESImhei_EXT_ESCROW_START 0L
#undef aes_imhei_AESImhei_EXT_ESCROW_STOP
#define aes_imhei_AESImhei_EXT_ESCROW_STOP 1L
#undef aes_imhei_AESImhei_EXT_ESCROW_ACCEPT
#define aes_imhei_AESImhei_EXT_ESCROW_ACCEPT 2L
#undef aes_imhei_AESImhei_EXT_ESCROW_PAUSE
#define aes_imhei_AESImhei_EXT_ESCROW_PAUSE 3L
#undef aes_imhei_AESImhei_EXT_ESCROW_STACK
#define aes_imhei_AESImhei_EXT_ESCROW_STACK 4L
#undef aes_imhei_AESImhei_EXT_ESCROW_RETURN
#define aes_imhei_AESImhei_EXT_ESCROW_RETURN 5L
#undef aes_imhei_AESImhei_NOT_USB
#define aes_imhei_AESImhei_NOT_USB -1L
#undef aes_imhei_AESImhei_USB_IDLE
#define aes_imhei_AESImhei_USB_IDLE 0L
#undef aes_imhei_AESImhei_STANDARD_DRIVER
#define aes_imhei_AESImhei_STANDARD_DRIVER 1L
#undef aes_imhei_AESImhei_FLASH_LOADER
#define aes_imhei_AESImhei_FLASH_LOADER 2L
#undef aes_imhei_AESImhei_MANUFACTURING_TEST
#define aes_imhei_AESImhei_MANUFACTURING_TEST 3L
#undef aes_imhei_AESImhei_DRIVER_RESTART
#define aes_imhei_AESImhei_DRIVER_RESTART 4L
#undef aes_imhei_AESImhei_USB_ERROR
#define aes_imhei_AESImhei_USB_ERROR 5L
#undef aes_imhei_AESImhei_DRIVER_EXIT
#define aes_imhei_AESImhei_DRIVER_EXIT 6L
/*
 * Class:     aes_imhei_AESImhei
 * Method:    OpenMHEVersion
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_OpenMHEVersion
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    OpenSpecificMHEVersion
 * Signature: (Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_OpenSpecificMHEVersion
  (JNIEnv *, jclass, jstring, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EnableInterface
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EnableInterface
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DisableInterface
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DisableInterface
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentValue
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentValue
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    PayOut
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_PayOut
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    LastPayStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_LastPayStatus
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SetDispenseQuantity
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SetDispenseQuantity
  (JNIEnv *, jclass, jint, jint, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    PaySpecific
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_PaySpecific
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    IndicatorOn
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_IndicatorOn
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    IndicatorOff
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_IndicatorOff
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SwitchOpens
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SwitchOpens
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SwitchCloses
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SwitchCloses
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentPaid
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentPaid
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CheckOperation
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CheckOperation
  (JNIEnv *, jclass, jint, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentUpdates
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentUpdates
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESSetKey
 * Signature: ([B)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESSetKey
  (JNIEnv *, jclass, jbyteArray);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESLockSet
 * Signature: ([B)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESLockSet
  (JNIEnv *, jclass, jbyteArray);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESLockClear
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESLockClear
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_DESStatus
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextEvent
 * Signature: (Laes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextEvent
  (JNIEnv *, jclass, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextAcceptorEvent
 * Signature: (ILaes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextAcceptorEvent
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextDispenserEvent
 * Signature: (ILaes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextDispenserEvent
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextSystemEvent
 * Signature: (Laes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextSystemEvent
  (JNIEnv *, jclass, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    AvailableValue
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_AvailableValue
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ValueNeeded
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_ValueNeeded
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SerialNumber
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SerialNumber
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowEnable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowEnable
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowDisable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowDisable
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowThroughput
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_EscrowThroughput
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowAccept
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowAccept
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowReturn
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowReturn
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeEnable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeEnable
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeDisable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeDisable
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeInEscrow
 * Signature: ([Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeInEscrow
  (JNIEnv *, jclass, jobjectArray);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeInEscrowExt
 * Signature: ([Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeInEscrowExt
  (JNIEnv *, jclass, jobjectArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeStacked
 * Signature: ([Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeStacked
  (JNIEnv *, jclass, jobjectArray);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeStackedExt
 * Signature: ([Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeStackedExt
  (JNIEnv *, jclass, jobjectArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeAccept
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeAccept
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeReturn
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeReturn
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodePrint
 * Signature: (Laes/imhei/AESImhei/TicketDescription;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodePrint
  (JNIEnv *, jclass, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodePrintStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodePrintStatus
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadAcceptorDetails
 * Signature: (ILaes/imhei/AESImhei/AcceptorBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadAcceptorDetails
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteAcceptorDetails
 * Signature: (ILaes/imhei/AESImhei/AcceptorBlock;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteAcceptorDetails
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadDispenserDetails
 * Signature: (ILaes/imhei/AESImhei/DispenserBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadDispenserDetails
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteDispenserDetails
 * Signature: (ILaes/imhei/AESImhei/DispenserBlock;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteDispenserDetails
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteInterfaceBlock
 * Signature: (I[BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteInterfaceBlock
  (JNIEnv *, jclass, jint, jbyteArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadInterfaceBlock
 * Signature: (I[BI)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_ReadInterfaceBlock
  (JNIEnv *, jclass, jint, jbyteArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterIncrement
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterIncrement
  (JNIEnv *, jclass, jint, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterCaption
 * Signature: (ILjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterCaption
  (JNIEnv *, jclass, jint, jstring);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterRead
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CounterRead
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadCounterCaption
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_aes_imhei_AESImhei_ReadCounterCaption
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterDisplay
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterDisplay
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    MeterStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_MeterStatus
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    MeterSerialNo
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_MeterSerialNo
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromReset
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromReset
  (JNIEnv *, jclass, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromWrite
 * Signature: ([BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromWrite
  (JNIEnv *, jclass, jbyteArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromRead
 * Signature: ([BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromRead
  (JNIEnv *, jclass, jbyteArray, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadEscrowBlock
 * Signature: (ILaes/imhei/AESImhei/EscrowControlBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadEscrowBlock
  (JNIEnv *, jclass, jint, jobject);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowCommand
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowCommand
  (JNIEnv *, jclass, jint, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SetDeviceKey
 * Signature: (III)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_SetDeviceKey
  (JNIEnv *, jclass, jint, jint, jint);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    USBDriverStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_USBDriverStatus
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    USBDriverExit
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_USBDriverExit
  (JNIEnv *, jclass);

/*
 * Class:     aes_imhei_AESImhei
 * Method:    FirmwareVersion
 * Signature: ([Ljava/lang/String;[Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_FirmwareVersion
  (JNIEnv *, jclass, jobjectArray, jobjectArray);

#ifdef __cplusplus
}
#endif
#endif
