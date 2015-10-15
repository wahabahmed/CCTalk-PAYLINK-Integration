unit Dispensers;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  MoreDetailUnit, ExtCtrls, StdCtrls, AesImhei, Utility;

type
  TDispensersForm = class(TForm)
    Timer      : TTimer;
    LowerPanel: TPanel;
    TheAddress : TPanel;
    TheCoins   : TPanel;
    TheStatus  : TPanel;
    TheInhibit : TCheckBox;
    ExitButton : TButton;
    Label1     : TLabel;
    TheDispType: TPanel;
    TheContents: TPanel;
    TheValue: TEdit;
    TheSerial: TPanel;
    TheDescPanel: TPanel;
    TheDescription: TLabel;
    TheMoreButton: TButton;
    procedure ExitButtonClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure TimerTimer(Sender: TObject);
    procedure TheInhibitClick(Sender: TObject);
    procedure TheValueChange(Sender: TObject);
    procedure TheMoreButtonClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  DispensersForm: TDispensersForm;

  DispType    : Array [0..32] of TPanel;
  Value       : Array [0..32] of TEdit;
  Address     : Array [0..32] of TPanel;
  Coins       : Array [0..32] of TPanel;
  Contents    : Array [0..32] of TPanel;
  Status      : Array [0..32] of TPanel;
  SerialNo    : Array [0..32] of TPanel;
  DescPanel   : Array [0..32] of TPanel;
  Inhibit     : Array [0..32] of TCheckBox;
  MoreButton  : Array [0..32] of TButton;

  UpdatingNow : Boolean ;

  DispenserHeight : LongInt ;

implementation

{$R *.DFM}


procedure TDispensersForm.ExitButtonClick(Sender: TObject);
begin
    Timer.Enabled := False ;
    Visible := False ;
end;




procedure TDispensersForm.FormCreate(Sender: TObject);
    var i : Integer ;
begin
    UpdatingNow := True ;
    for i := 0 to 32 do
    begin
       CreatePanel(DispType[i], TheDispType , 0, i * 2) ;
       CreateEdit (Value   [i], TheValue    , 0, i * 2) ;
       Value[i].Tag := i ;
       CreatePanel(Address [i], TheAddress  , 0, i * 2) ;
       CreatePanel(Coins   [i], TheCoins    , 0, i * 2) ;
       CreatePanel(Contents[i], TheContents , 0, i * 2) ;
       CreatePanel(Status  [i], TheStatus   , 0, i * 2) ;
       CreatePanel(SerialNo[i], TheSerial   , 0, i * 2) ;
       CreatePanel(DescPanel[i], TheDescPanel , 0, i * 2) ;

       Inhibit[i]            := TCheckBox.Create(TheInhibit.Owner) ;
       Inhibit[i].Parent     := TheInhibit.Parent ;
       Inhibit[i].Height     := TheInhibit.Height ;
       Inhibit[i].Top        := TheInhibit.Top + (TheValue.Height + 4) * i * 2 ;
       Inhibit[i].Width      := TheInhibit.Width ;
       Inhibit[i].Color      := TheInhibit.Color ;
       Inhibit[i].Left       := TheInhibit.Left;
       Inhibit[i].Visible    := True ;
       Inhibit[i].Enabled    := True ;
       Inhibit[i].Tag        := i ;
       Inhibit[i].OnClick    := TheInhibit.OnClick ;


       MoreButton[i]            := TButton.Create(TheMoreButton.Owner) ;
       MoreButton[i].Tag        := i ;
       MoreButton[i].Caption    := TheMoreButton.Caption ;
       MoreButton[i].Parent     := TheMoreButton.Parent ;
       MoreButton[i].Height     := TheMoreButton.Height ;
       MoreButton[i].Top        := TheMoreButton.Top + (TheValue.Height + 4) * i * 2 ;
       MoreButton[i].Width      := TheMoreButton.Width ;
       MoreButton[i].Font       := TheMoreButton.Font ;
       MoreButton[i].Left       := TheMoreButton.Left ;
       MoreButton[i].OnClick    := TheMoreButton.OnClick ;
       MoreButton[i].Visible    := True ;
   end ;


end;

procedure TDispensersForm.FormShow(Sender: TObject);
begin
    TimerTimer(Sender) ;
    Timer.Enabled := True ;
end;



procedure TDispensersForm.TimerTimer(Sender: TObject);
var
    Serial        : LongInt ;
    i             : LongInt ;
    Dispenser     : TDispenserBlock ;
    NewHeight     : LongInt ;
