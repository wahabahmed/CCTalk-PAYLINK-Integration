unit SwitchUnit;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, Indicators, Buttons, ExtCtrls, AesImhei;

type
  TSwitchForm = class(TForm)
    TheButton: TSpeedButton;
    TheLed: TSquareLed;
    TheLabel: TLabel;
    ExitButton: TButton;
    TheTimer: TTimer;
    APanel: TPanel;
    procedure ExitButtonClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure TheButtonClick(Sender: TObject);
    procedure TheTimerTimer(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  SwitchForm   : TSwitchForm;

  Led          : Array [0..15] of TSquareLed ;
  Button       : Array [0..15] of TSpeedButton ;


implementation

{$R *.DFM}


procedure TSwitchForm.FormCreate(Sender: TObject);
   var i : LongInt ;
begin
    for i := 0 to 15 do
    begin
       Led[i]        := TSquareLed.Create(TheLed.Owner) ;
       Led[i].Parent := TheLed.Parent ;
       Led[i].Height := TheLed.Height ;
       Led[i].Top    := TheLed.Top + i * TheLed.Height ;
       Led[i].Width  := TheLed.Width ;
       Led[i].Left   := TheLed.Left ;
       Led[i].LedHeight := TheLed.LedHeight ;
       Led[i].LedWidth := TheLed.LedWidth ;
       Led[i].Show ;
       Button[i]        := TSpeedButton.Create(TheButton.Owner) ;
       Button[i].Tag    := i ;
       Button[i].Caption := IntToStr(i) ;
       Button[i].Parent := TheButton.Parent ;
       Button[i].Height := TheButton.Height ;
       Button[i].Top    := Led[i].Top + (TheLed.Height - TheButton.Height) div 2 ;
       Button[i].Width  := TheButton.Width ;
       Button[i].Left   := TheButton.Left ;
       Button[i].GroupIndex := i + 1 ;
       Button[i].AllowAllUp := True ;
       Button[i].OnClick := TheButton.OnClick ;
       Button[i].Visible:= True ;
    end ;
end;


procedure TSwitchForm.TheButtonClick(Sender: TObject);
begin
    with Sender as TSpeedButton do
    begin
      if Down
      then
         IndicatorOn(Tag)
      else
         IndicatorOff(Tag) ;
    end ;
end;


procedure TSwitchForm.TheTimerTimer(Sender: TObject);
var
   i : Integer ;
begin
   for i := 0 to 15
   do
      Led[i].On := SwitchCloses(i) <> SwitchOpens(i) ;
end;



procedure TSwitchForm.ExitButtonClick(Sender: TObject);
begin
    TheTimer.Enabled := False ;
     Visible := False ;
end;

procedure TSwitchForm.FormShow(Sender: TObject);
begin
    TheTimer.Enabled := True ;
end;

end.
