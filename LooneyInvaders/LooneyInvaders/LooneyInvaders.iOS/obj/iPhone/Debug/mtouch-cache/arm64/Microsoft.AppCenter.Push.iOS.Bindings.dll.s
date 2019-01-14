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
	.byte 8,1
	.asciz "Mono AOT Compiler 5.14.0 (explicit/000780ca82c Tue Nov 20 23:30:52 EST 2018)"
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
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

	.byte 4,8,5
	.asciz "intptr"
LDIE_U:

	.byte 4,8,7
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

	.byte 4,8,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,8,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,8,1
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

	.byte 1,120,30
	.align 3
Lcie0_end:
.text
	.align 3
jit_code_start:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
.text
	.align 4
	.no_dead_strip ApiDefinition_Messaging__cctor
ApiDefinition_Messaging__cctor:
.file 1 "<unknown>"
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #200]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #208]
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #216]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_6:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #224]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_7:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor
Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #240]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #248]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf9002fa0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf9002ba0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_5
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #256]
.word 0xaa1a03e0
bl _p_6
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_8:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #264]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_9:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr
Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #272]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_7
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #280]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800161
.word 0xd2800161
bl _p_8
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_9
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_1@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_1@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_4
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xf94023a2
bl _p_10
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #288]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800f61
.word 0xd2800f61
bl _p_8
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_9
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_2@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_2@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_4
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
.word 0xf94027a2
bl _p_11
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #296]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2801921
.word 0xd2801921
bl _p_8
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_9
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_3@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_3@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_4
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xf94023a2
bl _p_10
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #304]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_4@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_4@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_12
.word 0x53001c00
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400bb1
.word 0xf940da31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #312]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf9401bb1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9002fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_5@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_5@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xaa1a03e2
.word 0xaa0103f9
.word 0xaa0003f8
.word 0xb40001fa
.word 0xaa1903e0
.word 0xaa1803e0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_4
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f7
.word 0x14000008
.word 0xaa1903e0
.word 0xaa1803e0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #320]
.word 0xf9400000
.word 0xaa0003f7
.word 0xaa1903e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1903e0
.word 0xaa1803e1
.word 0xaa1703e2
bl _p_10
.word 0xf9401bb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool
Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #328]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_6@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_6@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0x394043a2
bl _p_13
.word 0xf9400fb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_10:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor
Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #336]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #344]
bl _p_14
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_11:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool
Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #352]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf94017b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0x394083a2
bl _p_15
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_12:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor
Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #360]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #248]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf9002fa0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf9002ba0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_16
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_17
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9425e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #256]
.word 0xaa1a03e0
bl _p_6
.word 0xf9400fb1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9429631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf942a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_13:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #368]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_14:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr
Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #376]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_7
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_15:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification
Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #384]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf94017b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #392]
.word 0xd2801101
.word 0xd2801101
bl _p_18
.word 0xf90023a0
bl _p_19
.word 0xf94017b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
bl _p_9
.word 0xf94017b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_16:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #400]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #408]
.word 0xf9400000
.word 0xf9001ba0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_17:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #416]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #248]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_1
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xf9400340
.word 0xf9400c00
.word 0xf9002fa0
.word 0xf9400fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf9002ba0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_3
.word 0xf9400fb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_4
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_0@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_0@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_5
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #256]
.word 0xaa1a03e0
bl _p_6
.word 0xf9400fb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_18:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #424]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_1
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_19:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #432]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa1
.word 0xaa1903e0
bl _p_7
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0xf9400320
.word 0xf9400c00
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
.word 0xf9400021
bl _p_2
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_3
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_1a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #440]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xd2800019
.word 0xf94013b1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
bl _p_4
.word 0xf90033a0
.word 0xf94013b1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_7@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_7@PAGEOFF
ldr x0, [x0]
.word 0xf90037a0
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
bl _p_5
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #448]
bl _p_20
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf90027a0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94013b1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_1b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #456]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_4
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_8@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_8@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_21
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_1c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #464]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_4
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_9@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_9@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_5
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_21
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_1d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor
Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #472]
.word 0xf9000bb0
.word 0xf9400a11
.word 0xf9000fb1
.word 0xf9400bb1
.word 0xf9402e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #480]
bl _p_14
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #408]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_1e:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #488]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f6
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390303a0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_22
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_9
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_20:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #504]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f6
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390303a0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_24
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_9
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_21:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #512]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f6
.word 0x910103a0
.word 0xf94002c1
.word 0xf90023a1
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390323a0
.word 0xf94017b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_25
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_9
.word 0xaa1403e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94657b4
.word 0xf9403bb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_22:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #520]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f5
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390323a0
.word 0xf94017b1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0x394083a0
.word 0x340000c0
.word 0xf94017b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800036
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xaa1603e2
.word 0xaa1603e2
bl _p_26
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_9
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf94017b1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_23:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90027be
.word 0xa90553b3
.word 0xa9065bb5
.word 0xa90763b7
.word 0xa9086bb9
.word 0xa90973bb
.word 0xf90053bd
.word 0x910003f1
.word 0xf90057b1
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #528]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f6
.word 0x9100e3a0
.word 0xf94002c1
.word 0xf9001fa1
.word 0xf90002c0
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390303a0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
bl _p_27
.word 0x53001c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_9
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9100e3a0
.word 0xf9401fa0
.word 0xf90002c0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941b231
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_24:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b37bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002bbe
.word 0xa905d3b3
.word 0xa906dbb5
.word 0xa907e3b7
.word 0xa908ebb9
.word 0xa909f3bb
.word 0xf90057bd
.word 0x910003f1
.word 0xf9005bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #536]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f5
.word 0x910103a0
.word 0xf94002a1
.word 0xf90023a1
.word 0xf90002a0
.word 0xf94017b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390323a0
.word 0xf94017b1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
bl _p_28
.word 0x53001c00
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #496]
.word 0xb9400000
.word 0x34000260
.word 0xf94017b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
bl _p_23
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_9
.word 0xaa1303e0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf94023a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf94017b1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d3b3
.word 0xa946dbb5
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0

