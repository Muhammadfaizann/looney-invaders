.subsections_via_symbols
.section __DWARF, __debug_line,regular,debug
Ldebug_line_section_start:
Ldebug_line_start:
.section __DWARF, __debug_abbrev,regular,debug

	.byte 1,17,1,37,8,3,8,27,8,19,11,17,1,18,1,16,6,0,0,2,46,1,3,8,135,64,8,58,15,59,15,17
	.byte 1,18,1,64,10,0,0,3,5,0,3,8,73,19,2,10,0,0,15,5,0,3,8,73,19,2,6,0,0,4,36,0
	.byte 11,11,62,11,3,8,0,0,5,2,1,3,8,11,15,0,0,17,2,0,3,8,11,15,0,0,6,13,0,3,8,73
	.byte 19,56,10,0,0,7,22,0,3,8,73,19,0,0,8,4,1,3,8,11,15,73,19,0,0,9,40,0,3,8,28,13
	.byte 0,0,10,57,1,3,8,0,0,11,52,0,3,8,73,19,2,10,0,0,12,52,0,3,8,73,19,2,6,0,0,13
	.byte 15,0,73,19,0,0,14,16,0,73,19,0,0,16,28,0,73,19,56,10,0,0,18,46,0,3,8,17,1,18,1,0
	.byte 0,0
.section __DWARF, __debug_info,regular,debug
Ldebug_info_start:

LDIFF_SYM0=Ldebug_info_end - Ldebug_info_begin
	.long LDIFF_SYM0
Ldebug_info_begin:

	.short 2
	.long 0
	.byte 4,1
	.asciz "Mono AOT Compiler 5.14.0 (explicit/000780ca82c Tue Nov 20 23:31:35 EST 2018)"
	.asciz "System.Runtime.Serialization.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0
LDIFF_SYM1=Ldebug_line_start - Ldebug_line_section_start
	.long LDIFF_SYM1
LDIE_I1:

	.byte 4,1,5
	.asciz "sbyte"
LDIE_U1:

	.byte 4,1,7
	.asciz "byte"
LDIE_I2:

	.byte 4,2,5
	.asciz "short"
LDIE_U2:

	.byte 4,2,7
	.asciz "ushort"
LDIE_I4:

	.byte 4,4,5
	.asciz "int"
LDIE_U4:

	.byte 4,4,7
	.asciz "uint"
LDIE_I8:

	.byte 4,8,5
	.asciz "long"
LDIE_U8:

	.byte 4,8,7
	.asciz "ulong"
LDIE_I:

	.byte 4,4,5
	.asciz "intptr"
LDIE_U:

	.byte 4,4,7
	.asciz "uintptr"
LDIE_R4:

	.byte 4,4,4
	.asciz "float"
LDIE_R8:

	.byte 4,8,4
	.asciz "double"
LDIE_BOOLEAN:

	.byte 4,1,2
	.asciz "boolean"
LDIE_CHAR:

	.byte 4,2,8
	.asciz "char"
LDIE_STRING:

	.byte 4,4,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,4,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,4,1
	.asciz "object"
.section __DWARF, __debug_loc,regular,debug
Ldebug_loc_start:
.section __DWARF, __debug_frame,regular,debug
	.align 3

LDIFF_SYM2=Lcie0_end - Lcie0_start
	.long LDIFF_SYM2
Lcie0_start:

	.long -1
	.byte 3
	.asciz ""

	.byte 1,124,14,12,13,0
	.align 2
Lcie0_end:
.text
	.align 3
jit_code_start:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
ut_0:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key

ut_end:
.section __TEXT, __const
_unbox_trampoline_p:

	.long 0
LDIFF_SYM3=ut_end - ut_0
	.long LDIFF_SYM3
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key
System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key:
.file 1 "/Library/Frameworks/Xamarin.iOS.framework/Versions/12.2.1.11/src/Xamarin.iOS/mcs/class/referencesource/System.Runtime.Serialization/System/Runtime/Serialization/CollectionDataContract.cs"
.loc 1 41 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,128,141,229,4,0,141,229,4,0,157,229,0,0,144,229
	.byte 3,223,141,226,0,1,189,232,128,128,189,232

Lme_0:
.text
ut_1:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF
System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF:
.loc 1 42 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,5,223,77,226,0,128,141,229,4,0,141,229,8,16,141,229,8,0,157,229
	.byte 4,16,157,229,0,0,129,229,161,20,160,225,0,32,159,229,0,0,0,234
	.long mono_aot_System_Runtime_Serialization_got - . -4
	.byte 2,32,159,231,2,16,129,224,64,35,160,227,0,32,193,229,5,223,141,226,0,1,189,232,128,128,189,232

Lme_1:
.text
ut_2:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value
System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value:
.loc 1 48 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,128,141,229,4,0,141,229,4,0,157,229,4,0,144,229
	.byte 3,223,141,226,0,1,189,232,128,128,189,232

Lme_2:
.text
ut_3:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF
System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF:
.loc 1 49 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,5,223,77,226,0,128,141,229,4,0,141,229,8,16,141,229,8,0,157,229
	.byte 4,16,157,229,4,0,129,229,1,31,129,226,161,20,160,225,0,32,159,229,0,0,0,234
	.long mono_aot_System_Runtime_Serialization_got - . -4
	.byte 2,32,159,231,2,16,129,224,64,35,160,227,0,32,193,229,5,223,141,226,0,1,189,232,128,128,189,232

Lme_3:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataContractAttribute__ctor
System_Runtime_Serialization_DataContractAttribute__ctor:
.file 2 "/Library/Frameworks/Xamarin.iOS.framework/Versions/12.2.1.11/src/Xamarin.iOS/mcs/class/referencesource/System.Runtime.Serialization/System/Runtime/Serialization/DataContractAttribute.cs"
.loc 2 19 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,3,223,141,226,0,1,189,232,128,128,189,232

Lme_4:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataContractAttribute_set_Namespace_string
System_Runtime_Serialization_DataContractAttribute_set_Namespace_string:
.loc 2 41 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,2,223,77,226,0,96,160,225,0,16,141,229,0,0,157,229,12,0,134,229
	.byte 3,31,134,226,161,20,160,225,0,32,159,229,0,0,0,234
	.long mono_aot_System_Runtime_Serialization_got - . -4
	.byte 2,32,159,231,2,16,129,224,64,35,160,227,0,32,193,229
.loc 2 42 0

	.byte 64,3,160,227,17,0,198,229
.loc 2 43 0

	.byte 2,223,141,226,64,1,189,232,128,128,189,232

Lme_5:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataContractAttribute_set_Name_string
System_Runtime_Serialization_DataContractAttribute_set_Name_string:
.loc 2 56 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,2,223,77,226,0,96,160,225,0,16,141,229,0,0,157,229,8,0,134,229
	.byte 2,31,134,226,161,20,160,225,0,32,159,229,0,0,0,234
	.long mono_aot_System_Runtime_Serialization_got - . -4
	.byte 2,32,159,231,2,16,129,224,64,35,160,227,0,32,193,229
.loc 2 57 0

	.byte 64,3,160,227,16,0,198,229
.loc 2 58 0

	.byte 2,223,141,226,64,1,189,232,128,128,189,232

Lme_6:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataMemberAttribute__ctor
System_Runtime_Serialization_DataMemberAttribute__ctor:
.file 3 "/Library/Frameworks/Xamarin.iOS.framework/Versions/12.2.1.11/src/Xamarin.iOS/mcs/class/referencesource/System.Runtime.Serialization/System/Runtime/Serialization/DataMemberAttribute.cs"
.loc 3 12 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,0,0,157,229,0,31,224,227,16,16,128,229
.loc 3 14 0

	.byte 64,19,160,227,21,16,192,229
.loc 3 18 0

	.byte 3,223,141,226,0,1,189,232,128,128,189,232

Lme_7:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataMemberAttribute_set_Name_string
System_Runtime_Serialization_DataMemberAttribute_set_Name_string:
.loc 3 23 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,2,223,77,226,0,96,160,225,0,16,141,229,0,0,157,229,8,0,134,229
	.byte 2,31,134,226,161,20,160,225,0,32,159,229,0,0,0,234
	.long mono_aot_System_Runtime_Serialization_got - . -4
	.byte 2,32,159,231,2,16,129,224,64,35,160,227,0,32,193,229,64,3,160,227,12,0,198,229,2,223,141,226,64,1,189,232
	.byte 128,128,189,232

Lme_8:
.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool
System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool:
.loc 3 45 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,4,16,205,229,4,16,221,229,0,0,157,229
	.byte 20,16,192,229,3,223,141,226,0,1,189,232,128,128,189,232

Lme_9:
.text
ut_10:

	.byte 8,0,128,226
	b System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime
System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime:
.file 4 "/Library/Frameworks/Xamarin.iOS.framework/Versions/12.2.1.11/src/Xamarin.iOS/mcs/class/referencesource/System.Runtime.Serialization/System/Runtime/Serialization/DateTimeOffsetAdapter.cs"
.loc 4 30 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,5,223,77,226,0,16,141,229,12,0,141,229,12,0,157,229,0,16,144,229
	.byte 4,16,141,229,4,0,144,229,8,0,141,229,0,0,157,229,4,16,157,229,0,16,128,229,8,16,157,229,4,16,128,229
	.byte 5,223,141,226,0,1,189,232,128,128,189,232

Lme_a:
.text
ut_11:

	.byte 8,0,128,226
	b System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime
System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime:
.loc 4 31 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,4,223,77,226,13,176,160,225,0,0,139,229,4,16,139,229,8,32,139,229
	.byte 0,0,155,229,4,16,155,229,0,16,128,229,8,16,155,229,4,16,128,229,4,223,139,226,0,9,189,232,128,128,189,232

Lme_b:
.text
ut_12:

	.byte 8,0,128,226
	b System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes
System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes:
.loc 4 37 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,0,0,157,229,248,0,208,225,3,223,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_c:
.text
ut_13:

	.byte 8,0,128,226
	b System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16
System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16:
.loc 4 38 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,3,223,77,226,0,0,141,229,180,16,205,225,244,16,221,225,0,0,157,229
	.byte 184,16,192,225,3,223,141,226,0,1,189,232,128,128,189,232

Lme_d:
.text
ut_15:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key
System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key:
.loc 1 41 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,48,9,45,233,6,223,77,226,13,176,160,225,4,128,139,229,0,16,139,229,8,0,139,229
	.byte 4,0,155,229
bl _p_1

	.byte 0,80,160,225,0,0,149,229,7,64,128,226,7,64,196,227,4,208,77,224,13,64,160,225,4,0,149,229,64,19,64,226
	.byte 8,0,155,229,1,16,128,224,16,0,149,229,0,0,132,224,8,32,149,229,12,48,149,229,51,255,47,225,16,16,149,229
	.byte 4,0,160,225,1,0,128,224,20,0,139,229,0,0,155,229,16,0,139,229,8,0,149,229,12,0,149,229,4,0,155,229
bl _p_2

	.byte 0,32,160,225,16,0,155,229,20,16,155,229
bl _mono_gsharedvt_value_copy

	.byte 6,223,139,226,48,9,189,232,128,128,189,232

Lme_f:
.text
ut_16:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT
System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT:
.loc 1 42 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,7,223,77,226,13,176,160,225,0,128,139,229,8,0,139,229,12,16,139,229
	.byte 0,0,155,229
bl _p_3

	.byte 0,96,160,225,0,0,150,229,0,31,160,227,0,15,160,227,4,0,139,229,4,0,150,229,64,35,64,226,8,0,155,229
	.byte 2,0,128,224,12,16,155,229,20,16,139,229,16,0,139,229,8,0,150,229,12,0,150,229,0,0,155,229
bl _p_4

	.byte 0,32,160,225,16,0,155,229,20,16,155,229
bl _mono_gsharedvt_value_copy

	.byte 7,223,139,226,64,9,189,232,128,128,189,232

Lme_10:
.text
ut_17:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value
System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value:
.loc 1 48 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,48,9,45,233,6,223,77,226,13,176,160,225,4,128,139,229,0,16,139,229,8,0,139,229
	.byte 4,0,155,229
bl _p_5

	.byte 0,80,160,225,0,0,149,229,7,64,128,226,7,64,196,227,4,208,77,224,13,64,160,225,4,0,149,229,64,19,64,226
	.byte 8,0,155,229,1,16,128,224,16,0,149,229,0,0,132,224,8,32,149,229,12,48,149,229,51,255,47,225,16,16,149,229
	.byte 4,0,160,225,1,0,128,224,20,0,139,229,0,0,155,229,16,0,139,229,8,0,149,229,12,0,149,229,4,0,155,229
bl _p_6

	.byte 0,32,160,225,16,0,155,229,20,16,155,229
bl _mono_gsharedvt_value_copy

	.byte 6,223,139,226,48,9,189,232,128,128,189,232

Lme_11:
.text
ut_18:

	.byte 8,0,128,226
	b System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT

.text
	.align 2
	.no_dead_strip System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT
System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT:
.loc 1 49 0 prologue_end

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,7,223,77,226,13,176,160,225,0,128,139,229,8,0,139,229,12,16,139,229
	.byte 0,0,155,229
bl _p_7

	.byte 0,96,160,225,0,0,150,229,0,31,160,227,0,15,160,227,4,0,139,229,4,0,150,229,64,35,64,226,8,0,155,229
	.byte 2,0,128,224,12,16,155,229,20,16,139,229,16,0,139,229,8,0,150,229,12,0,150,229,0,0,155,229
bl _p_8

	.byte 0,32,160,225,16,0,155,229,20,16,155,229
bl _mono_gsharedvt_value_copy

	.byte 7,223,139,226,64,9,189,232,128,128,189,232

Lme_12:
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key
bl System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF
bl System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value
bl System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF
bl System_Runtime_Serialization_DataContractAttribute__ctor
bl System_Runtime_Serialization_DataContractAttribute_set_Namespace_string
bl System_Runtime_Serialization_DataContractAttribute_set_Name_string
bl System_Runtime_Serialization_DataMemberAttribute__ctor
bl System_Runtime_Serialization_DataMemberAttribute_set_Name_string
bl System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool
bl System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime
bl System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime
bl System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes
bl System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16
bl method_addresses
bl System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key
bl System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT
bl System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value
bl System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:

	.long 0,1,2,3,10,11,12,13
	.long 15,16,17,18
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:
bl ut_0
bl ut_1
bl ut_2
bl ut_3
bl ut_10
bl ut_11
bl ut_12
bl ut_13
bl ut_15
bl ut_16
bl ut_17
bl ut_18

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 3,12,13,0,30,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,80,10,68,14,12,68,8,8,14
	.byte 8,68,11,31,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,56,10,68,14,12,68,8,8,14
	.byte 8,68,11,31,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,60,10,68,14,12,68,8,8,14
	.byte 8,68,11,30,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,68,10,68,14,12,68,8,8,14,8
	.byte 68,11,35,12,13,0,68,14,8,135,2,72,14,16,134,4,136,3,142,1,68,14,24,2,60,10,68,14,16,68,8,6
	.byte 8,8,14,8,68,11,30,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,88,10,68,14,12,68,8
	.byte 8,14,8,68,11,30,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,84,10,68,14,12,68,8,8
	.byte 14,8,68,11,31,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,48,10,68,14,12,68,8,8
	.byte 14,8,68,11,40,12,13,0,68,14,8,135,2,72,14,16,136,4,139,3,142,1,68,14,32,68,13,11,2,32,10,68
	.byte 13,13,14,16,68,8,8,8,11,14,8,68,11,30,12,13,0,68,14,8,135,2,72,14,12,136,3,142,1,68,14,24
	.byte 76,10,68,14,12,68,8,8,14,8,68,11,48,12,13,0,68,14,8,135,2,72,14,24,132,6,133,5,136,4,139,3
	.byte 142,1,68,14,48,68,13,11,2,136,10,68,13,13,14,24,68,8,4,8,5,8,8,8,11,14,8,68,11,44,12,13
	.byte 0,68,14,8,135,2,72,14,20,134,5,136,4,139,3,142,1,68,14,48,68,13,11,2,100,10,68,13,13,14,20,68
	.byte 8,6,8,8,8,11,14,8,68,11

.text
	.align 4
plt:
mono_aot_System_Runtime_Serialization_plt:
	.no_dead_strip plt__rgctx_fetch_0
plt__rgctx_fetch_0:
_p_1:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 100,452
	.no_dead_strip plt__rgctx_fetch_1
plt__rgctx_fetch_1:
_p_2:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 104,491
	.no_dead_strip plt__rgctx_fetch_2
plt__rgctx_fetch_2:
_p_3:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 108,516
	.no_dead_strip plt__rgctx_fetch_3
plt__rgctx_fetch_3:
_p_4:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 112,552
	.no_dead_strip plt__rgctx_fetch_4
plt__rgctx_fetch_4:
_p_5:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 116,577
	.no_dead_strip plt__rgctx_fetch_5
plt__rgctx_fetch_5:
_p_6:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 120,616
	.no_dead_strip plt__rgctx_fetch_6
plt__rgctx_fetch_6:
_p_7:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 124,641
	.no_dead_strip plt__rgctx_fetch_7
