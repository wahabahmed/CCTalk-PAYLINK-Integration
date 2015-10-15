/**
 * Created by wahab ahmed on 09/10/2015.
 * This class contains all events values, Flags and statuses
 * So you don't need to read full documentation about event codes
 */

public enum CoinMechEnum {

    // enums to allow this categorisation to be achieved
    EVENT_CODE_MASK("0x03f"),
    UNIT_TYPE_MASK("~0x03f"),
    FAULT_BIT("0x020"),
    COIN_DISPENSER_EVENT("0x040"),
    NOTE_DISPENSER_EVENT("0x080"),
    COIN_EVENT("0x0C0"),
    NOTE_EVENT("0x100"),

    // The common base codes
    EVENT_OK("EVENT_OK"), // Internal use only
    EVENT_BUSY("EVENT_OK"), // Internal use only
    REJECTED("REJECTED"),
    INHIBITED("INHIBITED"),
    MISREAD("MISREAD"),
    FRAUD("FRAUD"),
    JAM("JAM"),
    JAM_FIXED("JAM_FIXED"),
    RETURN("RETURN"),
    OUTPUT_PROBLEM("OUTPUT_PROBLEM"),
    OUTPUT_FIXED("OUTPUT_FIXED"),
    INTERNAL_PROBLEM("INTERNAL_PROBLEM"),
    UNKNOWN("UNKNOWN"),
    DISPENSE_UPDATE("DISPENSE_UPDATE"),
    // Fault codes
    NOW_OK("0"),
    REPORTED_FAULT("REPORTED_FAULT"),
    UNIT_TIMEOUT("UNIT_TIMEOUT"),
    UNIT_RESET("UNIT_RESET"),
    SELF_TEST_REFUSED("SELF_TEST_REFUSED"),

    // General IMHEI Codes
    IMHEI_NULL("0"),
    IMHEI_INTERFACE_START("1"),
    IMHEI_APPLICATION_START("2"),
    IMHEI_APPLICATION_EXIT("3"),
    IMHEI_OVERFLOW("0x1f"),

    // Coin Acceptors
    IMHEI_COIN_NOW_OK("COIN_EVENT | FAULT_BIT | NOW_OK"),
    IMHEI_COIN_UNIT_REPORTED_FAULT("COIN_EVENT | FAULT_BIT | REPORTED_FAULT"),
    IMHEI_COIN_UNIT_TIMEOUT("COIN_EVENT | FAULT_BIT | UNIT_TIMEOUT"),
    IMHEI_COIN_UNIT_RESET("COIN_EVENT | FAULT_BIT | UNIT_RESET"),
    IMHEI_COIN_SELF_TEST_REFUSED("COIN_EVENT | FAULT_BIT | SELF_TEST_REFUSED"),
    IMHEI_COIN_REJECT_COIN("COIN_EVENT | REJECTED"),
    IMHEI_COIN_INHIBITED_COIN("COIN_EVENT | INHIBITED"),
    IMHEI_COIN_FRAUD_ATTEMPT("COIN_EVENT | FRAUD"),
    IMHEI_COIN_ACCEPTOR_JAM("COIN_EVENT | JAM"),
    IMHEI_COIN_COIN_RETURN("COIN_EVENT | RETURN"),
    IMHEI_COIN_SORTER_JAM("COIN_EVENT | OUTPUT_PROBLEM"),
    IMHEI_COIN_INTERNAL_PROBLEM("COIN_EVENT | INTERNAL_PROBLEM"),
    IMHEI_COIN_UNCLASSIFIED_EVENT("COIN_EVENT | UNKNOWN"),


    //Switch Codes
    SWITCH_DOOR(7),
    SWITCH_SETTINGS_MENU(15),
    SWITCH_SKIP_TRACK(14),
    SWITCH_CREDITS(13),
    SWITCH_VOLUME_MUTE_UNMUTE(12);


    public String eventCode;
    public int switchCode;


    CoinMechEnum(String eventCode) {
        this.eventCode = eventCode;
    }

    CoinMechEnum(int switchCode) {
        this.switchCode = switchCode;
    }

    public String getEventCode() {
        return eventCode;
    }

    public void setEventCode(String eventCode) {
        this.eventCode = eventCode;
    }

    public int getSwitchCode() {
        return switchCode;
    }

    public void setSwitchCode(int switchCode) {
        this.switchCode = switchCode;
    }
}