Lme_25:
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl ApiDefinition_Messaging__cctor
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title
bl Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor
bl method_addresses
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 13,12,31,0,68,14,64,157,8,158,7,68,13,29,16,12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10,16
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,16,12,31,0,68,14,80,157,10,158,9,68,13,29,68,154
	.byte 8,13,12,31,0,68,14,80,157,10,158,9,68,13,29,23,12,31,0,68,14,96,157,12,158,11,68,13,29,68,151,10
	.byte 152,9,68,153,8,154,7,16,12,31,0,68,14,112,157,14,158,13,68,13,29,68,153,12,39,12,31,0,68,14,208,1
	.byte 157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10,154,9,68,155,8,156,7
	.byte 39,12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153
	.byte 9,154,8,68,155,7,156,6

.text
	.align 4
plt:
mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_plt:
	.no_dead_strip plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag
plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag:
_p_1:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #552]
br x16
.word 614
	.no_dead_strip plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly
plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly:
_p_2:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #560]
br x16
.word 619
	.no_dead_strip plt_Foundation_NSObject_set_IsDirectBinding_bool
plt_Foundation_NSObject_set_IsDirectBinding_bool:
_p_3:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #568]
br x16
.word 624
	.no_dead_strip plt_Foundation_NSObject_get_Handle
plt_Foundation_NSObject_get_Handle:
_p_4:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #576]
br x16
.word 629
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_5:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #584]
br x16
.word 634
	.no_dead_strip plt_Foundation_NSObject_InitializeHandle_intptr_string
plt_Foundation_NSObject_InitializeHandle_intptr_string:
_p_6:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #592]
br x16
.word 636
	.no_dead_strip plt_Foundation_NSObject__ctor_intptr
plt_Foundation_NSObject__ctor_intptr:
_p_7:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #600]
br x16
.word 641
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_8:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #608]
br x16
.word 646
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_9:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #616]
br x16
.word 666
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_10:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #624]
br x16
.word 694
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_11:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #632]
br x16
.word 696
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_12:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #640]
br x16
.word 698
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_13:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #648]
br x16
.word 700
	.no_dead_strip plt_ObjCRuntime_Class_GetHandle_string
plt_ObjCRuntime_Class_GetHandle_string:
_p_14:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #656]
br x16
.word 702
	.no_dead_strip plt_ObjCRuntime_BaseWrapper__ctor_intptr_bool