begin
    UpdatingNow := True ;
    Serial := 0 ;
    While ReadDispenserDetails(Serial, Dispenser) do
    begin
       case Dispenser.UnitType of
       DP_AS_WH2:             DispType[Serial].Caption := 'Asahi Seiko Escalator' ;                 
       DP_AZK_HOPPER:         DispType[Serial].Caption := 'Azkoyen Hopper' ;                        
       DP_AZK_HOPPER_U:       DispType[Serial].Caption := 'Azkoyen Hopper U' ;                      
       DP_AZK_HOPPER_UPL:     DispType[Serial].Caption := 'Azkoyen Hopper U+' ;                     
       DP_CC_CASSETTE:        DispType[Serial].Caption := 'Bill to Bill Cassette' ;                 
       DP_CC_GHOST_HOPPER:    DispType[Serial].Caption := 'Ghost (Coin count only)' ;               
       DP_CDM_4000:           DispType[Serial].Caption := 'MFS CDM 4000 Cassette' ;                                                                                      
       DP_FUJITSU_F400:       DispType[Serial].Caption := 'Fujitsu F53 Cassette' ;                                                                                      
       DP_FUJITSU_F53:        DispType[Serial].Caption := 'Fujitsu F53 Cassette' ;                  
       DP_FUJITSU_F56:        DispType[Serial].Caption := 'Fujitsu F56 Cassette' ;                  
       DP_ID003_BOX:          DispType[Serial].Caption := 'ID003 Recycler Note Box' ;               
       DP_INNOV_NV11_RC:      DispType[Serial].Caption := 'NV11 Note Recycler' ;                    
       DP_INNOV_NV200_NOTE:   DispType[Serial].Caption := 'NV200 Note Denomination' ;               
       DP_JCM_VEGA_RC:        DispType[Serial].Caption := 'Vega Note Recycler' ;                    
       DP_MCL_BCR_HOPPER:     DispType[Serial].Caption := 'MCL Bulk Coin Hopper' ;                  
       DP_MCL_CR100_HOPPER:   DispType[Serial].Caption := 'MCL CR100 Hopper' ;                      
       DP_MCL_NR2_HOPPER:     DispType[Serial].Caption := 'MCL NR2 Hopper' ;                        
       DP_MCL_SCH2:           DispType[Serial].Caption := 'MCL Serial Compact Hopper 2' ;           
       DP_MCL_SCH3:           DispType[Serial].Caption := 'MCL Serial Compact Hopper 3' ;           
       DP_MCL_SCH3A:          DispType[Serial].Caption := 'MCL Combi Hopper' ;                      
       DP_MCL_SCH5:           DispType[Serial].Caption := 'MCL Compact Hopper 5 (DES)' ;            
       DP_MCL_SUH1:           DispType[Serial].Caption := 'MCL Serial Universal Hopper' ;           
       DP_MCL_SUH5:           DispType[Serial].Caption := 'MCL Universal Hopper 5 (DES)' ;          
       DP_MDB_LEVEL_2_TUBE:   DispType[Serial].Caption := 'MDB Tube' ;                              
       DP_MDB_TYPE_3_PAYOUT:  DispType[Serial].Caption := 'MDB Payout System' ;                     
       DP_MERKUR_100_PAY:     DispType[Serial].Caption := 'Merkur 100 Dispenser Roll' ;             
       DP_NRI_CURRENZA_H2:    DispType[Serial].Caption := 'NRI Currenza H2' ;                       
       DP_SHOPPER:            DispType[Serial].Caption := 'Innovative Smart Hopper' ;  
       DP_SHOPPER_TOTAL:      DispType[Serial].Caption := 'Innovative Smart Hopper Summary' ;  
       else                                                                                                     
           DispType[Serial].Caption := 'Unknown' ;                                                  
       end ;                                                                                        
                                                                                                         
       if   (DispType[Serial].Caption = 'Unknown')
        and ((Dispenser.UnitType and DP_CCTALK_INTERFACE) <> 0) Then
           DispType[Serial].Caption := 'Unknown cctalk' ;

       DispType[Serial].Visible := True ;
       Value   [Serial].Text    := Format('%d', [Dispenser.Value]) ;
       Value   [Serial].Visible := True ;
       Address [Serial].Caption := Format('%d', [Dispenser.UnitAddress]) ;
       Address [Serial].Visible := True ;
       Coins   [Serial].Caption := Format('%d', [Dispenser.Count]) ;
       Coins   [Serial].Visible := True ;
       case Dispenser.CoinCountStatus of
       DISPENSER_COIN_NONE:     
           Contents[Serial].Caption := '-' ;
           
       DISPENSER_COIN_LOW:      
           Contents[Serial].Caption := 'Low' ;
           
       DISPENSER_COIN_MID:      
           Contents[Serial].Caption := 'Normal' ;
           
       DISPENSER_COIN_HIGH:
           Contents[Serial].Caption := 'High' ;
                               
       DISPENSER_ACCURATE:     
           Contents[Serial].Caption := Format('%d', [Dispenser.CoinCount]) ;
       
       DISPENSER_ACCURATE_FULL:
           Contents[Serial].Caption := 'Full - ' + Format('%d', [Dispenser.CoinCount]) ;
       
       else
           Contents[Serial].Caption := 'Unknown' ;
       end ;
       Contents[Serial].Visible := True ;
       Status  [Serial].Caption := DecodePayStatus(Dispenser.Status) ;
       Status  [Serial].Visible := True ;

       SerialNo[Serial].Visible := True ;
       SerialNo[Serial].Caption := Format('%d', [Dispenser.SerialNumber]) ;

       DescPanel[Serial].Caption := Dispenser.Description ;
       TheDescription.Caption    := Dispenser.Description ;     // Measure the string!
       DescPanel[Serial].Width   := TheDescription.Width + 8 ;
       if (TheDescription.Caption <> '') Then
           DescPanel[Serial].Visible := True
       else
           DescPanel[Serial].Visible := False ;

       Inhibit[Serial].Checked := (Dispenser.Inhibit <> 0) ;
       Inhibit[Serial].Tag     := Serial ;
       Inhibit[Serial].Visible := True ;
       
       Inc(Serial) ;
    end ;

    for i := Serial to 32 do
    begin
       DispType  [i].Visible := False ;
       Value     [i].Visible := False ;
       Address   [i].Visible := False ;
       Coins     [i].Visible := False ;
       Contents  [i].Visible := False ;
       Status    [i].Visible := False ;
       Inhibit   [i].Visible := False ;
       SerialNo  [i].Visible := False ;
       DescPanel [i].Visible := False ;
       MoreButton[i].Visible := false ;
    end ;

    if Serial = 0 then
    begin
        DispType[0].Caption := 'No Dispensors on system' ;
        DispType[0].Visible := True ;
        Serial := 1 ;
    end ;
    NewHeight := Value[Serial].Top + Value[Serial].Height + LowerPanel.Height + 4 ;
    if NewHeight <> DispenserHeight then
    begin
        DispenserHeight := NewHeight ;
        if (NewHeight > 800)
        then
            NewHeight := 800 ;
        Height := NewHeight ;
    end ;
        
    UpdatingNow := False ;

