#include "aes_imhei_AESImhei.h"
#include "Aesimhei.h"


/*
 * Class:     aes_imhei_AESImhei
 * Method:    OpenMHEVersion
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_OpenMHEVersion
  (JNIEnv* env, jclass obj, jint Version)
    {
    if (Version != INTERFACE_VERSION)
        {
        return 13 ;       // ERROR_INVALID_DATA
        }
    else
        {
        return OpenMHEVersion(Version) ;
        }
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    OpenSpecificMHEVersion
 * Signature: (Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_OpenSpecificMHEVersion
  (JNIEnv* env, jclass obj, jstring JavaString, jint Version)
    {
    if (Version != INTERFACE_VERSION)
        {
        return 13 ;       // ERROR_INVALID_DATA
        }
    else
        {
        char* input = (char*)env->GetStringUTFChars(JavaString, 0) ;
        jint RetValue = OpenSpecificMHEVersion(input, Version) ;
        env->ReleaseStringUTFChars(JavaString, input) ;
        return RetValue ;
        }
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EnableInterface
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EnableInterface
  (JNIEnv* env, jclass obj)
    {
    EnableInterface() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DisableInterface
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DisableInterface
  (JNIEnv* env, jclass obj)
    {
    DisableInterface() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentValue
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentValue
  (JNIEnv* env, jclass obj)
    {
    return CurrentValue() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    PayOut
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_PayOut
  (JNIEnv* env, jclass obj, jint Amount)
    {
    PayOut(Amount) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    LastPayStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_LastPayStatus
  (JNIEnv* env, jclass obj)
    {
    return LastPayStatus() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SetDispenseQuantity
 * Signature: (III)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SetDispenseQuantity
  (JNIEnv* env, jclass obj, jint Index, jint Quantity, jint Value)
    {
    return SetDispenseQuantity(Index, Quantity, Value) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    PaySpecific
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_PaySpecific
  (JNIEnv* env, jclass obj)
    {
    return PaySpecific() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    IndicatorOn
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_IndicatorOn
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    IndicatorOn(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    IndicatorOff
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_IndicatorOff
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    IndicatorOff(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SwitchOpens
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SwitchOpens
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    return SwitchOpens(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SwitchCloses
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SwitchCloses
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    return SwitchCloses(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentPaid
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentPaid
  (JNIEnv* env, jclass obj)
    {
    return CurrentPaid() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CheckOperation
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CheckOperation
  (JNIEnv* env, jclass obj, jint  Sequence, jint  Timeout)
    {
    return CheckOperation(Sequence, Timeout) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CurrentUpdates
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CurrentUpdates
  (JNIEnv* env, jclass obj)
    {
    return CurrentUpdates() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESSetKey
 * Signature: ([B)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESSetKey
  (JNIEnv* env, jclass obj, jbyteArray JavaArray)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    DESSetKey((char*)Data) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESLockSet
 * Signature: ([B)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESLockSet
  (JNIEnv* env, jclass obj, jbyteArray JavaArray)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    DESLockSet((char*)Data) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESLockClear
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_DESLockClear
  (JNIEnv* env, jclass obj)
    {
    DESLockClear() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    DESStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_DESStatus
  (JNIEnv* env, jclass obj)
    {
    return DESStatus() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextEvent
 * Signature: (Laes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextEvent
  (JNIEnv* env, jclass obj, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    EventDetailBlock EventDetail ;
    jint RetValue = NextEvent(&EventDetail) ;

    // and copy it into the java class
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EventCode", "I"),      EventDetail.EventCode);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "RawEvent", "I"),       EventDetail.RawEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "DispenserEvent", "I"), EventDetail.DispenserEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Index", "I"),          EventDetail.Index);

    return RetValue ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextAcceptorEvent
 * Signature: (ILaes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextAcceptorEvent
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    EventDetailBlock EventDetail ;
    jint RetValue = NextAcceptorEvent(JavaInt, &EventDetail) ;

    // and copy it into the java class
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EventCode", "I"),      EventDetail.EventCode);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "RawEvent", "I"),       EventDetail.RawEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "DispenserEvent", "I"), EventDetail.DispenserEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Index", "I"),          EventDetail.Index);

    return RetValue ;
    }



/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextDispenserEvent
 * Signature: (ILaes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextDispenserEvent
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    EventDetailBlock EventDetail ;
    jint RetValue = NextDispenserEvent(JavaInt, &EventDetail) ;

    // and copy it into the java class
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EventCode", "I"),      EventDetail.EventCode);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "RawEvent", "I"),       EventDetail.RawEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "DispenserEvent", "I"), EventDetail.DispenserEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Index", "I"),          EventDetail.Index);

    return RetValue ;
    }



/*
 * Class:     aes_imhei_AESImhei
 * Method:    NextSystemEvent
 * Signature: (Laes/imhei/AESImhei/EventDetailBlock;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_NextSystemEvent
  (JNIEnv* env, jclass obj, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    EventDetailBlock EventDetail ;
    jint RetValue = NextSystemEvent(&EventDetail) ;

    // and copy it into the java class
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EventCode", "I"),      EventDetail.EventCode);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "RawEvent", "I"),       EventDetail.RawEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "DispenserEvent", "I"), EventDetail.DispenserEvent);
    env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Index", "I"),          EventDetail.Index);

    return RetValue ;
    }



/*
 * Class:     aes_imhei_AESImhei
 * Method:    AvailableValue
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_AvailableValue
  (JNIEnv* env, jclass obj)
    {
    return AvailableValue() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ValueNeeded
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_ValueNeeded
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    ValueNeeded(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SerialNumber
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_SerialNumber
  (JNIEnv* env, jclass obj)
    {
    return SerialNumber() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowEnable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowEnable
  (JNIEnv* env, jclass obj)
    {
    EscrowEnable() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowDisable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowDisable
  (JNIEnv* env, jclass obj)
    {
    EscrowDisable() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowThroughput
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_EscrowThroughput
  (JNIEnv* env, jclass obj)
    {
    return EscrowThroughput() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowAccept
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowAccept
  (JNIEnv* env, jclass obj)
    {
    return EscrowAccept() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowReturn
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowReturn
  (JNIEnv* env, jclass obj)
    {
    EscrowReturn() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeEnable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeEnable
  (JNIEnv* env, jclass obj)
    {
    BarcodeEnable() ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeDisable
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeDisable
  (JNIEnv* env, jclass obj)
    {
    BarcodeDisable() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeInEscrow
 * Signature: ([Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeInEscrow
  (JNIEnv* env, jclass obj, jobjectArray JavaString)
    {
    char TheBarcode[20] ;

    jint RetValue = BarcodeInEscrow(TheBarcode) ;
    env->SetObjectArrayElement(
            JavaString,0,env->NewStringUTF(TheBarcode));

    return RetValue ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeInEscrowExt
 * Signature: ([Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeInEscrowExt
  (JNIEnv* env, jclass obj, jobjectArray JavaString, jint JavaInt)
    {
    char* TheBarcode = new char[JavaInt] ;

    jint RetValue = BarcodeInEscrowExt(TheBarcode, JavaInt) ;
    env->SetObjectArrayElement(
            JavaString,0,env->NewStringUTF(TheBarcode));
    delete TheBarcode ;

    return RetValue ;
    }


/*
 * Class:     AESImhei
 * Method:    BarcodeStacked
 * Signature: (Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeStacked
  (JNIEnv* env, jclass obj, jobjectArray JavaString)
    {
    char TheBarcode[20] ;

    jint RetValue = BarcodeStacked(TheBarcode) ;
    env->SetObjectArrayElement(JavaString,0,env->NewStringUTF(TheBarcode));

    return RetValue ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeStackedExt
 * Signature: ([Ljava/lang/String;I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodeStackedExt
  (JNIEnv* env, jclass obj, jobjectArray JavaString, jint JavaInt)
    {
    char* TheBarcode = new char[JavaInt] ;

    jint RetValue = BarcodeStackedExt(TheBarcode, JavaInt) ;
    env->SetObjectArrayElement(JavaString,0,env->NewStringUTF(TheBarcode));
    delete TheBarcode ;

    return RetValue ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeAccept
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeAccept
  (JNIEnv* env, jclass obj)
    {
    BarcodeAccept() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodeReturn
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodeReturn
  (JNIEnv* env, jclass obj)
    {
    BarcodeReturn() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodePrint
 * Signature: (Laes/imhei/AESImhei/TicketDescription;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_BarcodePrint
  (JNIEnv* env, jclass obj, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    jstring BarcodeData     = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "BarcodeData", "Ljava/lang/String;")) ;
    jstring AmountInWords   = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "AmountInWords", "Ljava/lang/String;")) ;
    jstring AmountAsNumber  = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "AmountAsNumber", "Ljava/lang/String;")) ;
    jstring MachineIdentity = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "MachineIdentity", "Ljava/lang/String;")) ;
    jstring DatePrinted     = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "DatePrinted", "Ljava/lang/String;")) ;
    jstring TimePrinted     = (jstring)env->GetObjectField(JavaObject,
                                      env->GetFieldID(Javaclass, "TimePrinted", "Ljava/lang/String;")) ;

    TicketDescription Ticket ;

    Ticket.TicketType       = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "TicketType", "I")) ;

    Ticket.BarcodeData      = (char*)env->GetStringUTFChars(BarcodeData, 0) ;
    Ticket.AmountInWords    = (char*)env->GetStringUTFChars(AmountInWords, 0) ;
    Ticket.AmountAsNumber   = (char*)env->GetStringUTFChars(AmountAsNumber, 0) ;
    Ticket.MachineIdentity  = (char*)env->GetStringUTFChars(MachineIdentity, 0) ;
    Ticket.DatePrinted      = (char*)env->GetStringUTFChars(DatePrinted, 0) ;
    Ticket.TimePrinted      = (char*)env->GetStringUTFChars(TimePrinted, 0) ;

    BarcodePrint(&Ticket) ;

    env->ReleaseStringUTFChars(BarcodeData,     Ticket.BarcodeData) ;
    env->ReleaseStringUTFChars(AmountInWords,   Ticket.AmountInWords) ;
    env->ReleaseStringUTFChars(AmountAsNumber,  Ticket.AmountAsNumber) ;
    env->ReleaseStringUTFChars(MachineIdentity, Ticket.MachineIdentity) ;
    env->ReleaseStringUTFChars(DatePrinted,     Ticket.DatePrinted) ;
    env->ReleaseStringUTFChars(TimePrinted,     Ticket.TimePrinted) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    BarcodePrintStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_BarcodePrintStatus
  (JNIEnv* env, jclass obj)
    {
    return BarcodePrintStatus() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadAcceptorDetails
 * Signature: (ILaes/imhei/AESImhei/AcceptorBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadAcceptorDetails
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    AcceptorBlock TheAcceptor ;
    jboolean RetValue = ReadAcceptorDetails(JavaInt, &TheAcceptor) ;

    if (RetValue)
        {
        // and copy it into the java class
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Unit", "I"),              TheAcceptor.Unit);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Status", "I"),            TheAcceptor.Status);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "NoOfCoins", "I"),         TheAcceptor.NoOfCoins);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "InterfaceNumber", "I"),   TheAcceptor.InterfaceNumber);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "UnitAddress", "I"),       TheAcceptor.UnitAddress);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "DefaultPath", "I"),       TheAcceptor.DefaultPath);
        env->SetObjectField(JavaObject, env->GetFieldID(Javaclass, "Currency", "Ljava/lang/String;"),
                                                                         env->NewStringUTF(TheAcceptor.Currency));
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "SerialNumber", "I"),      TheAcceptor.SerialNumber);


        env->SetObjectField(JavaObject, env->GetFieldID(Javaclass, "Description", "Ljava/lang/String;"),
                                                                       env->NewStringUTF(TheAcceptor.Description));
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "BarcodesStacked", "I"),   TheAcceptor.BarcodesStacked);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EscrowBarcodeHere", "I"), TheAcceptor.EscrowBarcodeHere);
        jobjectArray JavaArray = static_cast<jobjectArray>
                        (env->GetObjectField(JavaObject, env->GetFieldID(Javaclass, "Coin", "[Laes/imhei/AESImhei$AcceptorCoin;")));

        jclass  CoinClass = env->GetObjectClass(env->GetObjectArrayElement(JavaArray, 0)) ;
        for (int No = 0 ; No < MAX_ACCEPTOR_COINS ; ++No)
            {
            jobject JavaCoin = env->GetObjectArrayElement(JavaArray, No) ;
            if (No < TheAcceptor.NoOfCoins)
                {
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "Value", "I"),           TheAcceptor.Coin[No].Value);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "Inhibit", "I"),         TheAcceptor.Coin[No].Inhibit);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "Count", "I"),           TheAcceptor.Coin[No].Count);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "Path", "I"),            TheAcceptor.Coin[No].Path);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "PathCount", "I"),       TheAcceptor.Coin[No].PathCount);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "DefaultPath", "B"),     TheAcceptor.Coin[No].DefaultPath);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "PathSwitchLevel", "I"), TheAcceptor.Coin[No].PathSwitchLevel);

                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "FutureExpansion", "B"), TheAcceptor.Coin[No].FutureExpansion);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "FutureExpansion2", "B"),TheAcceptor.Coin[No].FutureExpansion2);
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "HeldInEscrow", "B"),    TheAcceptor.Coin[No].HeldInEscrow);

                env->SetObjectField(JavaCoin, env->GetFieldID(CoinClass, "CoinName", "Ljava/lang/String;"),
                                                                             env->NewStringUTF(TheAcceptor.Coin[No].CoinName));
                }
            else
                {
                env->SetIntField(JavaCoin, env->GetFieldID(CoinClass, "Value", "I"), 0);
                }
            }
        }
    return RetValue ;
    }








/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteAcceptorDetails
 * Signature: (ILaes/imhei/AESImhei/AcceptorBlock;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteAcceptorDetails
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // We don't need to copy back most of the information - only the "output" fields.
    AcceptorBlock TheAcceptor ;
    TheAcceptor.Status      = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "Status", "I"));
    TheAcceptor.DefaultPath = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "DefaultPath", "I"));
    TheAcceptor.NoOfCoins   = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "NoOfCoins", "I"));

    jobjectArray JavaArray = static_cast<jobjectArray>
                    (env->GetObjectField(JavaObject, env->GetFieldID(Javaclass, "Coin", "[Laes/imhei/AESImhei$AcceptorCoin;")));

    jclass  CoinClass = env->GetObjectClass(env->GetObjectArrayElement(JavaArray, 0)) ;
    for (int No = 0 ; No < TheAcceptor.NoOfCoins ; ++No)
        {
        jobject JavaCoin = env->GetObjectArrayElement(JavaArray, No) ;
        TheAcceptor.Coin[No].Inhibit         = env->GetIntField(JavaCoin, env->GetFieldID(CoinClass, "Inhibit", "I"));
        TheAcceptor.Coin[No].Path            = env->GetIntField(JavaCoin, env->GetFieldID(CoinClass, "Path", "I"));
        TheAcceptor.Coin[No].PathSwitchLevel = env->GetIntField(JavaCoin, env->GetFieldID(CoinClass, "PathSwitchLevel", "I"));
        TheAcceptor.Coin[No].DefaultPath     = env->GetIntField(JavaCoin, env->GetFieldID(CoinClass, "DefaultPath", "B"));
        }

    WriteAcceptorDetails(JavaInt, &TheAcceptor) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadDispenserDetails
 * Signature: (ILaes/imhei/AESImhei/DispenserBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadDispenserDetails
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
    DispenserBlock TheDispenser ;
    jboolean RetValue = ReadDispenserDetails(JavaInt, &TheDispenser) ;

    if (RetValue)
        {
        // and copy it into the java class
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Unit", "I"),            TheDispenser.Unit);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Status", "I"),          TheDispenser.Status);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "InterfaceNumber", "I"), TheDispenser.InterfaceNumber);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "UnitAddress", "I"),     TheDispenser.UnitAddress);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Value", "I"),           TheDispenser.Value);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Count", "I"),           TheDispenser.Count);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Inhibit", "I"),         TheDispenser.Inhibit);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "NotesToDump", "I"),     TheDispenser.NotesToDump);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "SerialNumber", "I"),    TheDispenser.SerialNumber);
        env->SetObjectField(JavaObject, env->GetFieldID(Javaclass, "Description", "Ljava/lang/String;"),
                                                                       env->NewStringUTF(TheDispenser.Description));
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "CoinCount", "I"),       TheDispenser.CoinCount);
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "CoinCountStatus", "I"), TheDispenser.CoinCountStatus);
        }
    return RetValue ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteDispenserDetails
 * Signature: (ILaes/imhei/AESImhei/DispenserBlock;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteDispenserDetails
  (JNIEnv* env, jclass obj, jint JavaInt, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // We don't need to copy back most of the information - only the "output" fields.
    DispenserBlock TheDispenser ;
    TheDispenser.Inhibit     = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "Inhibit", "I"));
    TheDispenser.Value       = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "Value", "I"));
    TheDispenser.Status      = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "Status", "I"));
    TheDispenser.NotesToDump = env->GetIntField(JavaObject, env->GetFieldID(Javaclass, "NotesToDump", "I"));

    WriteDispenserDetails(JavaInt, &TheDispenser) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    WriteInterfaceBlock
 * Signature: (I[BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_WriteInterfaceBlock
  (JNIEnv* env, jclass obj, jint JavaInt, jbyteArray JavaArray, jint JavaInt2)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    WriteInterfaceBlock(JavaInt, reinterpret_cast<char*>(Data), JavaInt2) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadInterfaceBlock
 * Signature: (I[BI)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_ReadInterfaceBlock
  (JNIEnv* env, jclass obj, jint JavaInt, jbyteArray JavaArray, jint JavaInt2)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    jint RetValue = ReadInterfaceBlock(JavaInt, reinterpret_cast<char*>(Data), JavaInt2) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    return RetValue ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterIncrement
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterIncrement
  (JNIEnv* env, jclass obj, jint JavaInt, jint JavaInt2)
    {
    CounterIncrement( JavaInt, JavaInt2) ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterCaption
 * Signature: (ILjava/lang/String;)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterCaption
  (JNIEnv* env, jclass obj, jint JavaInt, jstring JavaString)
    {
    char* input = (char*)env->GetStringUTFChars(JavaString, 0) ;
    CounterCaption(JavaInt, input) ;
    env->ReleaseStringUTFChars(JavaString, input) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterRead
 * Signature: (I)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_CounterRead
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    return CounterRead(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadCounterCaption
 * Signature: (I)Ljava/lang/String;
 */