plt__rgctx_fetch_7:
_p_8:

	.byte 0,192,159,229,12,240,159,231
	.long mono_aot_System_Runtime_Serialization_got - . + 128,677
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_System_Runtime_Serialization_got, 136
got_end:
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 1, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.section __TEXT, __const
	.align 2
name_0:
	.asciz "_unbox_trampoline_p"
.data
	.align 3
globals:
	.align 2
	.long Lglobals_hash
	.align 2
	.long name_0
	.align 2
	.long _unbox_trampoline_p

	.long 0,0
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "26708177-4495-4302-9B90-8CACB6140F0A"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "System.Runtime.Serialization"
.data
	.align 3
_mono_aot_file_info:

	.long 144,0
	.align 2
	.long mono_aot_System_Runtime_Serialization_got
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long jit_code_start
	.align 2
	.long jit_code_end
	.align 2
	.long method_addresses
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long mem_end
	.align 2
	.long assembly_guid
	.align 2
	.long runtime_version
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long globals
	.align 2
	.long assembly_name
	.align 2
	.long plt
	.align 2
	.long plt_end
	.align 2
	.long unwind_info
	.align 2
	.long unbox_trampolines
	.align 2
	.long unbox_trampolines_end
	.align 2
	.long unbox_trampoline_addresses

	.long 25,136,9,19,66,387000831,0,1526
	.long 128,4,4,8,0,25,2160,624
	.long 416,232,0,336,384,280,0,192
	.long 48,616,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
	.byte 148,109,71,30,123,239,97,100,155,83,208,56,184,202,168,73
	.globl _mono_aot_module_System_Runtime_Serialization_info
	.align 2
_mono_aot_module_System_Runtime_Serialization_info:
	.align 2
	.long _mono_aot_file_info
.section __DWARF, __debug_info,regular,debug
LTDIE_2:

	.byte 17
	.asciz "System_Object"

	.byte 8,7
	.asciz "System_Object"

LDIFF_SYM4=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM5=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM6=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM6
LTDIE_1:

	.byte 5
	.asciz "System_ValueType"

	.byte 8,16
LDIFF_SYM7=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM7
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM8=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM9=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM10=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM10
LTDIE_0:

	.byte 5
	.asciz "System_Runtime_Serialization_KeyValue`2"

	.byte 16,16
LDIFF_SYM11=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM11
	.byte 2,35,0,6
	.asciz "key"

LDIFF_SYM12=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM12
	.byte 2,35,8,6
	.asciz "value"

LDIFF_SYM13=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM13
	.byte 2,35,12,0,7
	.asciz "System_Runtime_Serialization_KeyValue`2"

LDIFF_SYM14=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM14
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM15=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM15
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM16=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM16
	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_REF,_V_REF>:get_Key"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key"

	.byte 1,41
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key
	.long Lme_0

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM17=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM17
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM18=Lfde0_end - Lfde0_start
	.long LDIFF_SYM18
Lfde0_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key

LDIFF_SYM19=Lme_0 - System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Key
	.long LDIFF_SYM19
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,80,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_REF,_V_REF>:set_Key"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF"

	.byte 1,42
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF
	.long Lme_1

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM20=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM20
	.byte 2,125,4,3
	.asciz "value"

LDIFF_SYM21=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM21
	.byte 2,125,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM22=Lfde1_end - Lfde1_start
	.long LDIFF_SYM22
Lfde1_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF

LDIFF_SYM23=Lme_1 - System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Key_K_REF
	.long LDIFF_SYM23
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,56,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_REF,_V_REF>:get_Value"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value"

	.byte 1,48
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value
	.long Lme_2

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM24=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM24
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM25=Lfde2_end - Lfde2_start
	.long LDIFF_SYM25
Lfde2_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value

LDIFF_SYM26=Lme_2 - System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_get_Value
	.long LDIFF_SYM26
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,80,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_REF,_V_REF>:set_Value"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF"

	.byte 1,49
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF
	.long Lme_3

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM27=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM27
	.byte 2,125,4,3
	.asciz "value"

LDIFF_SYM28=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM28
	.byte 2,125,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM29=Lfde3_end - Lfde3_start
	.long LDIFF_SYM29
Lfde3_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF

LDIFF_SYM30=Lme_3 - System_Runtime_Serialization_KeyValue_2_K_REF_V_REF_set_Value_V_REF
	.long LDIFF_SYM30
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,60,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde3_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_4:

	.byte 5
	.asciz "System_Attribute"

	.byte 8,16
