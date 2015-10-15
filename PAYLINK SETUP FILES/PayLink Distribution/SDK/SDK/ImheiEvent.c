char* EventDecode(int Event)
    {
    switch (Event)
        {
    case IMHEI_NULL                     : return "Null";
    case IMHEI_INTERFACE_START          : return "Interface Start";
    case IMHEI_APPLICATION_START        : return "Application Start";
    case IMHEI_APPLICATION_EXIT         : return "Application Exit";

    case IMHEI_OVERFLOW                 : return "Overflow";


    // Coin Acceptors
    case IMHEI_COIN_NOW_OK              : return "Coin: Now Ok";
    case IMHEI_COIN_UNIT_REPORTED_FAULT : return "Coin: Unit Reported Fault";
    case IMHEI_COIN_UNIT_TIMEOUT        : return "Coin: Unit Timeout";
    case IMHEI_COIN_UNIT_RESET          : return "Coin: Unit Reset";
    case IMHEI_COIN_SELF_TEST_REFUSED   : return "Coin: Self Test Refused";


    case IMHEI_COIN_REJECT_COIN         : return "Coin: Reject Coin";
    case IMHEI_COIN_INHIBITED_COIN      : return "Coin: Inhibited Coin";
    case IMHEI_COIN_FRAUD_ATTEMPT       : return "Coin: Fraud Attempt";
    case IMHEI_COIN_ACCEPTOR_JAM        : return "Coin: Acceptor Jam";
    case IMHEI_COIN_COIN_RETURN         : return "Coin: Coin Return";
    case IMHEI_COIN_SORTER_JAM          : return "Coin: Sorter Jam";
    case IMHEI_COIN_SORTER_FIXED        : return "Coin: Sorter Fixed";
    case IMHEI_COIN_INTERNAL_PROBLEM    : return "Coin: Internal Problem";
    case IMHEI_COIN_UNRECOGNISED        : return "Coin: Unrecognised Coin";
    case IMHEI_COIN_UNCLASSIFIED_EVENT  : return "Coin: Unclassified Event";



    // Note Acceptors
    case IMHEI_NOTE_NOW_OK              : return "Note: Now Ok";
    case IMHEI_NOTE_UNIT_REPORTED_FAULT : return "Note: Unit Reported Fault";
    case IMHEI_NOTE_UNIT_TIMEOUT        : return "Note: Unit Timeout";
    case IMHEI_NOTE_UNIT_RESET          : return "Note: Unit Reset";
    case IMHEI_NOTE_SELF_TEST_REFUSED   : return "Note: Self Test Refused";

    case IMHEI_NOTE_REJECT_NOTE         : return "Note: Reject Note";
    case IMHEI_NOTE_INHIBITED_NOTE      : return "Note: Inhibited Note";
    case IMHEI_NOTE_NOTE_MISREAD        : return "Note: Note Misread";
    case IMHEI_NOTE_FRAUD_ATTEMPT       : return "Note: Fraud Attempt";
    case IMHEI_NOTE_ACCEPTOR_JAM        : return "Note: Acceptor Jam";
    case IMHEI_NOTE_ACCEPTOR_JAM_FIXED  : return "Note: Acceptor Jam Fixed";
    case IMHEI_NOTE_NOTE_RETURNED       : return "Note: Note Returned";
    case IMHEI_NOTE_STACKER_PROBLEM     : return "Note: Stacker Problem";
    case IMHEI_NOTE_STACKER_FIXED       : return "Note: Stacker Fixed";
    case IMHEI_NOTE_INTERNAL_ERROR      : return "Note: Internal Error";
    case IMHEI_NOTE_UNCLASSIFIED_EVENT  : return "Note: Unclassified Event";

    // Coin Dispenser
    case IMHEI_COIN_DISPENSER_NOW_OK             : return "Hopper: Now OK" ;
    case IMHEI_COIN_DISPENSER_REPORTED_FAULT     : return "Hopper: Unit Reported Fault";
    case IMHEI_COIN_DISPENSER_TIMEOUT            : return "Hopper: Unit Timeout";
    case IMHEI_COIN_DISPENSER_RESET              : return "Hopper: Unit Reset";
    case IMHEI_COIN_DISPENSER_SELF_TEST_REFUSED  : return "Hopper: Self Test Refused";

    case IMHEI_COIN_DISPENSER_FRAUD_ATTEMPT      : return "Hopper: Fraud Attempt";
    case IMHEI_COIN_DISPENSER_UPDATE             : return "Hopper: Level Updated";

    // Note Dispenser
    case IMHEI_NOTE_DISPENSER_NOW_OK             : return "Note Disp: Now OK" ;
    case IMHEI_NOTE_DISPENSER_REPORTED_FAULT     : return "Note Disp: Unit Reported Fault";
    case IMHEI_NOTE_DISPENSER_TIMEOUT            : return "Note Disp: Unit Timeout";
    case IMHEI_NOTE_DISPENSER_RESET              : return "Note Disp: Unit Reset";
    case IMHEI_NOTE_DISPENSER_SELF_TEST_REFUSED  : return "Note Disp: Self Test Refused";

    case IMHEI_NOTE_DISPENSER_FRAUD_ATTEMPT      : return "Note Disp: Fraud Attempt";
    case IMHEI_NOTE_DISPENSER_UPDATE             : return "Note Disp: Level Updated";
    case IMHEI_NOTE_DISPENSER_REJECTED           : return "Note Disp: Note(s) not paid out" ;
    case IMHEI_NOTE_DISPENSER_PENDING            : return "Note Disp: Note(s) pending" ;
    case IMHEI_NOTE_DISPENSER_PROBLEM            : return "Note Disp: Jammed on payout" ;
    default                             : return "Unknown Message Code" ;
       }
   }
