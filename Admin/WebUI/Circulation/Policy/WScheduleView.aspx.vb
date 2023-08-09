' Class: WAddPatron 
' Puspose: Add new patron
' Creator: Kiemdv
' CreatedDate: 19/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WScheduleView
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        Protected WithEvents lblMon1 As System.Web.UI.WebControls.Label
        Protected WithEvents CheckBox2 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox3 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox4 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox5 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox6 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox7 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox8 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox9 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox10 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox11 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox12 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox13 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox14 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox15 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox16 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox17 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox18 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox19 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox20 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox21 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox22 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox23 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox24 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox25 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox26 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox27 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox28 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox29 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox30 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox31 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox32 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox33 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox34 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents CheckBox35 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox36 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox37 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox38 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox39 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox40 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox41 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox42 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox43 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox44 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox45 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox46 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox47 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox48 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox49 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox50 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox51 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox52 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox53 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox54 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox55 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox56 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox57 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox58 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox59 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox60 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox61 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox62 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox63 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox64 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox65 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox66 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox67 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox68 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox69 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox70 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox71 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox72 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox73 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox74 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox75 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox76 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox77 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox78 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox79 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox80 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox81 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox82 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox83 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox84 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox85 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox86 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox87 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox88 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox89 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox90 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox91 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox92 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox93 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox94 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox95 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox96 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox97 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox98 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox99 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox100 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox101 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox102 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox103 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox104 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox105 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox106 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox107 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox108 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox109 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox110 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox111 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox112 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox113 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox114 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox115 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox116 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox117 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox118 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox119 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox120 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox121 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox122 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox123 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox124 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox125 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox126 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox127 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox128 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox129 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox130 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox131 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox132 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox133 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox134 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox135 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox136 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox137 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox138 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox139 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox140 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox141 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox142 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox143 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox144 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox145 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox146 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox147 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox148 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox149 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox150 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox151 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox152 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox153 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox154 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox155 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox156 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox157 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox158 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox159 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox160 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox161 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox162 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox163 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox164 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox165 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox166 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox167 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox168 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox169 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox170 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox171 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox172 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox173 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox174 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox175 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox176 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox177 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox178 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox179 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox180 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox181 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox182 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox183 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox184 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox185 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox186 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox187 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox188 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox189 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox190 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox191 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox192 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox193 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox194 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox195 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox196 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox197 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox198 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox199 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox200 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox201 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox202 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox203 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox204 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox205 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox206 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox207 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox208 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox209 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox210 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox211 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox212 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox213 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox214 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox215 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox216 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox217 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox218 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox219 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox220 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox221 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox222 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox223 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox224 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox225 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox226 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox227 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox228 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox229 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox230 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox231 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox232 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox233 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox234 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox235 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox236 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox237 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox238 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox239 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox240 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox241 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox242 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox243 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox244 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox245 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox246 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox247 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox248 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox249 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox250 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox251 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox252 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox253 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox254 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox255 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox256 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox257 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox258 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox259 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox260 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox261 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox262 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox263 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox264 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox265 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox266 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox267 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox268 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox269 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox270 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox271 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox272 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox273 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox274 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox275 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox276 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox277 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox278 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox279 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox280 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox281 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox282 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox283 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox284 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox285 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox286 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox287 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox288 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox289 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox290 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox291 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox292 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox293 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox294 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox295 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox296 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox297 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox298 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox299 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox300 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox301 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox302 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox303 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox304 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox305 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox306 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox307 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox308 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox309 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox310 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox311 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox312 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox313 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox314 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox315 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox316 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox317 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox318 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox319 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox320 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox321 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox322 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox323 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox324 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox325 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox326 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox327 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox328 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox329 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox330 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox331 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox332 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox333 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox334 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox335 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox336 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox337 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox338 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox339 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox340 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox341 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox342 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox343 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox344 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox345 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox346 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox347 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox348 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox349 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox350 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox351 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox352 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox353 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox354 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox355 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox356 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox357 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox358 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox359 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox360 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox361 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox362 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox363 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox364 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox365 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox366 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox367 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox368 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox369 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox370 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox371 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox372 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox373 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox374 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox375 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox376 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox377 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox378 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox379 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox380 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox381 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox382 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox383 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox384 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox385 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox386 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox387 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox388 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox389 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox390 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox391 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox392 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox393 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox394 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox395 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox396 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox397 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox398 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox399 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox400 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox401 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox402 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox403 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox404 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox405 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox406 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox407 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox408 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox409 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox410 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox411 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox412 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox413 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox414 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox415 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox416 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox417 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox418 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox419 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Checkbox420 As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Label02 As System.Web.UI.WebControls.Label
        Protected WithEvents Label03 As System.Web.UI.WebControls.Label
        Protected WithEvents Label04 As System.Web.UI.WebControls.Label
        Protected WithEvents Label05 As System.Web.UI.WebControls.Label
        Protected WithEvents Label06 As System.Web.UI.WebControls.Label
        Protected WithEvents Label07 As System.Web.UI.WebControls.Label
        Protected WithEvents Label08 As System.Web.UI.WebControls.Label
        Protected WithEvents Label09 As System.Web.UI.WebControls.Label
        Protected WithEvents Label010 As System.Web.UI.WebControls.Label
        Protected WithEvents Label011 As System.Web.UI.WebControls.Label
        Protected WithEvents Label012 As System.Web.UI.WebControls.Label
        Protected WithEvents Label013 As System.Web.UI.WebControls.Label
        Protected WithEvents Label014 As System.Web.UI.WebControls.Label
        Protected WithEvents Label015 As System.Web.UI.WebControls.Label
        Protected WithEvents Label016 As System.Web.UI.WebControls.Label
        Protected WithEvents Label017 As System.Web.UI.WebControls.Label
        Protected WithEvents Label018 As System.Web.UI.WebControls.Label
        Protected WithEvents Label019 As System.Web.UI.WebControls.Label
        Protected WithEvents Label020 As System.Web.UI.WebControls.Label
        Protected WithEvents Label021 As System.Web.UI.WebControls.Label
        Protected WithEvents Label022 As System.Web.UI.WebControls.Label
        Protected WithEvents Label023 As System.Web.UI.WebControls.Label
        Protected WithEvents Label024 As System.Web.UI.WebControls.Label
        Protected WithEvents Label025 As System.Web.UI.WebControls.Label
        Protected WithEvents Label026 As System.Web.UI.WebControls.Label
        Protected WithEvents Label027 As System.Web.UI.WebControls.Label
        Protected WithEvents Label028 As System.Web.UI.WebControls.Label
        Protected WithEvents Label029 As System.Web.UI.WebControls.Label
        Protected WithEvents Label030 As System.Web.UI.WebControls.Label
        Protected WithEvents Label031 As System.Web.UI.WebControls.Label
        Protected WithEvents Label032 As System.Web.UI.WebControls.Label
        Protected WithEvents Label033 As System.Web.UI.WebControls.Label
        Protected WithEvents Label034 As System.Web.UI.WebControls.Label
        Protected WithEvents Label035 As System.Web.UI.WebControls.Label
        Protected WithEvents Label036 As System.Web.UI.WebControls.Label
        Protected WithEvents Label037 As System.Web.UI.WebControls.Label
        Protected WithEvents Label038 As System.Web.UI.WebControls.Label
        Protected WithEvents Label039 As System.Web.UI.WebControls.Label
        Protected WithEvents Label040 As System.Web.UI.WebControls.Label
        Protected WithEvents Label041 As System.Web.UI.WebControls.Label
        Protected WithEvents Label042 As System.Web.UI.WebControls.Label
        Protected WithEvents Label043 As System.Web.UI.WebControls.Label
        Protected WithEvents Label044 As System.Web.UI.WebControls.Label
        Protected WithEvents Label045 As System.Web.UI.WebControls.Label
        Protected WithEvents Label046 As System.Web.UI.WebControls.Label
        Protected WithEvents Label047 As System.Web.UI.WebControls.Label
        Protected WithEvents Label048 As System.Web.UI.WebControls.Label
        Protected WithEvents Label049 As System.Web.UI.WebControls.Label
        Protected WithEvents Label050 As System.Web.UI.WebControls.Label
        Protected WithEvents Label051 As System.Web.UI.WebControls.Label
        Protected WithEvents Label052 As System.Web.UI.WebControls.Label
        Protected WithEvents Label053 As System.Web.UI.WebControls.Label
        Protected WithEvents Label054 As System.Web.UI.WebControls.Label
        Protected WithEvents Label055 As System.Web.UI.WebControls.Label
        Protected WithEvents Label056 As System.Web.UI.WebControls.Label
        Protected WithEvents Label057 As System.Web.UI.WebControls.Label
        Protected WithEvents Label058 As System.Web.UI.WebControls.Label
        Protected WithEvents Label059 As System.Web.UI.WebControls.Label
        Protected WithEvents Label060 As System.Web.UI.WebControls.Label
        Protected WithEvents Label061 As System.Web.UI.WebControls.Label
        Protected WithEvents Label062 As System.Web.UI.WebControls.Label
        Protected WithEvents Label063 As System.Web.UI.WebControls.Label
        Protected WithEvents Label064 As System.Web.UI.WebControls.Label
        Protected WithEvents Label065 As System.Web.UI.WebControls.Label
        Protected WithEvents Label066 As System.Web.UI.WebControls.Label
        Protected WithEvents Label067 As System.Web.UI.WebControls.Label
        Protected WithEvents Label068 As System.Web.UI.WebControls.Label
        Protected WithEvents Label069 As System.Web.UI.WebControls.Label
        Protected WithEvents Label070 As System.Web.UI.WebControls.Label
        Protected WithEvents Label071 As System.Web.UI.WebControls.Label
        Protected WithEvents Label072 As System.Web.UI.WebControls.Label
        Protected WithEvents Label073 As System.Web.UI.WebControls.Label
        Protected WithEvents Label074 As System.Web.UI.WebControls.Label
        Protected WithEvents Label075 As System.Web.UI.WebControls.Label
        Protected WithEvents Label076 As System.Web.UI.WebControls.Label
        Protected WithEvents Label077 As System.Web.UI.WebControls.Label
        Protected WithEvents Label078 As System.Web.UI.WebControls.Label
        Protected WithEvents Label079 As System.Web.UI.WebControls.Label
        Protected WithEvents Label080 As System.Web.UI.WebControls.Label
        Protected WithEvents Label081 As System.Web.UI.WebControls.Label
        Protected WithEvents Label082 As System.Web.UI.WebControls.Label
        Protected WithEvents Label083 As System.Web.UI.WebControls.Label
        Protected WithEvents Label084 As System.Web.UI.WebControls.Label
        Protected WithEvents Label085 As System.Web.UI.WebControls.Label
        Protected WithEvents Label086 As System.Web.UI.WebControls.Label
        Protected WithEvents Label087 As System.Web.UI.WebControls.Label
        Protected WithEvents Label088 As System.Web.UI.WebControls.Label
        Protected WithEvents Label089 As System.Web.UI.WebControls.Label
        Protected WithEvents Label090 As System.Web.UI.WebControls.Label
        Protected WithEvents Label091 As System.Web.UI.WebControls.Label
        Protected WithEvents Label092 As System.Web.UI.WebControls.Label
        Protected WithEvents Label093 As System.Web.UI.WebControls.Label
        Protected WithEvents Label094 As System.Web.UI.WebControls.Label
        Protected WithEvents Label095 As System.Web.UI.WebControls.Label
        Protected WithEvents Label096 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon8 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon9 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon10 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon11 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMon12 As System.Web.UI.WebControls.Label
        Protected WithEvents Label505 As System.Web.UI.WebControls.Label
        Protected WithEvents Label As System.Web.UI.WebControls.Label
        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBSchedule As New clsBSchedule
        Private objBUserLocation As New clsBUserLocation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not IsPostBack Then
                Call BindData()
                Call BindCalendar()
                Call LoadLocationShedule()
            End If
            Call BindJS()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBUserLocation object
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.UserID = Session("UserID")
            Call objBUserLocation.Initialize()

            ' Init objBSchedule object
            objBSchedule.InterfaceLanguage = Session("InterfaceLanguage")
            objBSchedule.ConnectionString = Session("ConnectionString")
            objBSchedule.DBServer = Session("DBServer")
            Call objBSchedule.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("Common", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Private", "<script language = 'javascript' src = '../Js/Policy/WWorkingUpdate.js'></script>")

            lnkNext.Attributes.Add("onclick", "JavaScript:if (document.forms[0].ddlYear.selectedIndex == 15) return false; ")
            lnkPrevious.Attributes.Add("onclick", "JavaScript:if (document.forms[0].ddlYear.selectedIndex == 0) return false; ")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intCount As Integer

            ' Get locations
            tblTemp = objBUserLocation.GetUserLocations(2)
            If Not tblTemp Is Nothing Then
                tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
            End If
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then

                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "LOCNAME"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()

                    For intCount = Now.Year - 5 To Now.Year - 1
                        ddlYear.Items.Add(intCount)
                    Next
                    For intCount = Now.Year To Now.Year + 10
                        ddlYear.Items.Add(intCount)
                    Next
                    ddlYear.SelectedIndex = 5
                End If
            End If
        End Sub

        ' Method: LoadLocationShedule
        Private Sub LoadLocationShedule()
            Dim intLocationID As Integer = 0
            Dim intYear As Integer = ddlYear.SelectedItem.Text
            Dim dtbSchedule As New DataTable
            Dim ctlItem, ctl, ctlFind As Control
            Dim labelFind As Label

            If IsNumeric(ddlLocation.SelectedValue) Then
                intLocationID = ddlLocation.SelectedValue
            End If

            ' Set default checked = false for all CheckBox
            For Each ctlItem In Page.Controls
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For Each ctl In ctlItem.Controls
                        If TypeOf (ctl) Is WebControl Then
                            If ctl.GetType.ToString = "System.Web.UI.WebControls.Label" Then
                                labelFind = CType(ctl, Label)
                                If Left(labelFind.ID, 3) <> "lbl" Then
                                    labelFind.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            Dim dtDate As Date
            Dim intFirstWeekDay As Integer
            Dim dtOffday As Date
            Dim intCount, intMon, intDay, intWeekDay As Integer

            objBSchedule.LocationID = intLocationID
            dtbSchedule = objBSchedule.GetSchedule(False)
            If Not dtbSchedule Is Nothing Then
                If dtbSchedule.Rows.Count > 0 Then
                    For intCount = 0 To dtbSchedule.Rows.Count - 1
                        dtOffday = dtbSchedule.Rows(intCount).Item("OffDay")
                        If Year(dtOffday) = intYear Then
                            intMon = Month(dtOffday)
                            intDay = Day(dtOffday)
                            Try
                                dtDate = "1/" & intMon & "/" & intYear
                            Catch ex As Exception
                                dtDate = intMon & "/1/" & intYear
                            End Try
                            intFirstWeekDay = Weekday(dtDate)
                            ' Set checked = true for CheckBox that is offday
                            ctlFind = ctlItem.FindControl("LABEL" & CStr(intFirstWeekDay + intDay - 1 + ((intMon - 1) * 42)))
                            labelFind = CType(ctlFind, Label)
                            labelFind.ForeColor = Color.Red
                        End If
                    Next
                End If
                dtbSchedule = Nothing
            End If
        End Sub

        ' Method: BindCalendar
        Private Sub BindCalendar()
            Dim intYear As Integer = ddlYear.SelectedItem.Text
            Dim ctlItem, ctl, ctlFind As Control
            Dim labelFind As Label

            ' Set default visible, checked = false for all CheckBox
            For Each ctlItem In Page.Controls
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For Each ctl In ctlItem.Controls
                        If TypeOf (ctl) Is WebControl Then
                            If ctl.GetType.ToString = "System.Web.UI.WebControls.Label" Then
                                labelFind = CType(ctl, Label)
                                If Left(labelFind.ID, 3) <> "lbl" Then
                                    labelFind.Visible = False
                                    labelFind.ForeColor = Color.Blue
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            Dim dtDate As Date
            Dim intWeekDay, intFirstWeekDay As Integer
            Dim i, j As Integer
            For i = 1 To 12
                For j = 1 To GetDaysInMonth(i, intYear)
                    Try
                        dtDate = j & "/" & i & "/" & intYear
                    Catch ex As Exception
                        dtDate = i & "/" & j & "/" & intYear
                    End Try
                    intWeekDay = Weekday(dtDate)
                    If j = 1 Then
                        intFirstWeekDay = intWeekDay
                    End If
                    ' Set visible = true for CheckBox that is really day
                    ctlFind = ctlItem.FindControl("LABEL" & CStr(intFirstWeekDay + j - 1 + ((i - 1) * 42)))
                    labelFind = CType(ctlFind, Label)
                    labelFind.Visible = True
                    labelFind.Text = j
                Next
            Next
        End Sub

        ' Method: GetDaysInMonth
        Function GetDaysInMonth(ByVal intMonth As Integer, ByVal intYear As Integer)
            Select Case intMonth
                Case 1, 3, 5, 7, 8, 10, 12
                    GetDaysInMonth = 31
                Case 4, 6, 9, 11
                    GetDaysInMonth = 30
                Case 2
                    If IsDate("February 29, " & intYear) Then
                        GetDaysInMonth = 29
                    Else
                        GetDaysInMonth = 28
                    End If
            End Select
        End Function

        ' Event: ddlYear_SelectedIndexChanged
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            Try
                Call BindCalendar()
                Call LoadLocationShedule()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: ddlLocation_SelectedIndexChanged
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Call LoadLocationShedule()
        End Sub

        ' Event: lnkNext_Click
        Private Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
            Try
                ddlYear.SelectedIndex = ddlYear.SelectedIndex + 1
                Call BindCalendar()
                Call LoadLocationShedule()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: lnkPrevious_Click
        Private Sub lnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
            ddlYear.SelectedIndex = ddlYear.SelectedIndex - 1
            Call BindCalendar()
            Call LoadLocationShedule()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBSchedule Is Nothing Then
                    objBSchedule.Dispose(True)
                    objBSchedule = Nothing
                End If
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace