unit Main;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, ComCtrls, Indicators, Buttons, AesImhei ;

type
  TMainForm = class(TForm)
    TheLabel: TLabel;
    ThePanel: TPanel;
    ResetRead: TButton;
    TheTimer: TTimer;
    JustRead: TPanel;
    TotalAmount: TPanel;
    Image: TImage;
    Panel1: TPanel;
    AmountPaid: TPanel;
    Panel2: TPanel;
    AcceptorsButton: TButton;
    DispensersButton: TButton;
    LEDButton: TButton;
    MeterButton: TButton;
    PayButton: TButton;
    CoinPay: TEdit;
    EscrowAmount: TPanel;
    EventCaption: TLabel;
    EventPanel: TPanel;
    LatestEvent: TRichEdit;
    EventViewButton: TBitBtn;
    EventOuter: TPanel;
    EscrowReturnButton: TButton;
    EscrowAcceptButton: TButton;
    EscrowPanel: TPanel;
    EscrowButton: TSpeedButton;
    BarCodeButton: TButton;
    USBStatus: TLabel;
    DESButton: TButton;
    ExtEscrowPanel: TPanel;
    EscNotes: TPanel;
    EscValue: TPanel;
    ExitButton: TButton;
    EscState: TPanel;
    Escrow1: TButton;
    Escrow2: TButton;
    Escrow3: TButton;
    NoteList: TRichEdit;
    procedure ExitButtonClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure TheTimerTimer(Sender: TObject);
    procedure ResetReadClick(Sender: TObject);
    procedure CoinPayClick(Sender: TObject);
    procedure AcceptorsButtonClick(Sender: TObject);
    procedure LEDButtonClick(Sender: TObject);
    procedure MeterButtonClick(Sender: TObject);
    procedure DispensersButtonClick(Sender: TObject);
    procedure CoinPayExit(Sender: TObject);
    procedure EscrowButtonClick(Sender: TObject);
    procedure EscrowAcceptButtonClick(Sender: TObject);
    procedure EscrowReturnButtonClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure EventViewButtonClick(Sender: TObject);
    procedure BarCodeButtonClick(Sender: TObject);
    procedure DESButtonClick(Sender: TObject);
    procedure CoinPayKeyPress(Sender: TObject; var Key: Char);
    procedure Escrow3Click(Sender: TObject);
    procedure Escrow2Click(Sender: TObject);
    procedure Escrow1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
    DoingPrecise : Boolean ;
  end;

const
  EventTab = 140 ;
  TopMargin = 24 ;

var
  MainForm     : TMainForm;
  CurrentRead  : LongInt ;
  PaidAtStart  : LongInt ;
  SnapShot     : LongInt ;
  EscrowAtAccept : LongInt ;
  MainFormHeight : LongInt ;
  EscrowCommand1 : LongInt ;
  EscrowCommand2 : LongInt ;
  EscrowCommand3 : LongInt ;
  NotesInList  : LongInt ;

implementation

uses PayCode, Acceptors, SwitchUnit, MeterUnit, Dispensers,
     EventListCode, ImheiEvent, BarCode, DESUnit ;

{$R *.DFM}

procedure TMainForm.ExitButtonClick(Sender: TObject);
begin
   CheckOperation(0, 0) ;       // Turn off watchdog
   Application.Terminate ;
end;


procedure TMainForm.FormClose(Sender: TObject; var Action: TCloseAction);
begin
    DisableInterface ;
end;


procedure TMainForm.FormCreate(Sender: TObject);
   var Ret : LongInt ;
   EscrowControl : TEscrowControlBlock ;
begin
    Ret := OpenMHE ;
    if Ret <> 0 then
    begin
        ShowMessage('MHE Open error ' + IntToStr(Ret)) ;
        Application.Terminate ;
    end
    else
    begin
        EnableInterface ;
        TheTimer.Enabled := True ;
        SnapShot := CurrentValue ;
        MainFormHeight := Height ;        // Save "Form with Escrow" height
        Height := EscrowPanel.Top + TopMargin ;      // No Escrow to start

        if ReadEscrowBlock(0, EscrowControl) = 0 then
        begin            // Turn off the extended Escrow window
            Width := ExtEscrowPanel.Left + 4 ;
        end ;
        
        
        if DESStatus <> DES_NOT then
        begin
            DESButton.Visible := true ;
        end ;
    end ;
end ;





