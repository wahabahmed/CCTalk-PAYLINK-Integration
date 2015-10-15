unit Acceptors;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, AesImhei, Utility, Buttons;

type
  TAcceptorsForm = class(TForm)
    TheCount: TPanel;
    ThePathCount: TPanel;
    TheValue: TPanel;
    TheRouted: TEdit;
    TheCoinDefPath: TEdit;
    TheSwitchLevel: TEdit;
    TheEscrow: TPanel;
    Status: TPanel;
    InterfaceNo: TPanel;
    UnitAddress: TPanel;
    CoinCount: TPanel;
    Currency: TPanel;
    DefPath: TEdit;
    Timer: TTimer;
    ALabel: TLabel;
    AcceptorChoice: TComboBox;
    ExitButton: TButton;
    Client: TPanel;
    AcceptorInhibit: TCheckBox;
    TheCoinInhibit: TCheckBox;
    BatchUpdates: TSpeedButton;
    Serial: TPanel;
    DescPanel: TPanel;
    Description: TLabel;
    TheCoinName: TPanel;
    DescCaption: TLabel;
    BarcodesStacked: TPanel;
    EscrowBarcodeHere: TLabel;
    BarcodeStackedText: TLabel;
    procedure ExitButtonClick(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure AcceptorChoiceChange(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure TimerTimer(Sender: TObject);
    procedure TheRoutedChange(Sender: TObject);
    procedure TheCoinDefPathChange(Sender: TObject);
    procedure TheSwitchLevelChange(Sender: TObject);
    procedure DefPathChange(Sender: TObject);
    procedure AcceptorInhibitClick(Sender: TObject);
    procedure TheCoinInhibitClick(Sender: TObject);
    procedure BatchUpdatesClick(Sender: TObject);
 private
    { Private declarations }
  public
    { Public declarations }
  end;

const MAX_COIN = 64 ;

var                                      
  AcceptorsForm: TAcceptorsForm;

  Value       : Array [0..MAX_COIN] of TPanel;
  Count       : Array [0..MAX_COIN] of TPanel;
  PathCount   : Array [0..MAX_COIN] of TPanel;
  Escrow      : Array [0..MAX_COIN] of TPanel;
  CoinName    : Array [0..MAX_COIN] of TPanel;
  Routed      : Array [0..MAX_COIN] of TEdit;
  CoinDefPath : Array [0..MAX_COIN] of TEdit;
  SwitchLevel : Array [0..MAX_COIN] of TEdit;
  CoinInhibit : Array [0..MAX_COIN] of TCheckBox;


  Acceptor      : TAcceptorBlock ;
  AcceptorIndex : Integer ;
  DefaultWidth  : Integer ;
  DuringUpdate  : Boolean ;
  AcceptorType  : Array [0..255] of LongInt ;

implementation

{$R *.DFM}

procedure WriteToAcceptor ;
begin
    if (not AcceptorsForm.BatchUpdates.Down) and (AcceptorIndex >= 0) and (not DuringUpdate)
    then
        WriteAcceptorDetails(AcceptorIndex, Acceptor) ;
end ;


procedure SetUpAcceptors ;
var Serial        : LongInt ;
    Line          : string ;
    AcceptorName  : string ;
begin
    AcceptorsForm.AcceptorChoice.Items.Clear ;
    Serial := 0 ;
    While ReadAcceptorDetails(Serial, Acceptor) do
    begin
       AcceptorType[Serial] := Acceptor.UnitType ;
       case Acceptor.UnitType of
       DP_AST_GBA:              AcceptorName := 'AstroSystems GBA' ;
       DP_AZK_A6:               AcceptorName := 'Azkoyen A6' ;
       DP_AZK_MDB:              AcceptorName := 'Azkoyen MDB Changer' ;
       DP_CC_ACCEPTOR:          AcceptorName := 'CashCode Acceptor' ;
       DP_CC_RECYCLER:          AcceptorName := 'CashCode Bill to Bill' ;
       DP_COINCO_BILLPRO:       AcceptorName := 'CoinCo BillPro' ;
       DP_COINCO_GLOBAL:        AcceptorName := 'CoinCo Global' ;
       DP_COINCO_MDB:           AcceptorName := 'CoinCo MDB Changer' ;
       DP_COINCO_MDB_BILL:      AcceptorName := 'CoinCo MDB Bill' ;
       DP_COINCO_VORTEX:        AcceptorName := 'CoinCo Vortex' ;
       DP_GPT_NOTE:             AcceptorName := 'GPT Argus' ;
       DP_ICT_U85:              AcceptorName := 'ICT U85' ;
       DP_ID003_NOTE:           AcceptorName := 'ID-003 Note' ;
       DP_ID003_RECYCLER:        AcceptorName := 'ID-003 Note Recycler' ;
       DP_INNOV_NV10:           AcceptorName := 'Innovative NV10' ;
       DP_INNOV_NV11:           AcceptorName := 'Innovative NV11' ;
       DP_INNOV_NV200:          AcceptorName := 'Innovative NV200' ;
       DP_INNOV_NV4:            AcceptorName := 'Innovative NV4' ;
       DP_INNOV_NV7:            AcceptorName := 'Innovative NV7' ;
       DP_INNOV_NV8:            AcceptorName := 'Innovative NV8' ;
       DP_INNOV_NV9:            AcceptorName := 'Innovative NV9' ;
       DP_JCM_CC_EBA:           AcceptorName := 'JCM EBA on cctalk' ;
       DP_JCM_CC_WBA:           AcceptorName := 'JCM WBA on cctalk' ;
       DP_JCM_NOTE:             AcceptorName := 'JCM Note' ;
       DP_JCM_VEGA:             AcceptorName := 'JCM Vega' ;
       DP_MARS_CASHFLOW_126:    AcceptorName := 'Mars Cashflow 126' ;
       DP_MARS_CASHFLOW_690:    AcceptorName := 'Mars Cashflow 690' ;
       DP_MARS_CASHFLOW_9500:   AcceptorName := 'Mars Cashflow 9500' ;
       DP_MARS_MDB:             AcceptorName := 'Mars MDB Changer' ;
       DP_MCL_7200:             AcceptorName := 'MCL 7200' ;
       DP_MCL_ARDAC:            AcceptorName := 'MCL Ardac /ID-003' ;
       DP_MCL_ARDAC_ELITE:      AcceptorName := 'MCL Ardac Elite' ;
       DP_MCL_BCR:              AcceptorName := 'MCL Bulk coin Recycler' ;
       DP_MCL_BCS:              AcceptorName := 'MCL Bulk coin Sorter' ;
       DP_MCL_CONDOR:           AcceptorName := 'MCL Condor' ;
       DP_MCL_CR100:            AcceptorName := 'MCL CR100 Recycler' ;
       DP_MCL_LUMINA:           AcceptorName := 'MCL Lumina' ;
       DP_MCL_NR2:              AcceptorName := 'MCL NR2 coin recycler' ;
       DP_MCL_SR3:              AcceptorName := 'MCL SR3' ;
       DP_MCL_SR5:              AcceptorName := 'MCL SR5' ;
       DP_MCL_WACS:             AcceptorName := 'MCL Ardac / WACS' ;
       DP_MDB_BILL:             AcceptorName := 'MBD Bill' ;
       DP_MDB_LEVEL_2:          AcceptorName := 'MDB Level 2 Changer' ;
       DP_MDB_LEVEL_3:          AcceptorName := 'MDB Level 3 Changer' ;
       DP_MERKUR_100:           AcceptorName := 'Merkur 100 Recycler' ;
       DP_NRI_G40:              AcceptorName := 'NRI G40' ;
       DP_NRI_PELICANO:         AcceptorName := 'NRI Pelicano' ;
       DP_SHOPPER_ACCEPT:       AcceptorName := 'Smart Hopper Acceptor' ;
       DP_HII_INTERFACE    or DP_COIN_ACCEPT_DEVICE:         AcceptorName := 'Hi2 Coin'                       ;
       DP_CCTALK_INTERFACE or DP_COIN_ACCEPT_DEVICE:         AcceptorName := 'ccTalk Coin' ;
       DP_CCTALK_INTERFACE or DP_NOTE_ACCEPT_DEVICE:         AcceptorName := 'ccTalk Note' ;                  
       else
           AcceptorName := 'Unknown' ;
       end ;

       Line := Format('%d:  %s', [Serial + 1, AcceptorName]) ;
       AcceptorsForm.AcceptorChoice.Items.Add(Line) ;
       Inc(Serial) ;
    end ;
    AcceptorIndex := Serial - 1 ;
    if (AcceptorIndex < 0) then
    begin
       AcceptorsForm.AcceptorChoice.Items.Add('No acceptors') ;
    end ;
end;





procedure CheckAcceptors ;
var Serial        : LongInt ;
begin
    Serial := 0 ;
    While ReadAcceptorDetails(Serial, Acceptor) do
    begin
       if AcceptorType[Serial] <> Acceptor.UnitType then
       begin
         SetUpAcceptors ;
         Exit ;
       end ;
       Inc(Serial) ;
    end ;
end;









procedure TAcceptorsForm.FormCreate(Sender: TObject);
var i             : Integer ;
begin
    DefaultWidth := AcceptorsForm.Width ;
    for i := 0 to MAX_COIN do
    begin
       CreatePanel(Value[i],     TheValue,       i, 0) ;
       CreatePanel(Count[i],     TheCount,       i, 0) ;
       CreatePanel(PathCount[i], ThePathCount,   i, 0) ;
       CreatePanel(Escrow[i],    TheEscrow,      i, 0) ;
       CreatePanel(CoinName[i],  TheCoinName,    i, 0) ;

       CreateEdit(Routed[i],     TheRouted,      i, 0) ;
       CreateEdit(CoinDefPath[i],TheCoinDefPath, i, 0) ;
       CreateEdit(SwitchLevel[i],TheSwitchLevel, i, 0) ;

       CoinInhibit[i]            := TCheckBox.Create(TheCoinInhibit.Owner) ;
       CoinInhibit[i].Parent     := TheCoinInhibit.Parent ;
       CoinInhibit[i].Height     := TheCoinInhibit.Height ;
       CoinInhibit[i].Top        := TheCoinInhibit.Top ;
       CoinInhibit[i].Width      := TheCoinInhibit.Width ;
       CoinInhibit[i].Color      := TheCoinInhibit.Color ;
       CoinInhibit[i].Left       := TheCoinInhibit.Left + (TheValue.Width + 4) * i ;
       CoinInhibit[i].Visible    := True ;
       CoinInhibit[i].Enabled    := True ;
       CoinInhibit[i].Tag        := i ;
       CoinInhibit[i].OnClick    := TheCoinInhibit.OnClick ;
    end ;
    SetUpAcceptors ;
end;





procedure TAcceptorsForm.ExitButtonClick(Sender: TObject);
begin
    Timer.Enabled := False ;
    Visible := False ;
end;




procedure TAcceptorsForm.FormShow(Sender: TObject);
begin
    AcceptorChoice.ItemIndex := AcceptorChoice.Items.Count - 1 ;
    AcceptorChoiceChange(Sender);

    Timer.Enabled := True ;
end;




procedure TAcceptorsForm.AcceptorChoiceChange(Sender: TObject);
var
    Acceptor      : TAcceptorBlock ;
    Code          : Integer ;
    i             : Integer ;
    WidthChange   : Integer ;
begin
    Val(AcceptorChoice.Text, AcceptorIndex, Code) ;
    Dec(AcceptorIndex) ;
    if  AcceptorIndex < 0
    then
        Exit ;

    if not ReadAcceptorDetails(AcceptorIndex, Acceptor) then
    begin
       ShowMessage(Format('Whoops. Can''t get Acceptor %d', [AcceptorIndex])) ;
       SetUpAcceptors ;
    end ;

    DuringUpdate := true ;
    if ((Acceptor.Status and ACCEPTOR_DISABLED) <> 0) then
        AcceptorInhibit.State := cbChecked
    else
        AcceptorInhibit.State := cbUnchecked ;
    
    Description.Caption := Acceptor.Description ;
    if (Description.Caption <> '') Then
       begin
       DescPanel.Visible := True ;
       DescCaption.Visible := True ;
       DescPanel.Width := Description.Width + 4 ;
       end
   else
       begin
       DescPanel.Visible := False ;
       DescCaption.Visible := False ;
       end ;
    InterfaceNo.Caption :=  Format('%d', [Acceptor.InterfaceNumber]) ;
    UnitAddress.Caption :=  Format('%d', [Acceptor.UnitAddress]) ;
    DefPath.Text        :=  Format('%d', [Acceptor.DefaultPath]) ;
    CoinCount.Caption   :=  Format('%d', [Acceptor.NoOfCoins]) ;
    Currency.Caption    :=  Format('%s', [Acceptor.Currency]) ;
    Serial.Caption      :=  Format('%d', [Acceptor.SerialNumber]) ;

    WidthChange := (Value[Acceptor.NoOfCoins - 1].Left + TheValue.Width + 9) - Client.Width ;
    if WidthChange < DescPanel.Left + DescPanel.Width - Client.Width
    Then
        WidthChange := DescPanel.Left + DescPanel.Width - Client.Width ;
    
    if AcceptorsForm.Width + WidthChange < DefaultWidth
    Then
        AcceptorsForm.Width := DefaultWidth
    else
    begin
        AcceptorsForm.Width := AcceptorsForm.Width + WidthChange ;
        If AcceptorsForm.Left + AcceptorsForm.Width + 100 > Screen.Width
        Then
           AcceptorsForm.Left := (Screen.Width - AcceptorsForm.Width) div 2 ;

        if AcceptorsForm.Left < 0
        Then
           AcceptorsForm.Left := 0 ;
    end ;

    for i := 0 to MAX_COIN do
    begin
      if i < Acceptor.NoOfCoins then
      begin
          Value      [i].Visible := true ;
          CoinName   [i].Visible := true ;
          PathCount  [i].Visible := true ;
          Escrow     [i].Visible := true ;
          Routed     [i].Visible := true ;
          CoinDefPath[i].Visible := true ;
          Count      [i].Visible := true ;
          SwitchLevel[i].Visible := true ;
          CoinInhibit[i].Visible := true ;

          Value      [i].Caption := Format('%d', [Acceptor.Coin[i].Value]) ;
          CoinName   [i].Caption := Acceptor.Coin[i].CoinName ;
          Count      [i].Caption := Format('%d', [Acceptor.Coin[i].Count]) ;
          Routed     [i].Text    := Format('%d', [Acceptor.Coin[i].Path]) ;
          CoinDefPath[i].Text    := Format('%d', [Acceptor.Coin[i].DefaultPath]) ;
          PathCount  [i].Caption := Format('%d', [Acceptor.Coin[i].PathCount]) ;
          Escrow     [i].Caption := Format('%d', [Acceptor.Coin[i].HeldInEscrow]) ;
          SwitchLevel[i].Text    := Format('%d', [Acceptor.Coin[i].PathSwitchLevel]) ;
          if Acceptor.Coin[i].Inhibit = 0
          then
              CoinInhibit[i].Checked := False
          else
              CoinInhibit[i].Checked := True ;
      end
      else
      begin
          Value      [i].Visible := False ;
          CoinName   [i].Visible := False ;
          Count      [i].Visible := False ;
          PathCount  [i].Visible := False ;
          Escrow     [i].Visible := False ;
          Routed     [i].Visible := False ;
          CoinDefPath[i].Visible := False ;
          SwitchLevel[i].Visible := False ;
          CoinInhibit[i].Visible := False ;
      end ;
    end ;
    DuringUpdate := false ;
end;





procedure TAcceptorsForm.TimerTimer(Sender: TObject);
var
    i             : Integer ;
    TheStatus     : LongInt ;
begin
    if AcceptorsForm.BatchUpdates.Down then
        Exit ;

    CheckAcceptors ;            // See if any of the acceptors have changed
    
    if AcceptorIndex < 0 then
        Exit ;
        
    if not ReadAcceptorDetails(AcceptorIndex, Acceptor) then
    begin
       SetUpAcceptors ;
       Exit ;
    end ;

    TheStatus := Acceptor.Status ;
    
    if TheStatus <> ACCEPTOR_BUSY then
        TheStatus := TheStatus and not (ACCEPTOR_BUSY or ACCEPTOR_INHIBIT) ;

    case TheStatus of
    0                 :     Status.Caption   :=  'OK' ;
    ACCEPTOR_DEAD     :     Status.Caption   :=  'Dead' ;
//  ACCEPTOR_ALL_DEAD :     Status.Caption   :=  'All Dead' ;
    ACCEPTOR_DISABLED :     Status.Caption   :=  'Disabled' ;
    ACCEPTOR_FRAUD    :     Status.Caption   :=  'Fraud' ;
    ACCEPTOR_BUSY     :     Status.Caption   :=  'Busy' ;
    ACCEPTOR_FAULT    :     Status.Caption   :=  'Fault' ;
    ACCEPTOR_NO_KEY   :     Status.Caption   :=  'Key Wait' ;
    else                    Status.Caption   :=  Format('%x', [Acceptor.Status]) ;
    end ;

    if Acceptor.EscrowBarcodeHere <> 0 then
    begin
       EscrowBarcodeHere.Visible  := true ;
       BarcodeStackedText.Visible := false ;
       BarcodesStacked.Visible    := false ;
    end
    else if Acceptor.BarcodesStacked <> 0 then
    begin
       EscrowBarcodeHere.Visible  := false ;
       BarcodeStackedText.Visible := true ;
       BarcodesStacked.Visible    := true ;
       BarcodesStacked.Caption    := Format('%d', [Acceptor.BarcodesStacked]) ;
    end
    else
    begin
       EscrowBarcodeHere.Visible  := false ;
       BarcodeStackedText.Visible := false ;
       BarcodesStacked.Visible    := false ;
    end ;



    for i := 0 to MAX_COIN do
    begin
      if i < Acceptor.NoOfCoins then
      begin
          Count      [i].Caption := Format('%d', [Acceptor.Coin[i].Count]) ;
          PathCount  [i].Caption := Format('%d', [Acceptor.Coin[i].PathCount]) ;
          Escrow     [i].Caption := Format('%d', [Acceptor.Coin[i].HeldInEscrow]) ;
      end
    end ;
end;




procedure TAcceptorsForm.TheRoutedChange(Sender: TObject);
var
    Value         : LongInt ;
    Code          : Integer ;
begin
    With Sender as TEdit do
    begin
       val(Text, Value, Code) ;
       Acceptor.Coin[Tag].Path := Value ;
       WriteToAcceptor ;
    end ;
end;





procedure TAcceptorsForm.TheCoinDefPathChange(Sender: TObject);
var
    Value         : LongInt ;
    Code          : Integer ;
begin
    With Sender as TEdit do
    begin
       val(Text, Value, Code) ;
       Acceptor.Coin[Tag].DefaultPath := Value ;
       WriteToAcceptor ;
    end ;
end;



procedure TAcceptorsForm.TheSwitchLevelChange(Sender: TObject);
var
    Value         : LongInt ;
    Code          : Integer ;
begin
    With Sender as TEdit do
    begin
       val(Text, Value, Code) ;
       Acceptor.Coin[Tag].PathSwitchLevel := Value ;
       WriteToAcceptor ;
    end ;
end;



procedure TAcceptorsForm.DefPathChange(Sender: TObject);
var
    Value         : LongInt ;
    Code          : Integer ;
begin
    With Sender as TEdit do
    begin
       val(Text, Value, Code) ;
       Acceptor.DefaultPath := Value ;
       WriteToAcceptor ;
    end ;
end;











procedure TAcceptorsForm.AcceptorInhibitClick(Sender: TObject);
begin
    if AcceptorInhibit.Checked
    then
        Acceptor.Status := Acceptor.Status   or    ACCEPTOR_INHIBIT
    else
        Acceptor.Status := Acceptor.Status and not ACCEPTOR_INHIBIT ;
    WriteToAcceptor ;
end;



procedure TAcceptorsForm.TheCoinInhibitClick(Sender: TObject);
begin
    With Sender as TCheckBox do
    begin
        if Checked
        then
            Acceptor.Coin[Tag].Inhibit := 1
        else
            Acceptor.Coin[Tag].Inhibit := 0 ;
        WriteToAcceptor ;
    end ;
end;



procedure TAcceptorsForm.BatchUpdatesClick(Sender: TObject);

begin
    WriteAcceptorDetails(AcceptorIndex, Acceptor) ;
end;





end.