JNIEXPORT jstring JNICALL Java_aes_imhei_AESImhei_ReadCounterCaption
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    return env->NewStringUTF(ReadCounterCaption(JavaInt)) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    CounterDisplay
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_CounterDisplay
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    CounterDisplay(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    MeterStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_MeterStatus
  (JNIEnv* env, jclass obj)
    {
    return MeterStatus() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    MeterSerialNo
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_MeterSerialNo
  (JNIEnv* env, jclass obj)
    {
    return MeterSerialNo() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromReset
 * Signature: (I)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromReset
  (JNIEnv* env, jclass obj, jint JavaInt)
    {
    E2PromReset(JavaInt) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromWrite
 * Signature: ([BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromWrite
  (JNIEnv* env, jclass obj, jbyteArray JavaArray, jint JavaInt)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    E2PromWrite(Data, JavaInt) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    E2PromRead
 * Signature: ([BI)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_E2PromRead
  (JNIEnv* env, jclass obj, jbyteArray JavaArray, jint JavaInt)
    {
    jboolean IsCopy ;
    jbyte* Data = env->GetByteArrayElements(JavaArray, &IsCopy) ;
    E2PromRead(Data, JavaInt) ;
    env->ReleaseByteArrayElements(JavaArray, Data, 0) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    ReadEscrowBlock
 * Signature: (ILaes/imhei/AESImhei/EscrowControlBlock;)Z
 */
JNIEXPORT jboolean JNICALL Java_aes_imhei_AESImhei_ReadEscrowBlock
  (JNIEnv* env, jclass obj, jint Number, jobject JavaObject)
    {
    jclass Javaclass = env->GetObjectClass(JavaObject) ;

    // Get the information
     EscrowControlBlock MySnapshot ;
     jboolean RetVal = (ReadEscrowBlock(Number, &MySnapshot) != 0) ;

     if (RetVal)
        {
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "EscrowVersion", "I"), MySnapshot.EscrowVersion ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "State"        , "I"), MySnapshot.State         ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "Result"       , "I"), MySnapshot.Result        ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "TotalValue"   , "I"), MySnapshot.TotalValue    ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "ValueReturned", "I"), MySnapshot.ValueReturned ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "AcceptorNo"   , "I"), MySnapshot.AcceptorNo    ) ;
        env->SetIntField(JavaObject, env->GetFieldID(Javaclass, "NoInEscrow"   , "I"), MySnapshot.NoInEscrow    ) ;
        jobjectArray JavaArray = static_cast<jobjectArray>
                        (env->GetObjectField(JavaObject, env->GetFieldID(Javaclass, "EscrowNote", "[Laes/imhei/AESImhei$EscrowNoteDetails;")));

        jclass  NoteClass = env->GetObjectClass(env->GetObjectArrayElement(JavaArray, 0)) ;

        for (int No = 0 ; No < MAX_ESCROW ; ++No)
            {
            jobject JavaNote = env->GetObjectArrayElement(JavaArray, No) ;
            if (No < MySnapshot.NoInEscrow)
                {
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "Value"     , "I"),  MySnapshot.EscrowNote[No].Value      )  ;
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "NoteNumber", "I"),  MySnapshot.EscrowNote[No].NoteNumber )  ;
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "Location"  , "I"),  MySnapshot.EscrowNote[No].Location   )  ;
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "Status"    , "I"),  MySnapshot.EscrowNote[No].Status     )  ;
                }
        else
                {
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "Value"     , "I"),  0 )  ;
                env->SetIntField(JavaNote, env->GetFieldID(NoteClass, "NoteNumber", "I"),  0 )  ;
                }
            }
        }
    return RetVal ;
    }


/*
 * Class:     aes_imhei_AESImhei
 * Method:    EscrowCommand
 * Signature: (II)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_EscrowCommand
  (JNIEnv* env, jclass obj, jint Number,jint Command)
{
    return EscrowCommand(Number, Command) ;
}

/*
 * Class:     aes_imhei_AESImhei
 * Method:    SetDeviceKey
 * Signature: (III)V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_SetDeviceKey
  (JNIEnv* env, jclass obj, jint JavaInt, jint JavaInt2, jint JavaInt3)
    {
    SetDeviceKey(JavaInt, JavaInt2, JavaInt3) ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    USBDriverStatus
 * Signature: ()I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_USBDriverStatus
  (JNIEnv* env, jclass obj)
    {
    return USBDriverStatus() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    USBDriverExit
 * Signature: ()V
 */
JNIEXPORT void JNICALL Java_aes_imhei_AESImhei_USBDriverExit
  (JNIEnv* env, jclass obj)
    {
    USBDriverExit() ;
    }

/*
 * Class:     aes_imhei_AESImhei
 * Method:    FirmwareVersion
 * Signature: ([Ljava/lang/String;[Ljava/lang/String;)I
 */
JNIEXPORT jint JNICALL Java_aes_imhei_AESImhei_FirmwareVersion
  (JNIEnv* env, jclass obj, jobjectArray JavaString, jobjectArray JavaString2)
    {
    char Date[20] ;
    char Time[20] ;
    jint RetValue = FirmwareVersion(Date, Time) ;

    env->SetObjectArrayElement(
            JavaString,0,env->NewStringUTF(Date));
    env->SetObjectArrayElement(
            JavaString2,0,env->NewStringUTF(Time));

    return RetValue ;
    }