end;

procedure TDispensersForm.TheInhibitClick(Sender: TObject);
var
    Serial    : Integer ;
    Dispenser : TDispenserBlock ;
begin
    with Sender as TCheckBox do
    begin
       Serial := Tag ;
       ReadDispenserDetails(Serial, Dispenser) ;
       if Checked
       then
          Dispenser.Inhibit := 1
       else
          Dispenser.Inhibit := 0 ;
       WriteDispenserDetails(Serial, Dispenser) ;
     end ;
end;




procedure TDispensersForm.TheValueChange(Sender: TObject);
var
    Value         : LongInt ;
    Code          : Integer ;
    Serial        : Integer ;
    Dispenser     : TDispenserBlock ;
begin
    If Not UpdatingNow Then
    begin
        With Sender as TEdit do
        begin
           Serial := Tag ;
           ReadDispenserDetails(Serial, Dispenser) ;
           Dispenser.Status := DISPENSER_REASSIGN_VALUE ;
           val(Text, Value, Code) ;
           Dispenser.Value  := Value ;
           WriteDispenserDetails(Serial, Dispenser) ;
        end ;
    end ;
end;


procedure TDispensersForm.TheMoreButtonClick(Sender: TObject);
begin
    With Sender as TButton do
    begin
           MoreDetail.Top  := Top + Parent.Top ;
           MoreDetail.Left := Left + Parent.Left ;
           MoreDetail.DispenserNumber := Tag ;
           MoreDetail.ShowModal ;
    end ;
end;

end.