plt_ObjCRuntime_BaseWrapper__ctor_intptr_bool:
_p_15:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #664]
br x16
.word 707
	.no_dead_strip plt_Foundation_NSObject_get_SuperHandle
plt_Foundation_NSObject_get_SuperHandle:
_p_16:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #672]
br x16
.word 712
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_17:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #680]
br x16
.word 717
	.no_dead_strip plt_wrapper_alloc_object_AllocSmall_intptr_intptr
plt_wrapper_alloc_object_AllocSmall_intptr_intptr:
_p_18:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #688]
br x16
.word 719
	.no_dead_strip plt_Foundation_You_Should_Not_Call_base_In_This_Method__ctor
plt_Foundation_You_Should_Not_Call_base_In_This_Method__ctor:
_p_19:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #696]
br x16
.word 727
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSDictionary_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSDictionary_intptr:
_p_20:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #704]
br x16
.word 732
	.no_dead_strip plt_Foundation_NSString_FromHandle_intptr
plt_Foundation_NSString_FromHandle_intptr:
_p_21:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #712]
br x16
.word 744
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_22:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #720]
br x16
.word 749
	.no_dead_strip plt__jit_icall_mono_thread_interruption_checkpoint
plt__jit_icall_mono_thread_interruption_checkpoint:
_p_23:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #728]
br x16
.word 751
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_24:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #736]
br x16
.word 789
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_25:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #744]
br x16
.word 791
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_26:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #752]
br x16
.word 793
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_27:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #760]
br x16
.word 795
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_28:
adrp x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #768]
br x16
.word 797
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got, 776
got_end:
.section	__DATA,__objc_selrefs,literal_pointers,no_dead_strip
.align	3
L_OBJC_SELECTOR_REFERENCES_0:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_0
L_OBJC_SELECTOR_REFERENCES_1:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_1
L_OBJC_SELECTOR_REFERENCES_2:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_2
L_OBJC_SELECTOR_REFERENCES_3:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_3
L_OBJC_SELECTOR_REFERENCES_4:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_4
L_OBJC_SELECTOR_REFERENCES_5:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_5
L_OBJC_SELECTOR_REFERENCES_6:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_6
L_OBJC_SELECTOR_REFERENCES_7:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_7
L_OBJC_SELECTOR_REFERENCES_8:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_8
L_OBJC_SELECTOR_REFERENCES_9:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_9
.section	__TEXT,__cstring,cstring_literals
L_OBJC_METH_VAR_NAME_0:
.asciz "init"
L_OBJC_METH_VAR_NAME_1:
.asciz "didFailToRegisterForRemoteNotificationsWithError:"
L_OBJC_METH_VAR_NAME_2:
.asciz "didReceiveRemoteNotification:"
L_OBJC_METH_VAR_NAME_3:
.asciz "didRegisterForRemoteNotificationsWithDeviceToken:"
L_OBJC_METH_VAR_NAME_4:
.asciz "isEnabled"
L_OBJC_METH_VAR_NAME_5:
.asciz "setDelegate:"
L_OBJC_METH_VAR_NAME_6:
.asciz "setEnabled:"
L_OBJC_METH_VAR_NAME_7:
.asciz "customData"
L_OBJC_METH_VAR_NAME_8:
.asciz "message"
L_OBJC_METH_VAR_NAME_9:
.asciz "title"
.section	__DATA,__objc_imageinfo,regular,no_dead_strip
.align	3
L_OBJC_IMAGE_INFO:
.long	0
.long	16
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 3
	.quad Lglobals_hash

	.long 0,0
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "B7C96419-7955-43A0-AF0C-6C9ACC9CE89E"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings"
.data
	.align 3
_mono_aot_file_info:

	.long 144,0
	.align 3
	.quad mono_aot_Microsoft_AppCenter_Push_iOS_Bindings_got
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad jit_code_start
	.align 3
	.quad jit_code_end
	.align 3
	.quad method_addresses
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad mem_end
	.align 3
	.quad assembly_guid
	.align 3
	.quad runtime_version
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad 0
	.align 3
	.quad globals
	.align 3
	.quad assembly_name
	.align 3
	.quad plt
	.align 3
	.quad plt_end
	.align 3
	.quad unwind_info
	.align 3
	.quad unbox_trampolines
	.align 3
	.quad unbox_trampolines_end
	.align 3
	.quad unbox_trampoline_addresses

	.long 68,776,29,38,70,387000831,0,5306
	.long 128,8,8,8,0,25,6168,856
	.long 560,272,0,440,528,328,0,216
	.long 72,848,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
	.byte 205,2,220,102,232,197,176,105,128,52,88,19,205,51,231,15
	.globl _mono_aot_module_Microsoft_AppCenter_Push_iOS_Bindings_info
	.align 3
_mono_aot_module_Microsoft_AppCenter_Push_iOS_Bindings_info:
	.align 3
	.quad _mono_aot_file_info
.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ApiDefinition.Messaging:.cctor"
	.asciz "ApiDefinition_Messaging__cctor"

	.byte 0,0
	.quad ApiDefinition_Messaging__cctor
	.quad Lme_6

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM3=Lfde0_end - Lfde0_start
	.long LDIFF_SYM3
Lfde0_start:

	.long 0
	.align 3
	.quad ApiDefinition_Messaging__cctor

LDIFF_SYM4=Lme_6 - ApiDefinition_Messaging__cctor
	.long LDIFF_SYM4
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde0_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_2:

	.byte 17
	.asciz "System_Object"

	.byte 16,7
	.asciz "System_Object"

LDIFF_SYM5=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM6=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM6
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM7=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_3:

	.byte 8
	.asciz "_Flags"

	.byte 1
LDIFF_SYM8=LDIE_U1 - Ldebug_info_start
	.long LDIFF_SYM8
	.byte 9
	.asciz "Disposed"

	.byte 1,9
	.asciz "NativeRef"

	.byte 2,9
	.asciz "IsDirectBinding"

	.byte 4,9
	.asciz "RegisteredToggleRef"

	.byte 8,9
	.asciz "InFinalizerQueue"

	.byte 16,9
	.asciz "HasManagedRef"

	.byte 32,9
	.asciz "IsCustomType"

	.byte 128,127,0,7
	.asciz "_Flags"

LDIFF_SYM9=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM10=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM10
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM11=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM11
LTDIE_1:

	.byte 5
	.asciz "Foundation_NSObject"

	.byte 40,16
LDIFF_SYM12=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM12
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM13=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM13
	.byte 2,35,16,6
	.asciz "class_handle"

LDIFF_SYM14=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM14
	.byte 2,35,24,6
	.asciz "flags"

LDIFF_SYM15=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 2,35,32,0,7
	.asciz "Foundation_NSObject"

LDIFF_SYM16=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM16
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM17=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM17
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM18=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM18
LTDIE_0:

	.byte 5
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush"

	.byte 40,16
LDIFF_SYM19=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush"

LDIFF_SYM20=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM20
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM21=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM21
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM22=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM22
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:get_ClassHandle"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle
	.quad Lme_7

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM23=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM23
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM24=Lfde1_end - Lfde1_start
	.long LDIFF_SYM24
Lfde1_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle

LDIFF_SYM25=Lme_7 - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_get_ClassHandle
	.long LDIFF_SYM25
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor
	.quad Lme_8

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM26=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM26
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM27=Lfde2_end - Lfde2_start
	.long LDIFF_SYM27
Lfde2_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor

LDIFF_SYM28=Lme_8 - Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor
	.long LDIFF_SYM28
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde2_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_4:

	.byte 5
	.asciz "Foundation_NSObjectFlag"

	.byte 16,16
LDIFF_SYM29=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2,35,0,0,7
	.asciz "Foundation_NSObjectFlag"

LDIFF_SYM30=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM30
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM31=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM31
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM32=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM32
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag
	.quad Lme_9

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM33=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM34=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM34
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM35=Lfde3_end - Lfde3_start
	.long LDIFF_SYM35
Lfde3_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag

LDIFF_SYM36=Lme_9 - Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM36
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr
	.quad Lme_a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM37=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM37
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM38=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM38
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM39=Lfde4_end - Lfde4_start
	.long LDIFF_SYM39
Lfde4_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr

LDIFF_SYM40=Lme_a - Microsoft_AppCenter_Push_iOS_Bindings_MSPush__ctor_intptr
	.long LDIFF_SYM40
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde4_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_5:

	.byte 5
	.asciz "Foundation_NSError"

	.byte 40,16
LDIFF_SYM41=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM41
	.byte 2,35,0,0,7
	.asciz "Foundation_NSError"

LDIFF_SYM42=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM42
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM43=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM43
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM44=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:DidFailToRegisterForRemoteNotificationsWithError"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError
	.quad Lme_b

	.byte 2,118,16,3
	.asciz "error"

LDIFF_SYM45=LTDIE_5_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM45
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM46=Lfde5_end - Lfde5_start
	.long LDIFF_SYM46
Lfde5_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError

LDIFF_SYM47=Lme_b - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidFailToRegisterForRemoteNotificationsWithError_Foundation_NSError
	.long LDIFF_SYM47
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde5_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_6:

	.byte 5
	.asciz "Foundation_NSDictionary"

	.byte 40,16
LDIFF_SYM48=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM48
	.byte 2,35,0,0,7
	.asciz "Foundation_NSDictionary"

LDIFF_SYM49=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM49
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM50=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM50
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM51=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM51
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:DidReceiveRemoteNotification"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary
	.quad Lme_c

	.byte 2,118,16,3
	.asciz "userInfo"

LDIFF_SYM52=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM53=Lfde6_end - Lfde6_start
	.long LDIFF_SYM53
Lfde6_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary

LDIFF_SYM54=Lme_c - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidReceiveRemoteNotification_Foundation_NSDictionary
	.long LDIFF_SYM54
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde6_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_7:

	.byte 5
	.asciz "Foundation_NSData"

	.byte 40,16
LDIFF_SYM55=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 2,35,0,0,7
	.asciz "Foundation_NSData"

LDIFF_SYM56=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM56
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM57=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM57
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM58=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM58
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:DidRegisterForRemoteNotificationsWithDeviceToken"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData
	.quad Lme_d

	.byte 2,118,16,3
	.asciz "deviceToken"

LDIFF_SYM59=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM59
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM60=Lfde7_end - Lfde7_start
	.long LDIFF_SYM60
Lfde7_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData

LDIFF_SYM61=Lme_d - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_DidRegisterForRemoteNotificationsWithDeviceToken_Foundation_NSData
	.long LDIFF_SYM61
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:IsEnabled"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled
	.quad Lme_e

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM62=Lfde8_end - Lfde8_start
	.long LDIFF_SYM62
Lfde8_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled

LDIFF_SYM63=Lme_e - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_IsEnabled
	.long LDIFF_SYM63
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde8_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_8:

	.byte 5
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate"

	.byte 40,16
LDIFF_SYM64=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate"

LDIFF_SYM65=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM65
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM66=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM66
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM67=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM67
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:SetDelegate"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate
	.quad Lme_f

	.byte 2,118,16,3
	.asciz "_delegate"

LDIFF_SYM68=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM69=Lfde9_end - Lfde9_start
	.long LDIFF_SYM69
Lfde9_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate

LDIFF_SYM70=Lme_f - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetDelegate_Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate
	.long LDIFF_SYM70
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,151,10,152,9,68,153,8,154,7
	.align 3
Lfde9_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_10:

	.byte 5
	.asciz "System_ValueType"

	.byte 16,16
LDIFF_SYM71=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM71
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM72=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM72
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM73=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM73
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM74=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM74
LTDIE_9:

	.byte 5
	.asciz "System_Boolean"

	.byte 17,16
LDIFF_SYM75=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM75
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM76=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM76
	.byte 2,35,16,0,7
	.asciz "System_Boolean"

LDIFF_SYM77=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM77
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM78=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM78
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM79=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM79
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:SetEnabled"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool
	.quad Lme_10

	.byte 2,118,16,3
	.asciz "isEnabled"

LDIFF_SYM80=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM81=Lfde10_end - Lfde10_start
	.long LDIFF_SYM81
Lfde10_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool

LDIFF_SYM82=Lme_10 - Microsoft_AppCenter_Push_iOS_Bindings_MSPush_SetEnabled_bool
	.long LDIFF_SYM82
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde10_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPush:.cctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor
	.quad Lme_11

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM83=Lfde11_end - Lfde11_start
	.long LDIFF_SYM83
Lfde11_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor

LDIFF_SYM84=Lme_11 - Microsoft_AppCenter_Push_iOS_Bindings_MSPush__cctor
	.long LDIFF_SYM84
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde11_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_12:

	.byte 5
	.asciz "ObjCRuntime_BaseWrapper"

	.byte 24,16
LDIFF_SYM85=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM85
	.byte 2,35,0,6
	.asciz "<Handle>k__BackingField"

LDIFF_SYM86=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM86
	.byte 2,35,16,0,7
	.asciz "ObjCRuntime_BaseWrapper"

LDIFF_SYM87=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM87
LTDIE_12_POINTER:

	.byte 13
LDIFF_SYM88=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM88
LTDIE_12_REFERENCE:

	.byte 14
LDIFF_SYM89=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM89
LTDIE_11:

	.byte 5
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper"

	.byte 24,16
LDIFF_SYM90=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM90
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper"

LDIFF_SYM91=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM91
LTDIE_11_POINTER:

	.byte 13
LDIFF_SYM92=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM92
LTDIE_11_REFERENCE:

	.byte 14
LDIFF_SYM93=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM93
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegateWrapper:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool
	.quad Lme_12

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM94=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 2,141,16,3
	.asciz "handle"

LDIFF_SYM95=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM95
	.byte 2,141,24,3
	.asciz "owns"

LDIFF_SYM96=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM96
	.byte 2,141,32,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM97=Lfde12_end - Lfde12_start
	.long LDIFF_SYM97
Lfde12_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool

LDIFF_SYM98=Lme_12 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegateWrapper__ctor_intptr_bool
	.long LDIFF_SYM98
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde12_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegate:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor
	.quad Lme_13

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM99=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM99
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM100=Lfde13_end - Lfde13_start
	.long LDIFF_SYM100
Lfde13_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor

LDIFF_SYM101=Lme_13 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor
	.long LDIFF_SYM101
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde13_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegate:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag
	.quad Lme_14

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM102=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM102
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM103=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM103
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM104=Lfde14_end - Lfde14_start
	.long LDIFF_SYM104
Lfde14_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag

LDIFF_SYM105=Lme_14 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM105
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde14_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegate:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr
	.quad Lme_15

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM106=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM107=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM107
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM108=Lfde15_end - Lfde15_start
	.long LDIFF_SYM108
Lfde15_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr

LDIFF_SYM109=Lme_15 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate__ctor_intptr
	.long LDIFF_SYM109
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde15_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_13:

	.byte 5
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification"

	.byte 40,16
LDIFF_SYM110=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification"

LDIFF_SYM111=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM111
LTDIE_13_POINTER:

	.byte 13
LDIFF_SYM112=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM112
LTDIE_13_REFERENCE:

	.byte 14
LDIFF_SYM113=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegate:ReceivedPushNotification"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification
	.quad Lme_16

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM114=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM114
	.byte 2,141,16,3
	.asciz "push"

LDIFF_SYM115=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM115
	.byte 2,141,24,3
	.asciz "pushNotification"

LDIFF_SYM116=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM116
	.byte 2,141,32,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM117=Lfde16_end - Lfde16_start
	.long LDIFF_SYM117
Lfde16_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification

LDIFF_SYM118=Lme_16 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushDelegate_ReceivedPushNotification_Microsoft_AppCenter_Push_iOS_Bindings_MSPush_Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification
	.long LDIFF_SYM118
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:get_ClassHandle"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle
	.quad Lme_17

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM119=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM120=Lfde17_end - Lfde17_start
	.long LDIFF_SYM120
Lfde17_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle

LDIFF_SYM121=Lme_17 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_ClassHandle
	.long LDIFF_SYM121
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde17_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor
	.quad Lme_18

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM122=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM122
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM123=Lfde18_end - Lfde18_start
	.long LDIFF_SYM123
Lfde18_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor

LDIFF_SYM124=Lme_18 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor
	.long LDIFF_SYM124
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde18_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag
	.quad Lme_19

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM125=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM125
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM126=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM126
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM127=Lfde19_end - Lfde19_start
	.long LDIFF_SYM127
Lfde19_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag

LDIFF_SYM128=Lme_19 - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM128
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde19_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:.ctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr
	.quad Lme_1a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM129=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM129
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM130=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM130
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM131=Lfde20_end - Lfde20_start
	.long LDIFF_SYM131
Lfde20_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr

LDIFF_SYM132=Lme_1a - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__ctor_intptr
	.long LDIFF_SYM132
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde20_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:get_CustomData"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData
	.quad Lme_1b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM133=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM133
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM134=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM134
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM135=Lfde21_end - Lfde21_start
	.long LDIFF_SYM135
Lfde21_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData

LDIFF_SYM136=Lme_1b - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_CustomData
	.long LDIFF_SYM136
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,153,12
	.align 3
Lfde21_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:get_Message"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message
	.quad Lme_1c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM137=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM137
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM138=Lfde22_end - Lfde22_start
	.long LDIFF_SYM138
Lfde22_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message

LDIFF_SYM139=Lme_1c - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Message
	.long LDIFF_SYM139
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde22_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:get_Title"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title
	.quad Lme_1d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM140=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM140
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM141=Lfde23_end - Lfde23_start
	.long LDIFF_SYM141
Lfde23_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title

LDIFF_SYM142=Lme_1d - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification_get_Title
	.long LDIFF_SYM142
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde23_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification:.cctor"
	.asciz "Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor
	.quad Lme_1e

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM143=Lfde24_end - Lfde24_start
	.long LDIFF_SYM143
Lfde24_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor

LDIFF_SYM144=Lme_1e - Microsoft_AppCenter_Push_iOS_Bindings_MSPushNotification__cctor
	.long LDIFF_SYM144
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde24_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.quad Lme_20

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM145=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM145
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM146=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM146
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM147=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM147
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM148=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM148
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM149=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM149
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM150=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM150
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM151=Lfde25_end - Lfde25_start
	.long LDIFF_SYM151
Lfde25_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr

LDIFF_SYM152=Lme_20 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.long LDIFF_SYM152
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde25_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.quad Lme_21

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM153=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM153
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM154=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM154
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM155=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM155
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM156=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM156
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM157=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM157
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM158=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM158
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM159=Lfde26_end - Lfde26_start
	.long LDIFF_SYM159
Lfde26_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr

LDIFF_SYM160=Lme_21 - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM160
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde26_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_22

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM161=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM161
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM162=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM162
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM163=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM163
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM164=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM164
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM165=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM165
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM166=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM166
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM167=Lfde27_end - Lfde27_start
	.long LDIFF_SYM167
Lfde27_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM168=Lme_22 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM168
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde27_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_14:

	.byte 5
	.asciz "System_Int32"

	.byte 20,16
LDIFF_SYM169=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM169
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM170=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM170
	.byte 2,35,16,0,7
	.asciz "System_Int32"

LDIFF_SYM171=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM171
LTDIE_14_POINTER:

	.byte 13
LDIFF_SYM172=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM172
LTDIE_14_REFERENCE:

	.byte 14
LDIFF_SYM173=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM173
	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_bool"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.quad Lme_23

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM174=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM174
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM175=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM175
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM176=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM176
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM177=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM177
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM178=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM178
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM179=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM179
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM180=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM180
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM181=Lfde28_end - Lfde28_start
	.long LDIFF_SYM181
Lfde28_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool

LDIFF_SYM182=Lme_23 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.long LDIFF_SYM182
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde28_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.quad Lme_24

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM183=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM183
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM184=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM184
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM185=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM185
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM186=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM186
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM187=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM187
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM188=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM188
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM189=Lfde29_end - Lfde29_start
	.long LDIFF_SYM189
Lfde29_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr

LDIFF_SYM190=Lme_24 - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.long LDIFF_SYM190
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde29_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_25

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM191=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM191
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM192=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM192
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM193=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM193
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM194=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM194
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM195=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM195
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM196=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM196
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM197=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM197
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM198=Lfde30_end - Lfde30_start
	.long LDIFF_SYM198
Lfde30_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM199=Lme_25 - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM199
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde30_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:
