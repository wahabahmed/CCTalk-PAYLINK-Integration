unit Indicators;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls ;

const
  dfltLedLedHeight = 5 ;
  dfltLedLedWidth  = 10 ;
  dfltLedHeight = 40 ;
  dfltLedWidth  = 40 ;
  dfltColorOn   = clLime ;
  dfltColorOff  = clGreen ;
  dfltBarCount  = 10 ;
  dfltBarHeight = 100 ;
  dfltBarWidth  = 30 ;
  dfltBarBorder = 2 ;
  

type
  TSquareLed = Class(TGraphicControl)
  private
// Internal
    LedTop :         Integer ;
    LedLeft :        Integer ;
    BoxTop :         Integer ;
    SetHeight :      Integer ;
    SetWidth :       Integer ;

// Properties
    fLedHeight :     Integer ;
    fLedWidth :      Integer ;
    fColorOn :       TColor ;
    fColorOff :      TColor ;
    fOn :            Boolean ;
    fEnabled :       Boolean ;
    fVisible :       Boolean ;
    fBevel :         Boolean ;
    fCaption :       string ;
    fFont :          TFont ;

// Internal
    procedure SetParameters ;
    procedure Paint ; override ;
    procedure DrawLed ;

// Properties
    Procedure SetFont(Value : TFont);
    Procedure SetLedHeight(Value : Integer);
    Procedure SetLedWidth(Value : Integer);
    Procedure SetColorOn(Value : TColor);
    Procedure SetColorOff(Value : TColor);
    Procedure SetOn(Value : Boolean);
    Procedure SetEnabled(Value : Boolean);
    Procedure SetVisible(Value : Boolean);
    Procedure SetBevel(Value : Boolean);
    Procedure SetCaption(Value : string);
  public
    Constructor Create(Owner : TComponent) ; override ;
    Destructor Destroy ; override ;
  published
    property Top ;
    property Left ;
    property Width  default dfltLedWidth ;
    property Height default dfltLedHeight ;
    property ShowHint ;
    property ParentShowHint ;
    property Hint ;
    property Font :      Tfont   read fFont       write SetFont ;
    property LedHeight : Integer read fLedHeight  write SetLedHeight
                                                  default dfltLedLedHeight ;
    property LedWidth :  Integer read fLedWidth   write SetLedWidth
                                                  default dfltLedLedWidth ;
    property ColorOn :   TColor  read fColorOn    write SetColorOn
                                                  default dfltColorOn ;
    property ColorOff :  TColor  read fColorOff   write SetColorOff
                                                  default dfltColorOff ;
    property On :        Boolean read fOn         write SetOn
                                                  default True ;
    property Enabled :   Boolean read fEnabled    write SetEnabled
                                                  default True ;
    property Visible :   Boolean read fVisible    write SetVisible
                                                  default True ;
    property Bevel :     Boolean read fBevel      write SetBevel
                                                  default True ;
    property Caption :   string  read fCaption    write SetCaption ;
  end ;




  TBarGraph = Class(TCustomControl)
  private
// Internal
    SetHeight :      Integer ;
    SetWidth :       Integer ;
    Leds :           TList ;

// Properties
    fValue :         Integer ;
    fColorOn :       TColor ;
    fColorOff :      TColor ;
    fBorderSize :    Integer ;
    fEnabled :       Boolean ;

// Internal
    procedure SetParameters ;
    procedure SetLeds ;
    procedure Paint ; override ;

// Properties
    Procedure SetValue(Value : Integer);
    Procedure SetColorOn(Value : TColor);
    Procedure SetColorOff(Value : TColor);
    Procedure SetEnabled(Value : Boolean);
    Procedure SetBorderSize(Value : Integer);
    Procedure SetLedCount(Value : Integer);
    function  GetLedCount : Integer;
  public
    Constructor Create(Owner : TComponent) ; override ;
    Destructor Destroy ; override ;
  published
    property Top ;
    property Left ;
    property Width  default dfltBarWidth ;
    property Height default dfltBarHeight ;
    property Visible ;
    property ShowHint ;
    property Hint ;
    property Align ;
    property Value :     Integer read fValue      write SetValue
                                                  default 5 ;
    property Coloron :   TColor  read fColoron    write SetColoron
                                                  default dfltColorOn ;
    property Coloroff :  TColor  read fColoroff   write SetColoroff
                                                  default dfltColorOff ;
    property BorderSize :Integer read fBorderSize write SetBorderSize
                                                  default dfltBarBorder ;
    property LedCount :  Integer read GetLedCount write SetLedCount
                                                  default dfltBarCount ;
    property Enabled :   Boolean read fEnabled    write SetEnabled
                                                  default True ;
  end ;


procedure Register;

implementation

{------------------------------------------------------------------------------}
procedure Register;
begin
  RegisterComponents('Extras', [TSquareLed, TBarGraph]);
end;


{------------------------------------------------------------------------------}
Constructor TSquareLed.Create(Owner : TComponent) ;
begin
  Inherited Create(Owner) ;
  Parent     := Owner as TWinControl ;
  Width      := dfltLedWidth ;
  Height     := dfltLedHeight ;
  fColorOn   := dfltColorOn ;
  fColorOff  := dfltColorOff ;
  fBevel     := True ;
  fVisible   := True ;
  fEnabled   := True ;
  fOn        := True ;
  fLedWidth  := dfltLedLedWidth ;
  fLedHeight := dfltLedLedHeight ;
  fFont      := TFont.Create ;
  fFont.Name := 'MS Sans Serif' ;
end ;



{------------------------------------------------------------------------------}
Destructor TSquareLed.Destroy ;
begin
  fFont.Free ;
  Inherited Destroy ;
end ;



{------------------------------------------------------------------------------}
procedure TSquareLed.SetParameters ;
var
  TheRect : TRect ;
begin
  if Caption <> '' then
  begin
    if Canvas.Font <> fFont
    then
      Canvas.Font := fFont ;
    TheRect := Rect(0, 0, Width, Height) ;
    DrawText(Canvas.Handle, PChar(Caption), Length(Caption), TheRect,
                     DT_WORDBREAK or DT_CENTER or DT_CALCRECT) ;
    BoxTop       := TheRect.Bottom div 2 ;
  end
  else
    BoxTop       := 0 ;

  LedLeft := (Width  - LedWidth)  div 2 ;
  LedTop  := BoxTop + (Height - BoxTop - LedHeight) div 2 ;

  SetHeight := Height ; // Remeber = 'cos they might change!
  SetWidth  := Width ;
end ;



{------------------------------------------------------------------------------}
procedure TSquareLed.Paint ;
var
  TheRect : TRect ;
begin
  if not fVisible and not (csDesigning in ComponentState)
  then
    Exit ;

  if (SetHeight <> Height) or (SetWidth <> Width)
  then
    SetParameters ;

  with Canvas do
  begin
    Brush.Color := clBtnFace ;
    FillRect(Rect(0, 0, Width, Height)) ;

    if fBevel then
    begin
    // Outer Bevel (Down)
      Pen.Width := 1 ;
      Pen.Color := clBtnShadow ;
      MoveTo(0        , Height - 1) ;
      LineTo(0        , BoxTop) ;
      LineTo(Width - 1, BoxTop) ;
      LineTo(Width - 1, BoxTop + 1) ;
      Pen.COlor := clBtnHighLight ;
      LineTo(Width - 1, Height - 1) ;
      LineTo(0        , Height - 1) ;

    // Inner Bevel (Up)
      MoveTo(1        , Height - 2) ;
      LineTo(1        , BoxTop + 1) ;
      LineTo(Width - 2, BoxTop + 1) ;
      LineTo(Width - 2, BoxTop + 2) ;
      Pen.Color := clBtnShadow ;
      LineTo(Width - 2, Height - 2) ;
      LineTo(1        , Height - 2) ;
    end ;

// Caption - Top Contre
    if Caption <> '' then
    begin
      if Font <> fFont
      then
        Font := fFont ;
      TheRect := Rect(0, 0, Width, Height) ;
      DrawText(Handle, PChar(Caption), Length(Caption), TheRect,
                       DT_WORDBREAK or DT_CENTER)
    end ;

    // Led Bevel (Down)
    Pen.Color := clBtnShadow ;
    MoveTo(LedLeft - 1        , LedTop + LedHeight) ;
    LineTo(LedLeft - 1        , LedTop - 1) ;
    LineTo(LedLeft + LedWidth , LedTop - 1) ;
    LineTo(LedLeft + LedWidth , LedTop) ;
    Pen.COlor := clBtnHighLight ;
    LineTo(LedLeft + LedWidth , LedTop + LedHeight) ;
    LineTo(LedLeft - 1        , LedTop + LedHeight) ;

    // Finally!
    DrawLed ;
  end ;
end ;


{------------------------------------------------------------------------------}
// Draw The Led itself
procedure TSquareLed.DrawLed ;
begin
  with Canvas do
  begin
    if fEnabled
    then 
      if fOn
      then
        Brush.Color := colorOn
      else
        Brush.Color := ColorOff
    else
      Brush.Color := clBtnFace ;
    FillRect(Rect(LedLeft, LedTop, LedLeft + LedWidth, LedTop + LedHeight)) ;
  end ;
end ;


{------------------------------------------------------------------------------}
Procedure TSquareLed.SetColorOn(Value : TColor);
Begin
  fColorOn := Value ;
  DrawLed ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetColorOff(Value : TColor);