LDIFF_SYM31=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM31
	.byte 2,35,0,0,7
	.asciz "System_Attribute"

LDIFF_SYM32=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM32
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM33=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM33
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM34=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM34
LTDIE_5:

	.byte 5
	.asciz "System_Boolean"

	.byte 9,16
LDIFF_SYM35=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM35
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM36=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM36
	.byte 2,35,8,0,7
	.asciz "System_Boolean"

LDIFF_SYM37=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM37
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM38=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM38
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM39=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM39
LTDIE_3:

	.byte 5
	.asciz "System_Runtime_Serialization_DataContractAttribute"

	.byte 20,16
LDIFF_SYM40=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM40
	.byte 2,35,0,6
	.asciz "name"

LDIFF_SYM41=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM41
	.byte 2,35,8,6
	.asciz "ns"

LDIFF_SYM42=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM42
	.byte 2,35,12,6
	.asciz "isNameSetExplicitly"

LDIFF_SYM43=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM43
	.byte 2,35,16,6
	.asciz "isNamespaceSetExplicitly"

LDIFF_SYM44=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2,35,17,0,7
	.asciz "System_Runtime_Serialization_DataContractAttribute"

LDIFF_SYM45=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM45
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM46=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM46
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM47=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM47
	.byte 2
	.asciz "System.Runtime.Serialization.DataContractAttribute:.ctor"
	.asciz "System_Runtime_Serialization_DataContractAttribute__ctor"

	.byte 2,17
	.long System_Runtime_Serialization_DataContractAttribute__ctor
	.long Lme_4

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM48=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM48
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM49=Lfde4_end - Lfde4_start
	.long LDIFF_SYM49
Lfde4_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataContractAttribute__ctor

LDIFF_SYM50=Lme_4 - System_Runtime_Serialization_DataContractAttribute__ctor
	.long LDIFF_SYM50
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,68,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DataContractAttribute:set_Namespace"
	.asciz "System_Runtime_Serialization_DataContractAttribute_set_Namespace_string"

	.byte 2,41
	.long System_Runtime_Serialization_DataContractAttribute_set_Namespace_string
	.long Lme_5

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM51=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM51
	.byte 1,86,3
	.asciz "value"

LDIFF_SYM52=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM53=Lfde5_end - Lfde5_start
	.long LDIFF_SYM53
Lfde5_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataContractAttribute_set_Namespace_string

LDIFF_SYM54=Lme_5 - System_Runtime_Serialization_DataContractAttribute_set_Namespace_string
	.long LDIFF_SYM54
	.byte 68,14,8,135,2,72,14,16,134,4,136,3,142,1,68,14,24,2,60,10,68,14,16,68,8,6,8,8,14,8,68,11
	.align 2
Lfde5_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DataContractAttribute:set_Name"
	.asciz "System_Runtime_Serialization_DataContractAttribute_set_Name_string"

	.byte 2,56
	.long System_Runtime_Serialization_DataContractAttribute_set_Name_string
	.long Lme_6

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM55=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 1,86,3
	.asciz "value"

LDIFF_SYM56=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM57=Lfde6_end - Lfde6_start
	.long LDIFF_SYM57
Lfde6_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataContractAttribute_set_Name_string

LDIFF_SYM58=Lme_6 - System_Runtime_Serialization_DataContractAttribute_set_Name_string
	.long LDIFF_SYM58
	.byte 68,14,8,135,2,72,14,16,134,4,136,3,142,1,68,14,24,2,60,10,68,14,16,68,8,6,8,8,14,8,68,11
	.align 2
Lfde6_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_7:

	.byte 5
	.asciz "System_Int32"

	.byte 12,16
LDIFF_SYM59=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM59
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM60=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 2,35,8,0,7
	.asciz "System_Int32"

LDIFF_SYM61=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM61
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM62=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM62
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM63=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM63
LTDIE_6:

	.byte 5
	.asciz "System_Runtime_Serialization_DataMemberAttribute"

	.byte 24,16
LDIFF_SYM64=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 2,35,0,6
	.asciz "name"

LDIFF_SYM65=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM65
	.byte 2,35,8,6
	.asciz "isNameSetExplicitly"

LDIFF_SYM66=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM66
	.byte 2,35,12,6
	.asciz "order"

LDIFF_SYM67=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM67
	.byte 2,35,16,6
	.asciz "isRequired"

LDIFF_SYM68=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 2,35,20,6
	.asciz "emitDefaultValue"