procedure TMainForm.FormShow(Sender: TObject);
begin
    LatestEvent.SelectAll() ;
    LatestEvent.Paragraph.TabCount := 1 ;
    LatestEvent.Paragraph.Tab[0] := EventTab ;
    LatestEvent.SelLength := 0 ;
end;






procedure TMainForm.TheTimerTimer(Sender: TObject);
var
   Read          : LongInt ;
   EventDetails  : TEventDetailBlock ;
   Event         : LongInt ;
   EscrowControl : TEscrowControlBlock ;
   i             : LongInt ;
   TempStr       : String ;
   
begin
      CurrentRead := CurrentValue ;
      TotalAmount.Caption := Format('%n', [CurrentRead / 100]) ;
      AmountPaid.Caption := Format('%n', [CurrentPaid / 100]) ;
      EscrowAmount.Caption := Format('%n', [(EscrowThroughput -
                                             EscrowAtAccept) / 100]) ;

      case USBDriverStatus of
      
      NOT_USB:
          USBStatus.Caption := '' ; 
          
      USB_IDLE:
          USBStatus.Caption := 'Driver: Not loaded' ; 
                     
      STANDARD_DRIVER:
          USBStatus.Caption := 'Driver: OK' ; 
              
      FLASH_LOADER:
          USBStatus.Caption := 'Flash reprogramming' ; 
                 
      MANUFACTURING_TEST:
          USBStatus.Caption := 'Manufacturing Test' ; 
           
      DRIVER_RESTART:
          USBStatus.Caption := 'Driver: Restarting' ; 
               
      USB_ERROR:
          USBStatus.Caption := 'Driver: USB Error' ; 
                    
      else
          USBStatus.Caption := 'Driver: Unknown Status' ;
      end ;
      
      Read := CurrentRead - SnapShot ;
      JustRead.Caption := Format('%n', [Read / 100]) ;

      Event := NextEvent(EventDetails) ;
      if (Event <> 0) then
      begin
          LatestEvent.Text :=  EventDecode(Event) + Char(9) ;

          if (Event >= COIN_DISPENSER_EVENT)
          then
              if EventDetails.DispenserEvent = 0
              then
                 LatestEvent.Text := LatestEvent.Text + Format('| Raw Code: %.2x  Acc: %d',
                                          [EventDetails.RawEvent, EventDetails.Index])
              else
                 LatestEvent.Text := LatestEvent.Text + Format('| Raw Code: %.2x Disp: %d',
                                          [EventDetails.RawEvent, EventDetails.Index]) ;

          EventList.Events.Text := LatestEvent.Text + char(10) + EventList.Events.Text ;
          LatestEvent.SelectAll() ;
          LatestEvent.Paragraph.TabCount := 1 ;
          LatestEvent.Paragraph.Tab[0] := EventTab ;
          LatestEvent.SelLength := 0 ;
      end ;





      if ReadEscrowBlock(0, EscrowControl) <> 0 then
      begin            // Fill in the Escrow details
          case EscrowControl.State of

          EXT_ESCROW_NONE:
          begin    
              EscState.Caption := 'None' ;
              Escrow1.Caption  := '' ;
              Escrow1.Visible  := false ;
              EscrowCommand1   := 0 ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_OFF:
          begin    
              EscState.Caption := 'Off' ;
              Escrow1.Caption  := 'Start' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_START ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_IDLE:
          begin    
              EscState.Caption := 'Idle' ;
              Escrow1.Caption  := 'Accept' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_ACCEPT ;
              Escrow2.Caption  := 'Stop' ;
              Escrow2.Visible  := true ;
              EscrowCommand2   := EXT_ESCROW_STOP ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_WAITING:
          begin    
              EscState.Caption := 'Waiting' ;
              Escrow1.Caption  := 'Pause' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_PAUSE ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_LOADING:
          begin    
              EscState.Caption := 'Loading' ;
              Escrow1.Caption  := '' ;
              Escrow1.Visible  := false ;
              EscrowCommand1   := 0 ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_STORED:
          begin    
              EscState.Caption := 'Stored' ;
              Escrow1.Caption  := 'Pause' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_PAUSE ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_PAUSED:
          begin    
              EscState.Caption := 'Paused' ;
              Escrow1.Caption  := 'Stack' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_STACK ;
              Escrow2.Caption  := 'Return' ;
              Escrow2.Visible  := true ;
              EscrowCommand2   := EXT_ESCROW_RETURN ;
              Escrow3.Caption  := 'Accept' ;
              Escrow3.Visible  := true ;
              EscrowCommand3   := EXT_ESCROW_ACCEPT ;
          end ;    

          EXT_ESCROW_STACKING:
          begin    
              EscState.Caption := 'Stacking' ;
              Escrow1.Visible  := false ;
              EscrowCommand1   := 0 ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;

          EXT_ESCROW_RETURNING:
          begin    
              EscState.Caption := 'Returning' ;
              Escrow1.Caption  := '' ;
              Escrow1.Visible  := false ;
              EscrowCommand1   := 0 ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_RETURNED_OK:
          begin    
              EscState.Caption := 'Returned OK' ;
              Escrow1.Caption  := 'Accept' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_ACCEPT ;
              Escrow2.Caption  := 'Stop' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := EXT_ESCROW_STOP ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_RETURNING_PROBLEM:
          begin
              EscState.Caption := 'Returning Problem' ;
              Escrow1.Caption  := 'Return' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_RETURN ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
        end ;

          EXT_ESCROW_STACKED_OK:
          begin    
              EscState.Caption := 'Stacked OK' ;
              Escrow1.Caption  := 'Accept' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_ACCEPT ;
              Escrow2.Caption  := 'Stop' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := EXT_ESCROW_STOP ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_STACKING_PROBLEM:
          begin    
              EscState.Caption := 'Stack Problem' ;
              Escrow1.Caption  := '' ;
              Escrow1.Visible  := false ;
              EscrowCommand1   := 0 ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;

          EXT_ESCROW_FULL:
          begin    
              EscState.Caption := 'Full' ;
              Escrow1.Caption  := 'Pause' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_PAUSE ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          EXT_ESCROW_POWER_ACTIVE:
          begin    
              EscState.Caption := 'Active at start' ;
              Escrow1.Caption  := 'Pause' ;
              Escrow1.Visible  := true ;
              EscrowCommand1   := EXT_ESCROW_PAUSE ;
              Escrow2.Caption  := '' ;
              Escrow2.Visible  := false ;
              EscrowCommand2   := 0 ;
              Escrow3.Caption  := '' ;
              Escrow3.Visible  := false ;
              EscrowCommand3   := 0 ;
          end ;    

          else
              EscState.Caption := 'Unknown State!' ;
          end ;
          
          EscValue.Caption := Format('%n', [EscrowControl.TotalValue / 100]) ;
          EscNotes.Caption := Format('%d', [EscrowControl.NoInEscrow]) ;

          NotesInList := EscrowControl.NoInEscrow ;
          if NotesInList = 0 then
          begin
              NoteList.Text    := '' ;
              NoteList.Visible := false ;
          end
          else
          begin
              TempStr      := 'Note Value' + Char(9) + 'Location' + Char(9) + 'Status' + Char(10) ;
              for i := 0 to EscrowControl.NoInEscrow - 1 do
              begin
                  TempStr := TempStr + format('%d', [EscrowControl.EscrowNote[i].Value]) +  Char(9)
                                                 + format('%d', [EscrowControl.EscrowNote[i].Location])  ;
                  if EscrowControl.EscrowNote[i].Status = ESCROW_NOTE_PROBLEM then
                          TempStr := TempStr + Char(9) + 'Problem'
                  else if EscrowControl.EscrowNote[i].Status = ESCROW_NOTE_RETURNED then
                          TempStr := TempStr + Char(9) + 'Returned'
                  else if EscrowControl.EscrowNote[i].Status = ESCROW_NOTE_STACKED then
                          TempStr := TempStr + Char(9) + 'Stacked'
                  else
                          TempStr := TempStr + Char(9) + 'Stored' ;
                  TempStr := TempStr + Char(10) ;
              end ;
              if TempStr <> NoteList.Text then
              begin
                  NoteList.Text := TempStr ;
                  NoteList.SelectAll() ;
                  NoteList.Paragraph.TabCount := 2 ;
                  NoteList.Paragraph.Tab[0] := 55 ;
                  NoteList.Paragraph.Tab[1] := 100 ;
                  NoteList.SelLength := 0 ;
              end ;

              NoteList.Visible := true ;
          end ;
      end ;

 end;







procedure TMainForm.ResetReadClick(Sender: TObject);
begin
   SnapShot := CurrentRead ;
end;


procedure TMainForm.CoinPayClick(Sender: TObject);
var AccPaid : LongInt ;
begin
   PaidAtStart := CurrentPaid ;
   if DoingPrecise then
   begin
       AccPaid := PaySpecific ;
       if AccPaid <> CoinPay.Tag 
       then
            ShowMessage('PaySpecific reports ' + IntToStr(AccPaid) + ' rather than ' + IntToStr(CoinPay.Tag)) ; 
       CoinPay.Tag := AccPaid ;
   end
   else
   begin
       PayOut(CoinPay.Tag) ;
   end ;
   PayForm.AmountPaid.Caption := Format('%n', [CoinPay.Tag * 0.01]) ;
   PayForm.ShowModal ;
end;



procedure TMainForm.AcceptorsButtonClick(Sender: TObject);
begin
    AcceptorsForm.Show
end;



procedure TMainForm.LEDButtonClick(Sender: TObject);
begin
    SwitchForm.Show
end;

procedure TMainForm.MeterButtonClick(Sender: TObject);
begin
    MeterForm.Show
end;



procedure TMainForm.DispensersButtonClick(Sender: TObject);
begin
    DispensersForm.Show