Begin
  fColorOff := Value ;
  DrawLed ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetEnabled(Value : Boolean);
Begin
  fEnabled := Value ;
  DrawLed ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetOn(Value : Boolean);
Begin
  fOn := Value ;
  DrawLed ;
End;



{------------------------------------------------------------------------------}
Procedure TSquareLed.SetVisible(Value : Boolean);
Begin
  fVisible := Value ;
  Invalidate ;
End;



{------------------------------------------------------------------------------}
Procedure TSquareLed.SetBevel(Value : Boolean);
Begin
  fBevel := Value ;
  SetParameters ;
  Invalidate ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetLedHeight(Value : Integer);
Begin
  fLedHeight := Value ;
  SetParameters ;
  Invalidate ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetLedWidth(Value : Integer);
Begin
  fLedWidth := Value ;
  SetParameters ;
  Invalidate ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetCaption(Value : string);
Begin
  fCaption := Value ;
  SetParameters ;
  Invalidate ;
End;

{------------------------------------------------------------------------------}
Procedure TSquareLed.SetFont(Value : TFont);
Begin
  fFont := Value ;
  SetParameters ;
  Invalidate ;
End;







{------------------------------------------------------------------------------}
Constructor TBarGraph.Create(Owner : TComponent) ;
begin
  Inherited Create(Owner) ;
  Parent      := Owner as TWinControl ;
  Width       := dfltBarWidth ;
  Height      := dfltBarHeight ;
  fColoron    := dfltColorOn ;
  fColoroff   := dfltColorOff ;
  fEnabled    := True ;
  fBorderSize := dfltBarBorder ;
  fValue      := 5 ;
  Leds        := TList.Create ;
  SetLedCount (dfltBarCount) ;
end ;



{------------------------------------------------------------------------------}
Destructor TBarGraph.Destroy ;
var
  i : Integer ;
begin
  for i := 0 to Leds.Count - 1 do
    TSquareLed(Leds[i]).Free ;
  Leds.Free ;
  Inherited Destroy ;
end ;



{------------------------------------------------------------------------------}
procedure TBarGraph.SetParameters ;
var
  i : Integer ;
begin
  SetHeight := Height ; // Remeber = 'cos they might change!
  SetWidth  := Width ;


  // Now work out the LEDs!
  for i := 0 to Leds.Count - 1 do
    with TSquareLed(Leds[i]) do
    begin
      Bevel  := False ;
      Width  := Self.Width ;
      Height := Self.Height div Leds.Count ;
      LedWidth  := Width - fBorderSize * 2 ;
      LedHeight := Height - fBorderSize * 2 ;
      Left := 0 ;
      Top  := i * Height ;
      ParentShowHint := True ;
      ShowHint := False ;
    end ;
end ;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetLeds ;
var
  i : Integer ;
Begin
  for i := 0 to Leds.Count - 1 do
  with TSquareLed(Leds[i]) do
  begin
    ColorOn  := Self.fColorOn ;
    ColorOff := Self.fColorOff ;
    Enabled  := Self.fEnabled ;
    On       := (fValue > (Leds.Count - i - 1)) ;
  end ;
End;


{------------------------------------------------------------------------------}
procedure TBarGraph.Paint ;
begin
  if (SetHeight <> Height) or (SetWidth <> Width)
  then
    SetParameters ;
end ;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetEnabled(Value : Boolean);
Begin
  fEnabled := Value ;
  SetLeds ;
End;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetColorOn(Value : TColor);
Begin
  fColorOn := Value ;
  SetLeds ;
End;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetColorOff(Value : TColor);
Begin
  fColorOff := Value ;
  SetLeds ;
End;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetValue(Value : Integer);
var
  i : Integer ;
Begin
  fValue := Value ;
  for i := 0 to Leds.Count - 1
  do
    TSquareLed(Leds[i]).On := (fValue > (Leds.Count - i - 1)) ;
End;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetLedCount(Value : Integer);
var
  i : Integer ;
Begin
  if Leds.Count = Value
  then
    Exit ;

  if Leds.Count > Value
  then
    for i := Leds.Count - 1 downto Value do
    begin
      TSquareLed(Leds[i]).Free ;
      Leds.Delete(i) ;
    end
  else
    for i := Leds.Count to Value - 1
    do
      Leds.Add(TSquareLed.Create(Self)) ;

  SetLeds ;
  SetParameters ;
  Invalidate ;
End;

Function TBarGraph.GetLedCount : Integer ;
begin ; result := Leds.Count ; end ;


{------------------------------------------------------------------------------}
Procedure TBarGraph.SetBorderSize(Value : Integer);
Begin
  fBorderSize := Value ;
  SetParameters ;
  Invalidate ;
End;


End.