LDIFF_SYM69=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 2,35,21,0,7
	.asciz "System_Runtime_Serialization_DataMemberAttribute"

LDIFF_SYM70=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM70
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM71=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM71
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM72=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM72
	.byte 2
	.asciz "System.Runtime.Serialization.DataMemberAttribute:.ctor"
	.asciz "System_Runtime_Serialization_DataMemberAttribute__ctor"

	.byte 3,12
	.long System_Runtime_Serialization_DataMemberAttribute__ctor
	.long Lme_7

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM73=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM73
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM74=Lfde7_end - Lfde7_start
	.long LDIFF_SYM74
Lfde7_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataMemberAttribute__ctor

LDIFF_SYM75=Lme_7 - System_Runtime_Serialization_DataMemberAttribute__ctor
	.long LDIFF_SYM75
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,88,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DataMemberAttribute:set_Name"
	.asciz "System_Runtime_Serialization_DataMemberAttribute_set_Name_string"

	.byte 3,23
	.long System_Runtime_Serialization_DataMemberAttribute_set_Name_string
	.long Lme_8

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM76=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM76
	.byte 1,86,3
	.asciz "value"

LDIFF_SYM77=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM77
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM78=Lfde8_end - Lfde8_start
	.long LDIFF_SYM78
Lfde8_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataMemberAttribute_set_Name_string

LDIFF_SYM79=Lme_8 - System_Runtime_Serialization_DataMemberAttribute_set_Name_string
	.long LDIFF_SYM79
	.byte 68,14,8,135,2,72,14,16,134,4,136,3,142,1,68,14,24,2,60,10,68,14,16,68,8,6,8,8,14,8,68,11
	.align 2
Lfde8_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DataMemberAttribute:set_IsRequired"
	.asciz "System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool"

	.byte 3,45
	.long System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool
	.long Lme_9

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM80=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM81=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM81
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM82=Lfde9_end - Lfde9_start
	.long LDIFF_SYM82
Lfde9_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool

LDIFF_SYM83=Lme_9 - System_Runtime_Serialization_DataMemberAttribute_set_IsRequired_bool
	.long LDIFF_SYM83
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,84,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde9_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_9:

	.byte 5
	.asciz "System_Int16"

	.byte 10,16
LDIFF_SYM84=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM84
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM85=LDIE_I2 - Ldebug_info_start
	.long LDIFF_SYM85
	.byte 2,35,8,0,7
	.asciz "System_Int16"

LDIFF_SYM86=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM86
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM87=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM87
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM88=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM88
LTDIE_8:

	.byte 5
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter"

	.byte 20,16
LDIFF_SYM89=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM89
	.byte 2,35,0,6
	.asciz "utcDateTime"

LDIFF_SYM90=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM90
	.byte 2,35,0,6
	.asciz "offsetMinutes"

LDIFF_SYM91=LDIE_I2 - Ldebug_info_start
	.long LDIFF_SYM91
	.byte 2,35,8,0,7
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter"

LDIFF_SYM92=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM92
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM93=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM93
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM94=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 2
	.asciz "System.Runtime.Serialization.DateTimeOffsetAdapter:get_UtcDateTime"
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime"

	.byte 4,30
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime
	.long Lme_a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM95=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM95
	.byte 2,125,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM96=Lfde10_end - Lfde10_start
	.long LDIFF_SYM96
Lfde10_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime

LDIFF_SYM97=Lme_a - System_Runtime_Serialization_DateTimeOffsetAdapter_get_UtcDateTime
	.long LDIFF_SYM97
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,32,2,48,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde10_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DateTimeOffsetAdapter:set_UtcDateTime"
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime"

	.byte 4,31
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime
	.long Lme_b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM98=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM98
	.byte 2,123,0,3
	.asciz "value"

LDIFF_SYM99=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM99
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM100=Lfde11_end - Lfde11_start
	.long LDIFF_SYM100
Lfde11_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime

LDIFF_SYM101=Lme_b - System_Runtime_Serialization_DateTimeOffsetAdapter_set_UtcDateTime_System_DateTime
	.long LDIFF_SYM101
	.byte 68,14,8,135,2,72,14,16,136,4,139,3,142,1,68,14,32,68,13,11,2,32,10,68,13,13,14,16,68,8,8,8
	.byte 11,14,8,68,11
	.align 2