end;



procedure TMainForm.CoinPayExit(Sender: TObject);
   var i     : Integer ;
   var Value : Integer ;
   var Dec   : Real ;
begin
   Dec := 0 ;
   Value := 0 ;
   for i := 1 to Length(CoinPay.Text) do
   begin
     if CoinPay.Text[i] = '.' then
     begin
       Dec   := 10.0 ;
       Value := Value * 100 ;
     end
     else if (CoinPay.Text[i] >= '0') and (CoinPay.Text[i] <= '9')
     then
       if Dec = 0
       then
          Value := Value * 10 + Ord(CoinPay.Text[i]) - Ord('0')
       else
       begin
          Value := Value + trunc((Ord(CoinPay.Text[i]) - Ord('0')) * Dec) ;
          Dec   := Dec / 10 ;
       end ;
   end ;
   if Dec = 0 then
      Value := Value * 100 ; // No Decimal point!
   CoinPay.Tag  := Value ;
   CoinPay.Text := Format('%n', [CoinPay.Tag * 0.01]) ;
end;


procedure TMainForm.EscrowButtonClick(Sender: TObject);
begin
    If EscrowButton.Down then
    begin
       Height := MainFormHeight ;
       EscrowButton.Caption := 'Escrow Off' ;
       EscrowAtAccept := EscrowThroughput ;         // Zero the display
       EscrowEnable ;
    end
    else
    begin
       Height := EscrowPanel.Top + TopMargin ;
       EscrowButton.Caption := 'Escrow On' ;
       EscrowDisable ;
    end

end;




procedure TMainForm.EscrowAcceptButtonClick(Sender: TObject);
begin
    EscrowAtAccept := EscrowThroughput ;
    EscrowAccept ;
end;

procedure TMainForm.EscrowReturnButtonClick(Sender: TObject);
begin
    EscrowAtAccept := EscrowThroughput ;
    EscrowReturn ;
end;


procedure TMainForm.EventViewButtonClick(Sender: TObject);
begin
    EventCaption.Caption := 'Event List' ;
    EventList.Left := Left +  EventOuter.Left + EventPanel.Left + 2 ;
    EventList.Top  := Top  +  EventOuter.Top + TopMargin + EventPanel.Top;
    EventList.Width:= EventPanel.Width ;
    EventList.Show ;
end ;









procedure TMainForm.BarCodeButtonClick(Sender: TObject);
begin
    BarCodeForm.Left := Left - BarCodeForm.Width ;
    BarCodeForm.Top  := Top ;
    BarCodeForm.Show ;
end;




procedure TMainForm.DESButtonClick(Sender: TObject);
begin
    DESForm.Left := Left - DESForm.Width ;
    DESForm.Top  := Top ;
    DESForm.Show ;
end;

procedure TMainForm.CoinPayKeyPress(Sender: TObject; var Key: Char);
begin
    if Ord(Key) = 13 then
    begin
         CoinPayExit(Sender) ;
         CoinPayClick(Sender) ;
    end ;
end;








procedure TMainForm.Escrow3Click(Sender: TObject);
begin
    EscrowCommand(0, EscrowCommand3) ;
end;

procedure TMainForm.Escrow2Click(Sender: TObject);
begin
    EscrowCommand(0, EscrowCommand2) ;
end;

procedure TMainForm.Escrow1Click(Sender: TObject);
begin
    EscrowCommand(0, EscrowCommand1) ;

end;


end.