Lfde11_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DateTimeOffsetAdapter:get_OffsetMinutes"
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes"

	.byte 4,37
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes
	.long Lme_c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM102=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM102
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM103=Lfde12_end - Lfde12_start
	.long LDIFF_SYM103
Lfde12_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes

LDIFF_SYM104=Lme_c - System_Runtime_Serialization_DateTimeOffsetAdapter_get_OffsetMinutes
	.long LDIFF_SYM104
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,76,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde12_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.DateTimeOffsetAdapter:set_OffsetMinutes"
	.asciz "System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16"

	.byte 4,38
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16
	.long Lme_d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM105=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM105
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM106=LDIE_I2 - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM107=Lfde13_end - Lfde13_start
	.long LDIFF_SYM107
Lfde13_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16

LDIFF_SYM108=Lme_d - System_Runtime_Serialization_DateTimeOffsetAdapter_set_OffsetMinutes_int16
	.long LDIFF_SYM108
	.byte 68,14,8,135,2,72,14,12,136,3,142,1,68,14,24,84,10,68,14,12,68,8,8,14,8,68,11
	.align 2
Lfde13_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_10:

	.byte 5
	.asciz "System_Runtime_Serialization_KeyValue`2"

	.byte 16,16
LDIFF_SYM109=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM109
	.byte 2,35,0,6
	.asciz "key"

LDIFF_SYM110=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 2,35,8,6
	.asciz "value"

LDIFF_SYM111=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM111
	.byte 2,35,12,0,7
	.asciz "System_Runtime_Serialization_KeyValue`2"

LDIFF_SYM112=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM112
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM113=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM113
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM114=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM114
	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_GSHAREDVT,_V_GSHAREDVT>:get_Key"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key"

	.byte 1,41
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key
	.long Lme_f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM115=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM115
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM116=Lfde14_end - Lfde14_start
	.long LDIFF_SYM116
Lfde14_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key

LDIFF_SYM117=Lme_f - System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Key
	.long LDIFF_SYM117
	.byte 68,14,8,135,2,72,14,24,132,6,133,5,136,4,139,3,142,1,68,14,48,68,13,11,2,136,10,68,13,13,14,24
	.byte 68,8,4,8,5,8,8,8,11,14,8,68,11
	.align 2
Lfde14_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_GSHAREDVT,_V_GSHAREDVT>:set_Key"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT"

	.byte 1,42
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT
	.long Lme_10

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM118=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM118
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM119=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM120=Lfde15_end - Lfde15_start
	.long LDIFF_SYM120
Lfde15_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT

LDIFF_SYM121=Lme_10 - System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Key_K_GSHAREDVT
	.long LDIFF_SYM121
	.byte 68,14,8,135,2,72,14,20,134,5,136,4,139,3,142,1,68,14,48,68,13,11,2,100,10,68,13,13,14,20,68,8
	.byte 6,8,8,8,11,14,8,68,11
	.align 2
Lfde15_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_GSHAREDVT,_V_GSHAREDVT>:get_Value"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value"

	.byte 1,48
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value
	.long Lme_11

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM122=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM122
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM123=Lfde16_end - Lfde16_start
	.long LDIFF_SYM123
Lfde16_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value

LDIFF_SYM124=Lme_11 - System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_get_Value
	.long LDIFF_SYM124
	.byte 68,14,8,135,2,72,14,24,132,6,133,5,136,4,139,3,142,1,68,14,48,68,13,11,2,136,10,68,13,13,14,24
	.byte 68,8,4,8,5,8,8,8,11,14,8,68,11
	.align 2
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Runtime.Serialization.KeyValue`2<K_GSHAREDVT,_V_GSHAREDVT>:set_Value"
	.asciz "System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT"

	.byte 1,49
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT
	.long Lme_12

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM125=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM125
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM126=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM126
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM127=Lfde17_end - Lfde17_start
	.long LDIFF_SYM127
Lfde17_start:

	.long 0
	.align 2
	.long System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT

LDIFF_SYM128=Lme_12 - System_Runtime_Serialization_KeyValue_2_K_GSHAREDVT_V_GSHAREDVT_set_Value_V_GSHAREDVT
	.long LDIFF_SYM128
	.byte 68,14,8,135,2,72,14,20,134,5,136,4,139,3,142,1,68,14,48,68,13,11,2,100,10,68,13,13,14,20,68,8
	.byte 6,8,8,8,11,14,8,68,11
	.align 2
Lfde17_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:
