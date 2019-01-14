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
	.asciz "NotificationCenter.dll"
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
	.no_dead_strip NotificationCenter_Notification__ctor_object_object
NotificationCenter_Notification__ctor_object_object:
.file 1 "<unknown>"
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bb8
.word 0xaa0003f8
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #200]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf94017b1
.word 0xf9403e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf94017b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9400fa0
.word 0xf9000b00
.word 0x91004301
.word 0xd349fc21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.word 0xf94017b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf94013a0
.word 0xf9000f00
.word 0x91006301
.word 0xd349fc21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb8
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_0:
.text
	.align 4
	.no_dead_strip NotificationCenter_Notification_get_Sender
NotificationCenter_Notification_get_Sender:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #208]
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
.word 0xf9400fa0
.word 0xf9400800
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_1:
.text
	.align 4
	.no_dead_strip NotificationCenter_Notification_get_Message
NotificationCenter_Notification_get_Message:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #216]
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
.word 0xf9400fa0
.word 0xf9400c00
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_2:
.text
	.align 4
	.no_dead_strip NotificationCenter_Notification_get_Empty
NotificationCenter_Notification_get_Empty:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bba

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #224]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xd280001a
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
.word 0xf9400fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0xd2800000

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #232]
.word 0xd2800401
.word 0xd2800401
bl _p_1
.word 0xf9001ba0
.word 0xd2800001
.word 0xd2800002
bl _p_2
.word 0xf9400fb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa0003fa
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xf9400fb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_3:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager__ctor
NotificationCenter_NotificationCenterManager__ctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
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
.word 0xf9400fb1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #248]
.word 0xd2800a01
.word 0xd2800a01
bl _p_1
.word 0xf9001ba0
bl _p_3
.word 0xf9400fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9000b40
.word 0x91004341
.word 0xd349fc21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.word 0xf9400fb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_4:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager_get_Instance
NotificationCenter_NotificationCenterManager_get_Instance:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #256]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd280001a
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
.word 0xf9401bb1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #264]
.word 0xf9400000
.word 0xaa0003f9
.word 0xaa1903e0
.word 0xaa1903e1
.word 0xaa0003f8
.word 0xb5000379
.word 0xaa1803e0
.word 0xf9401bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #272]
.word 0xd2800301
.word 0xd2800301
bl _p_1
.word 0xf9002ba0
bl _p_4
.word 0xf9401bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x1, [x16, #264]
.word 0xf9000037
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803fa
.word 0xf9401bb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_5:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #280]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xf9402bb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0x53001c00
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x53001c00
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x340002d6
.word 0xf9402bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800021
.word 0xd2800021
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402bb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800000
.word 0xeb00033f
.word 0x9a9f17e0
.word 0x53001c00
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x340002d5
.word 0xf9402bb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800021
.word 0xd2800021
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9400b02
.word 0xaa1a03e0
.word 0xaa0203e0
.word 0xaa1a03e1
.word 0xf9400042
.word 0xf9407c50
.word 0xd63f0200
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000173
.word 0xf9400260
.word 0xf9400000
.word 0xf9400800
.word 0xf9400400

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x1, [x16, #288]
.word 0xeb01001f
.word 0x10000011
.word 0x54000d01
.word 0xaa1303e0
.word 0xaa1303f7
.word 0xf9402bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xd2800000
.word 0xeb00027f
.word 0x9a9f17e0
.word 0x53001c00
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x34000634
.word 0xf9402bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #296]
.word 0xd2800401
.word 0xd2800401
bl _p_1
.word 0xf9003ba0
bl _p_8
.word 0xf9402bb1
.word 0xf942c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9400b03
.word 0xaa1a03e0
.word 0xaa1703e0
.word 0xaa0303e0
.word 0xaa1a03e1
.word 0xaa1703e2
.word 0xf9400063
.word 0xf9409870
.word 0xd63f0200
.word 0xf9402bb1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9432231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1903e0
.word 0xaa1703e0
.word 0xaa1903e1
.word 0x394002fe
bl _p_9
.word 0xf9402bb1
.word 0xf9437a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9438a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9439a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_10

Lme_6:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xf9001bb7
.word 0xa903ebb9
.word 0xf90027a0
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #304]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xf9402bb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0x53001c00
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x53001c00
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x340002d6
.word 0xf9402bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28005e1
.word 0xd28005e1
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402bb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xd2800000
.word 0xeb00033f
.word 0x9a9f17e0
.word 0x53001c00
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x340002d5
.word 0xf9402bb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800021
.word 0xd2800021
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9400802
.word 0xaa1a03e0
.word 0xaa0203e0
.word 0xaa1a03e1
.word 0xf9400042
.word 0xf9407c50
.word 0xd63f0200
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000173
.word 0xf9400260
.word 0xf9400000
.word 0xf9400800
.word 0xf9400400

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x1, [x16, #288]
.word 0xeb01001f
.word 0x10000011
.word 0x540007a1
.word 0xaa1303e0
.word 0xaa1303f7
.word 0xf9402bb1
.word 0xf9424231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xd2800000
.word 0xeb00027f
.word 0x9a9f97e0
.word 0x53001c00
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x34000314
.word 0xf9402bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1903e0
.word 0xaa1703e0
.word 0xaa1903e1
.word 0x394002fe
bl _p_11
.word 0x53001c00
.word 0xf9402bb1
.word 0xf942be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xf9401bb7
.word 0xa943ebb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_10

Lme_7:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification
NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xf9001bb7
.word 0xa903ebb9
.word 0xf90027a0
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #312]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0x910203a0
.word 0xd2800000
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xd2800013
.word 0xf9402bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_5
.word 0x53001c00
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94063a0
.word 0x53001c00
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x34000356
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28005e1
.word 0xd28005e1
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xd2800000
.word 0xeb00035f
.word 0x9a9f17e0
.word 0x53001c00
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0x34000355
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2800aa1
.word 0xd2800aa1
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9400802
.word 0xaa1903e0
.word 0xaa0203e0
.word 0xaa1903e1
.word 0xf9400042
.word 0xf9407c50
.word 0xd63f0200
.word 0xf9004fa0
.word 0xf9402bb1
.word 0xf9425631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
.word 0xb4000180
.word 0xf9404fa0
.word 0xf9400000
.word 0xf9400000
.word 0xf9400800
.word 0xf9400400

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x1, [x16, #288]
.word 0xeb01001f
.word 0x10000011
.word 0x540018c1
.word 0xf9404fa0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf942a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xd2800000
.word 0xeb0002ff
.word 0x9a9f97e0
.word 0x53001c00
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf942ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x34001434
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9430231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x9101a3a0
.word 0xaa0003e8
.word 0xaa1703e0
.word 0x394002fe
bl _p_12
.word 0xf9402bb1
.word 0xf9433a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0x910203a0
.word 0xf94037a0
.word 0xf90043a0
.word 0xf9403ba0
.word 0xf90047a0
.word 0xf9403fa0
.word 0xf9004ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9437a31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000033
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9439e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910203a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_13
.word 0xf9006ba0
.word 0xf9402bb1
.word 0xf943c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf90067a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf943e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94067a2
.word 0xaa0203e0
.word 0xf90063a0
.word 0xaa1a03e0
.word 0xaa0203e0
.word 0xaa1a03e1
.word 0xf9400c50
.word 0xd63f0200
.word 0xf94063a0
.word 0xf9402bb1
.word 0xf9442631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9443631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9444631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9446631
.word 0xb4000051
.word 0xd63f0220
.word 0x910203a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_14
.word 0x53001c00
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf9449231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94063a0
.word 0x35fff740
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf90053bf
.word 0x94000005
.word 0xf94053a0
.word 0xb4000040
bl _p_15
.word 0x14000019
.word 0xf9005fbe
.word 0xf9402bb1
.word 0xf944e631
.word 0xb4000051
.word 0xd63f0220
.word 0x910203a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_16
.word 0xf9402bb1
.word 0xf9450a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9451a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9452a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405fbe
.word 0xd61f03c0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9455231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9457231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9458231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xf9401bb7
.word 0xa943ebb9
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_10

Lme_8:
.text
	.align 4
	.no_dead_strip NotificationCenter_NotificationCenterManager_PostNotification_string
NotificationCenter_NotificationCenterManager_PostNotification_string:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xa90263b7
.word 0xf9001bba
.word 0xf9001fa0
.word 0xaa0103fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #328]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xd2800018
.word 0xd2800017
.word 0xd2800016
.word 0x9101c3a0
.word 0xd2800000
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047bf
.word 0xf94023b1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_5
.word 0x53001c00
.word 0xf9006ba0
.word 0xf94023b1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0x53001c00
.word 0xaa0003f7
.word 0xf94023b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0x34000357
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28005e1
.word 0xd28005e1
bl _p_6
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf9400802
.word 0xaa1a03e0
.word 0xaa0203e0
.word 0xaa1a03e1
.word 0xf9400042
.word 0xf9407c50
.word 0xd63f0200
.word 0xaa0003f5
.word 0xf94023b1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000175
.word 0xf94002a0
.word 0xf9400000
.word 0xf9400800
.word 0xf9400400

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x1, [x16, #288]
.word 0xeb01001f
.word 0x10000011
.word 0x54002081
.word 0xaa1503e0
.word 0xaa1503f8
.word 0xf94023b1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xd2800000
.word 0xeb0002bf
.word 0x9a9f97e0
.word 0x53001c00
.word 0xaa0003f6
.word 0xf94023b1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x34001c16
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910163a0
.word 0xaa0003e8
.word 0xaa1803e0
.word 0x3940031e
bl _p_12
.word 0xf94023b1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0x910163a0
.word 0x9101c3a0
.word 0xf9402fa0
.word 0xf9003ba0
.word 0xf94033a0
.word 0xf9003fa0
.word 0xf94037a0
.word 0xf90043a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000072
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf942d631
.word 0xb4000051
.word 0xd63f0220
.word 0x9101c3a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_13
.word 0xf9006ba0
.word 0xf94023b1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf90047a0
.word 0xf94023b1
.word 0xf9431631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9433631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9434631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xf90073a0
bl _p_17
.word 0xf9006fa0
.word 0xf94023b1
.word 0xf9436631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406fa1
.word 0xf94073a2
.word 0xaa0203e0
.word 0xf9006ba2
.word 0xf9400c50
.word 0xd63f0200
.word 0xf9406ba0
.word 0xf94023b1
.word 0xf9439231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf943a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf943b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000026
.word 0xf9004fa0
.word 0xf9404fa0
.word 0xf94023b1
.word 0xf943de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf943ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #336]
bl _p_18
.word 0xf94023b1
.word 0xf9440e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9441e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9442e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9443e31
.word 0xb4000051
.word 0xd63f0220
bl _p_19
.word 0xf90067a0
.word 0xf94067a0
.word 0xb4000060
.word 0xf94067a0
bl _p_7
.word 0x14000001
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9447a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9449a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101c3a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_14
.word 0x53001c00
.word 0xf9006ba0
.word 0xf94023b1
.word 0xf944c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0x35ffef60
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf944ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9004bbf
.word 0x94000005
.word 0xf9404ba0
.word 0xb4000040
bl _p_15
.word 0x14000019
.word 0xf90063be
.word 0xf94023b1
.word 0xf9451a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101c3a0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x15, [x16, #320]
bl _p_16
.word 0xf94023b1
.word 0xf9453e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9454e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9455e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94063be
.word 0xd61f03c0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9458631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf945a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf945b631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xa94263b7
.word 0xf9401bba
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_10

Lme_9:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF
System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF:
.file 2 "/Library/Frameworks/Xamarin.iOS.framework/Versions/12.2.1.11/src/Xamarin.iOS/mcs/class/corlib/System/Array.cs"
.loc 2 70 0 prologue_end
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xf9002baf
.word 0xaa0003fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #344]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf9400fb1
.word 0xf9403a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb9801b40
.word 0xf90033a0
.word 0xf9400fb1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0x350001c0
.loc 2 71 0
.word 0xf9400fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_20
.word 0x3980b410
.word 0xb5000050
bl _p_21
.word 0xf9402ba0
bl _p_22
.word 0xf9400000
.word 0x14000033
.loc 2 73 0
.word 0xf9400fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0x910103a0
.word 0xd2800000
.word 0xf90023a0
.word 0xf90027a0
.word 0x910103a0
.word 0xf90033a0
.word 0xf9402ba0
bl _p_23
.word 0xaa0003ef
.word 0xf94033a0
.word 0xaa1a03e1
bl _p_24
.word 0x910103a0
.word 0x9100c3a0
.word 0xf94023a0
.word 0xf9001ba0
.word 0xf94027a0
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_23
.word 0xd2800401
.word 0xd2800401
bl _p_1
.word 0x9100c3a1
.word 0x91004003
.word 0xaa0303e1
.word 0xf9401ba2
.word 0xf9000062
.word 0xd349fc23
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0063

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x4, [x16, #16]
.word 0x8b040063
.word 0xd280003e
.word 0x3900007e
.word 0x91002021
.word 0xf9401fa2
.word 0xf9000022
.word 0xf9400fb1
.word 0xf9418a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_f:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_get_Count
System_Array_InternalArray__ICollection_get_Count:
.loc 2 60 0 prologue_end
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #352]
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
.word 0xf9400ba0
.word 0xb9801800
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_10:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_get_IsReadOnly
System_Array_InternalArray__ICollection_get_IsReadOnly:
.loc 2 65 0 prologue_end
.word 0xa9bd7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #360]
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
.word 0xd2800020
.word 0xd2800020
.word 0xf9400fb1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_11:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_Clear
System_Array_InternalArray__ICollection_Clear:
.loc 2 78 0 prologue_end
.word 0xa9bd7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #368]
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
.word 0xd2889960
.word 0xd2889960
bl _p_25
.word 0xaa0003e1
.word 0xd2801fc0
.word 0xf2a04000
.word 0xd2801fc0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf9400fb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_12:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_Add_T_REF_T_REF
System_Array_InternalArray__ICollection_Add_T_REF_T_REF:
.loc 2 83 0 prologue_end
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9001faf
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
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
.word 0xd2889f60
.word 0xd2889f60
bl _p_25
.word 0xaa0003e1
.word 0xd2801fc0
.word 0xf2a04000
.word 0xd2801fc0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_13:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_Remove_T_REF_T_REF
System_Array_InternalArray__ICollection_Remove_T_REF_T_REF:
.loc 2 88 0 prologue_end
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9001faf
.word 0xf9000ba0
.word 0xf9000fa1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #384]
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
.word 0xd2889f60
.word 0xd2889f60
bl _p_25
.word 0xaa0003e1
.word 0xd2801fc0
.word 0xf2a04000
.word 0xd2801fc0
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_14:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_Contains_T_REF_T_REF
System_Array_InternalArray__ICollection_Contains_T_REF_T_REF:
.loc 2 93 0 prologue_end
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013ba
.word 0xf90027af
.word 0xaa0003fa
.word 0xf90017a1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #392]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800019
.word 0xd2800018
.word 0xf9002bbf
.word 0xf9401bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xf9400340
.word 0x3940b000
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xd2800021
.word 0x6b01001f
.word 0x540002ad
.loc 2 94 0
.word 0xf9401bb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xd288a6e0
.word 0xd288a6e0
bl _p_25
bl _p_26
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a1
.word 0xd2802160
.word 0xf2a04000
.word 0xd2802160
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_7
.loc 2 96 0
.word 0xf9401bb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb9801b40
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f9
.loc 2 97 0
.word 0xf9401bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800018
.word 0x14000048
.loc 2 99 0
.word 0xf9401bb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0x910143a0
.word 0xf94027a0
bl _p_27
.word 0x93407f00
.word 0xd37df000
.word 0x8b000340
.word 0x91008000
.word 0xf9400000
.word 0xf9002ba0
.loc 2 100 0
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
.word 0xb50001c0
.loc 2 101 0
.word 0xf9401bb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xb5000440
.loc 2 102 0
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800020
.word 0xd2800020
.word 0x14000038
.loc 2 108 0
.word 0xf9401bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0x9100a3a0
.word 0xf9402ba1
.word 0xf94017a2
.word 0xaa0203e0
.word 0xf9400042
.word 0xf9402c50
.word 0xd63f0200
.word 0x53001c00
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0x34000100
.loc 2 109 0
.word 0xf9401bb1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800020
.word 0xd2800020
.word 0x1400001e
.loc 2 97 0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1903e0
.word 0x6b19031f
.word 0x54fff5cb
.loc 2 113 0
.word 0xf9401bb1
.word 0xf9429631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0xd2800000
.word 0xf9401bb1
.word 0xf942ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_15:
.text
	.align 4
	.no_dead_strip System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int
System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int:
.loc 2 118 0 prologue_end
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015bb5
.word 0xf90013b8
.word 0xf9002faf
.word 0xaa0003f8
.word 0xf90017a1
.word 0xf9001ba2

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #400]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf9401fb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9002bb8
.word 0xaa1803e0
.word 0xd2800000
.word 0xf9400b16
.word 0xeb1f02df
.word 0x54000060
.word 0xb98006d5
.word 0x14000002
.word 0xd2800015
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
.word 0xf90033a0
.word 0xb98033a0
.word 0xf90037a0
.word 0xaa1803e0
.word 0xb9801b00
.word 0xf9003ba0
.word 0xf9401fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a2
.word 0xf94037a3
.word 0xf9403ba4
.word 0xf9402ba0
.word 0xaa1503e1
bl _p_28
.loc 2 119 0
.word 0xf9401fb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415bb5
.word 0xf94013b8
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_16:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate
wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate:
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #408]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800018
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xd2800013
.word 0xf9402bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #416]
.word 0xb9400000
.word 0x34000140
bl _p_29
.word 0xf90037a0
.word 0xf94037a1
.word 0xf94037a0
.word 0xf9003ba1
.word 0xb4000060
.word 0xf9403ba0
bl _p_7
.word 0xf9403ba0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9101a320
.word 0xf9403720
.word 0xaa0003f6
.word 0xaa1603e0
.word 0xb5000480
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91008320
.word 0xf9401320
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xb4000200
.word 0xaa1403e0
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b22
.word 0xaa1403e0
.word 0xaa1a03e1
.word 0xd63f0040
.word 0x53001c00
.word 0x14000038
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b21
.word 0xaa1a03e0
.word 0xd63f0020
.word 0x53001c00
.word 0x1400002b
.word 0xaa1603e0
.word 0xb9801ac0
.word 0xaa0003f7
.word 0xd2800018
.word 0xaa1603e0
.word 0xaa1803e0
.word 0x93407f00
.word 0xb9801ac1
.word 0xeb00003f
.word 0x10000011
.word 0x54000569
.word 0xd37df000
.word 0x8b0002c0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f5
.word 0xaa1503e2
.word 0xaa1a03e0
.word 0xaa0203e0
.word 0xaa1a03e1
.word 0xf90047a2
.word 0xf9400c50
.word 0xd63f0200
.word 0xf94047a1
.word 0x53001c00
.word 0xf90043a0
.word 0xf9402bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x53001c00
.word 0xaa0003f3
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1703e1
.word 0x6b17001f
.word 0x54fffbab
.word 0xaa1303e0
.word 0xaa1303e0
.word 0xf9402bb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_10

Lme_17:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate
wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate:
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #424]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xd2800013
.word 0xb9006bbf
.word 0xf9402bb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #416]
.word 0xb9400000
.word 0x34000140
bl _p_29
.word 0xf9003ba0
.word 0xf9403ba1
.word 0xf9403ba0
.word 0xf9003fa1
.word 0xb4000060
.word 0xf9403fa0
bl _p_7
.word 0xf9403fa0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9101a300
.word 0xf9403700
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xb5000500
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91008300
.word 0xf9401300
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xb4000240
.word 0xaa1303e0
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9100e300
.word 0xf9401f00
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91004300
.word 0xf9400b03
.word 0xaa1303e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xd63f0060
.word 0x93407c00
.word 0x1400003b
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x9100e300
.word 0xf9401f00
.word 0xaa1803e0
.word 0xaa1803e0
.word 0x91004300
.word 0xf9400b02
.word 0xaa1903e0
.word 0xaa1a03e1
.word 0xd63f0040
.word 0x93407c00
.word 0x1400002c
.word 0xaa1503e0
.word 0xb9801aa0
.word 0xaa0003f6
.word 0xd2800017
.word 0xaa1503e0
.word 0xaa1703e0
.word 0x93407ee0
.word 0xb9801aa1
.word 0xeb00003f
.word 0x10000011
.word 0x54000589
.word 0xd37df000
.word 0x8b0002a0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f4
.word 0xaa1403e3
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa0303e0
.word 0xaa1903e1
.word 0xaa1a03e2
.word 0xf90047a3
.word 0xf9400c70
.word 0xd63f0200
.word 0x93407c00
.word 0xaa0003e1
.word 0xf94047a0
.word 0xf90043a1
.word 0xf9402bb1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xb9006ba0
.word 0xaa1703e0
.word 0x110006e0
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1603e1
.word 0x6b16001f
.word 0x54fffb6b
.word 0xb9806ba0
.word 0xf9402bb1
.word 0xf9420e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_10

Lme_18:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification
wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #432]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800018
.word 0xd2800017
.word 0xd2800016
.word 0xd2800015
.word 0xd2800014
.word 0xf9402bb1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x0, [x16, #416]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
bl _p_29
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90037a0
.word 0xb4000073
.word 0xf94037a0
bl _p_7
.word 0xf94037a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9101a320
.word 0xf9403720
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb5000756
.word 0xf9402bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91008320
.word 0xf9401320
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xb40002f4
.word 0xf9402bb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b22
.word 0xaa1403e0
.word 0xaa1a03e1
.word 0xd63f0040
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000058
.word 0xf9402bb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9100e320
.word 0xf9401f20
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91004320
.word 0xf9400b21
.word 0xaa1a03e0
.word 0xd63f0020
.word 0xf9402bb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000044
.word 0xf9402bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb9801ac0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800018
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9425231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1803e0
.word 0x93407f00
.word 0xb9801ac1
.word 0xeb00003f
.word 0x10000011
.word 0x54000689
.word 0xd37df000
.word 0x8b0002c0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9003ba0
.word 0xaa1a03e0
.word 0xaa1503e0
.word 0xaa1a03e1
.word 0xf9400eb0
.word 0xd63f0200
.word 0xf9403ba0
.word 0xf9402bb1
.word 0xf942c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1703e0
.word 0x6b17031f
.word 0x54fff9cb
.word 0xf9402bb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9431e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_10

Lme_19:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1
.word 0xf90023a2
.word 0xf90027a3

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #440]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800019
.word 0xd2800018
.word 0xf9402bb1
.word 0xf9404e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800417
.word 0xb5000077
.word 0xd2800016
.word 0x1400000f
.word 0x91003ef0
.word 0x928001f1
.word 0xf2bffff1
.word 0x8a110210
.word 0x910003f1
.word 0xcb100231
.word 0x9100023f
.word 0x8b100230
.word 0xeb10023f
.word 0x54000080
.word 0xa9007e3f
.word 0x91004231
.word 0x17fffffc
.word 0x910003f6
.word 0xaa1603e0
.word 0xaa1603f9
.word 0xf9402bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603f8
.word 0xf9402bb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x9100e3a0
.word 0xf90002c0
.word 0xf9402bb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xd2800100
.word 0x93407c00
.word 0x910022c0
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910103a0
.word 0xf9000300
.word 0xf9402bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910123a0
.word 0xf9000300
.word 0xf9402bb1
.word 0xf9418231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa1603e1
.word 0xaa1603e1
bl _p_30
.word 0xf9003ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9402bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c87bfd
.word 0xd65f03c0

Lme_1a:
.text
	.align 4
	.no_dead_strip wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #448]
.word 0xf90023b0
.word 0xf9400a11
.word 0xf90027b1
.word 0xd2800019
.word 0xd2800018
.word 0xf94023b1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800217
.word 0xb5000077
.word 0xd2800016
.word 0x1400000f
.word 0x91003ef0
.word 0x928001f1
.word 0xf2bffff1
.word 0x8a110210
.word 0x910003f1
.word 0xcb100231
.word 0x9100023f
.word 0x8b100230
.word 0xeb10023f
.word 0x54000080
.word 0xa9007e3f
.word 0x91004231
.word 0x17fffffc
.word 0x910003f6
.word 0xaa1603e0
.word 0xaa1603f9
.word 0xf94023b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603f8
.word 0xf94023b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x9100e3a0
.word 0xf90002c0
.word 0xf94023b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa1603e1
.word 0xaa1603e1
bl _p_31
.word 0xf94023b1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_1b:
.text
ut_28:
add x0, x0, 16
b System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
ut_end:
.section __TEXT, __const
_unbox_trampoline_p:

	.long 0
LDIFF_SYM3=ut_end - ut_28
	.long LDIFF_SYM3
.text
	.align 4
	.no_dead_strip System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
System_Array_InternalEnumerator_1_T_REF__ctor_System_Array:
.loc 2 217 0 prologue_end
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9001faf
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #456]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf94013b1
.word 0xf9403e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9400fa0
.word 0xf9000320
.word 0xaa1903e1
.word 0xd349ff21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.loc 2 218 0
.word 0xf94013b1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x92800020
.word 0xf2bfffe0
.word 0x9280003e
.word 0xf2bffffe
.word 0xb9000b3e
.loc 2 219 0
.word 0xf94013b1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_1c:
.text
	.align 3
jit_code_end:

	.byte 0,0,0,0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl NotificationCenter_Notification__ctor_object_object
bl NotificationCenter_Notification_get_Sender
bl NotificationCenter_Notification_get_Message
bl NotificationCenter_Notification_get_Empty
bl NotificationCenter_NotificationCenterManager__ctor
bl NotificationCenter_NotificationCenterManager_get_Instance
bl NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
bl NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
bl NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification
bl NotificationCenter_NotificationCenterManager_PostNotification_string
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF
bl System_Array_InternalArray__ICollection_get_Count
bl System_Array_InternalArray__ICollection_get_IsReadOnly
bl System_Array_InternalArray__ICollection_Clear
bl System_Array_InternalArray__ICollection_Add_T_REF_T_REF
bl System_Array_InternalArray__ICollection_Remove_T_REF_T_REF
bl System_Array_InternalArray__ICollection_Contains_T_REF_T_REF
bl System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int
bl wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate
bl wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate
bl wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object
bl wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
bl System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
method_addresses_end:

.section __TEXT, __const
	.align 3
unbox_trampolines:

	.long 28
unbox_trampolines_end:

	.long 0
.text
	.align 3
unbox_trampoline_addresses:
bl ut_28

	.long 0
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 0,16,12,31,0,68,14,64,157,8,158,7,68,13,29,68,152,6,16,12,31,0,68,14,64,157,8,158,7,68,13,29
	.byte 68,153,6,16,12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6,23,12,31,0,68,14,96,157,12,158,11,68
	.byte 13,29,68,151,10,152,9,68,153,8,154,7,34,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13
	.byte 68,149,12,150,11,68,151,10,152,9,68,153,8,154,7,32,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147
	.byte 14,148,13,68,149,12,150,11,68,151,10,68,153,9,154,8,32,12,31,0,68,14,224,1,157,28,158,27,68,13,29,68
	.byte 147,26,148,25,68,149,24,150,23,68,151,22,68,153,21,154,20,27,12,31,0,68,14,240,1,157,30,158,29,68,13,29
	.byte 68,149,28,150,27,68,151,26,152,25,68,154,24,16,12,31,0,68,14,112,157,14,158,13,68,13,29,68,154,12,13,12
	.byte 31,0,68,14,64,157,8,158,7,68,13,29,13,12,31,0,68,14,48,157,6,158,5,68,13,29,21,12,31,0,68,14
	.byte 112,157,14,158,13,68,13,29,68,152,12,153,11,68,154,10,22,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68
	.byte 149,14,150,13,68,152,12,34,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13
	.byte 68,151,12,152,11,68,153,10,154,9,24,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152
	.byte 12,153,11,23,12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152,8,153,7

.text
	.align 4
plt:
mono_aot_NotificationCenter_plt:
	.no_dead_strip plt_wrapper_alloc_object_AllocSmall_intptr_intptr
plt_wrapper_alloc_object_AllocSmall_intptr_intptr:
_p_1:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #472]
br x16
.word 744
	.no_dead_strip plt_NotificationCenter_Notification__ctor_object_object
plt_NotificationCenter_Notification__ctor_object_object:
_p_2:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #480]
br x16
.word 752
	.no_dead_strip plt_System_Collections_Hashtable__ctor
plt_System_Collections_Hashtable__ctor:
_p_3:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #488]
br x16
.word 757
	.no_dead_strip plt_NotificationCenter_NotificationCenterManager__ctor
plt_NotificationCenter_NotificationCenterManager__ctor:
_p_4:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #496]
br x16
.word 760
	.no_dead_strip plt_string_IsNullOrEmpty_string
plt_string_IsNullOrEmpty_string:
_p_5:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #504]
br x16
.word 765
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_6:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #512]
br x16
.word 768
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_7:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #520]
br x16
.word 788
	.no_dead_strip plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate__ctor
plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate__ctor:
_p_8:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #528]
br x16
.word 816
	.no_dead_strip plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_Add_NotificationCenter_NotificationCenterManager_NotificationDelegate
plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_Add_NotificationCenter_NotificationCenterManager_NotificationDelegate:
_p_9:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #536]
br x16
.word 827
	.no_dead_strip plt__jit_icall_mono_arch_throw_corlib_exception
plt__jit_icall_mono_arch_throw_corlib_exception:
_p_10:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #544]
br x16
.word 838
	.no_dead_strip plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_Remove_NotificationCenter_NotificationCenterManager_NotificationDelegate
plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_Remove_NotificationCenter_NotificationCenterManager_NotificationDelegate:
_p_11:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #552]
br x16
.word 873
	.no_dead_strip plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_GetEnumerator
plt_System_Collections_Generic_List_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_GetEnumerator:
_p_12:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #560]
br x16
.word 884
	.no_dead_strip plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_get_Current
plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_get_Current:
_p_13:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #568]
br x16
.word 895
	.no_dead_strip plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_MoveNext
plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_MoveNext:
_p_14:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #576]
br x16
.word 906
	.no_dead_strip plt__jit_icall_ves_icall_thread_finish_async_abort
plt__jit_icall_ves_icall_thread_finish_async_abort:
_p_15:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #584]
br x16
.word 917
	.no_dead_strip plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_Dispose
plt_System_Collections_Generic_List_1_Enumerator_NotificationCenter_NotificationCenterManager_NotificationDelegate_Dispose:
_p_16:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #592]
br x16
.word 955
	.no_dead_strip plt_NotificationCenter_Notification_get_Empty
plt_NotificationCenter_Notification_get_Empty:
_p_17:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #600]
br x16
.word 976
	.no_dead_strip plt_System_Console_WriteLine_string
plt_System_Console_WriteLine_string:
_p_18:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #608]
br x16
.word 981
	.no_dead_strip plt__jit_icall_mono_thread_get_undeniable_exception
plt__jit_icall_mono_thread_get_undeniable_exception:
_p_19:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #616]
br x16
.word 984
	.no_dead_strip plt__rgctx_fetch_0
plt__rgctx_fetch_0:
_p_20:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #624]
br x16
.word 1045
	.no_dead_strip plt__jit_icall_mono_generic_class_init
plt__jit_icall_mono_generic_class_init:
_p_21:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #632]
br x16
.word 1053
	.no_dead_strip plt__rgctx_fetch_1
plt__rgctx_fetch_1:
_p_22:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #640]
br x16
.word 1079
	.no_dead_strip plt__rgctx_fetch_2
plt__rgctx_fetch_2:
_p_23:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #648]
br x16
.word 1093
	.no_dead_strip plt_System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
plt_System_Array_InternalEnumerator_1_T_REF__ctor_System_Array:
_p_24:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #656]
br x16
.word 1101
	.no_dead_strip plt__jit_icall_mono_helper_ldstr_mscorlib
plt__jit_icall_mono_helper_ldstr_mscorlib:
_p_25:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #664]
br x16
.word 1119
	.no_dead_strip plt_Locale_GetText_string
plt_Locale_GetText_string:
_p_26:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #672]
br x16
.word 1148
	.no_dead_strip plt__rgctx_fetch_3
plt__rgctx_fetch_3:
_p_27:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #680]
br x16
.word 1167
	.no_dead_strip plt_System_Array_Copy_System_Array_int_System_Array_int_int
plt_System_Array_Copy_System_Array_int_System_Array_int_int:
_p_28:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #688]
br x16
.word 1189
	.no_dead_strip plt__jit_icall_mono_thread_interruption_checkpoint
plt__jit_icall_mono_thread_interruption_checkpoint:
_p_29:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #696]
br x16
.word 1192
	.no_dead_strip plt__jit_icall_mono_delegate_begin_invoke
plt__jit_icall_mono_delegate_begin_invoke:
_p_30:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #704]
br x16
.word 1230
	.no_dead_strip plt__jit_icall_mono_delegate_end_invoke
plt__jit_icall_mono_delegate_end_invoke:
_p_31:
adrp x16, mono_aot_NotificationCenter_got@PAGE+0
add x16, x16, mono_aot_NotificationCenter_got@PAGEOFF
ldr x16, [x16, #712]
br x16
.word 1259
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_NotificationCenter_got, 720
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
	.align 3
	.quad Lglobals_hash
	.align 3
	.quad name_0
	.align 3
	.quad _unbox_trampoline_p

	.long 0,0
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "DE74F4D5-2FBE-400C-A251-B68661EED8D5"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "NotificationCenter"
.data
	.align 3
_mono_aot_file_info:

	.long 144,0
	.align 3
	.quad mono_aot_NotificationCenter_got
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

	.long 58,720,32,29,70,387000831,0,5748
	.long 128,8,8,8,0,25,6832,1072
	.long 888,640,0,792,864,696,0,520
	.long 56,1064,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
	.byte 208,250,244,155,59,85,150,226,64,170,138,48,81,192,139,118
	.globl _mono_aot_module_NotificationCenter_info
	.align 3
_mono_aot_module_NotificationCenter_info:
	.align 3
	.quad _mono_aot_file_info
.section __DWARF, __debug_info,regular,debug
LTDIE_1:

	.byte 17
	.asciz "System_Object"

	.byte 16,7
	.asciz "System_Object"

LDIFF_SYM4=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM5=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM6=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM6
LTDIE_0:

	.byte 5
	.asciz "NotificationCenter_Notification"

	.byte 32,16
LDIFF_SYM7=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM7
	.byte 2,35,0,6
	.asciz "m_sender"

LDIFF_SYM8=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM8
	.byte 2,35,16,6
	.asciz "m_message"

LDIFF_SYM9=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM9
	.byte 2,35,24,0,7
	.asciz "NotificationCenter_Notification"

LDIFF_SYM10=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM10
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM11=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM11
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM12=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM12
	.byte 2
	.asciz "NotificationCenter.Notification:.ctor"
	.asciz "NotificationCenter_Notification__ctor_object_object"

	.byte 0,0
	.quad NotificationCenter_Notification__ctor_object_object
	.quad Lme_0

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM13=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM13
	.byte 1,104,3
	.asciz "p_sender"

LDIFF_SYM14=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM14
	.byte 2,141,24,3
	.asciz "p_message"

LDIFF_SYM15=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 2,141,32,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM16=Lfde0_end - Lfde0_start
	.long LDIFF_SYM16
Lfde0_start:

	.long 0
	.align 3
	.quad NotificationCenter_Notification__ctor_object_object

LDIFF_SYM17=Lme_0 - NotificationCenter_Notification__ctor_object_object
	.long LDIFF_SYM17
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,152,6
	.align 3
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.Notification:get_Sender"
	.asciz "NotificationCenter_Notification_get_Sender"

	.byte 0,0
	.quad NotificationCenter_Notification_get_Sender
	.quad Lme_1

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM18=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM18
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM19=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM20=Lfde1_end - Lfde1_start
	.long LDIFF_SYM20
Lfde1_start:

	.long 0
	.align 3
	.quad NotificationCenter_Notification_get_Sender

LDIFF_SYM21=Lme_1 - NotificationCenter_Notification_get_Sender
	.long LDIFF_SYM21
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,153,6
	.align 3
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.Notification:get_Message"
	.asciz "NotificationCenter_Notification_get_Message"

	.byte 0,0
	.quad NotificationCenter_Notification_get_Message
	.quad Lme_2

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM22=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM22
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM23=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM23
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM24=Lfde2_end - Lfde2_start
	.long LDIFF_SYM24
Lfde2_start:

	.long 0
	.align 3
	.quad NotificationCenter_Notification_get_Message

LDIFF_SYM25=Lme_2 - NotificationCenter_Notification_get_Message
	.long LDIFF_SYM25
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,153,6
	.align 3
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.Notification:get_Empty"
	.asciz "NotificationCenter_Notification_get_Empty"

	.byte 0,0
	.quad NotificationCenter_Notification_get_Empty
	.quad Lme_3

	.byte 2,118,16,11
	.asciz "V_0"

LDIFF_SYM26=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM26
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM27=Lfde3_end - Lfde3_start
	.long LDIFF_SYM27
Lfde3_start:

	.long 0
	.align 3
	.quad NotificationCenter_Notification_get_Empty

LDIFF_SYM28=Lme_3 - NotificationCenter_Notification_get_Empty
	.long LDIFF_SYM28
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6
	.align 3
Lfde3_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_5:

	.byte 5
	.asciz "System_ValueType"

	.byte 16,16
LDIFF_SYM29=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM30=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM30
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM31=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM31
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM32=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM32
LTDIE_4:

	.byte 5
	.asciz "System_Int32"

	.byte 20,16
LDIFF_SYM33=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM34=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM34
	.byte 2,35,16,0,7
	.asciz "System_Int32"

LDIFF_SYM35=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM35
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM36=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM36
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM37=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM37
LTDIE_6:

	.byte 5
	.asciz "System_Single"

	.byte 20,16
LDIFF_SYM38=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM38
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM39=LDIE_R4 - Ldebug_info_start
	.long LDIFF_SYM39
	.byte 2,35,16,0,7
	.asciz "System_Single"

LDIFF_SYM40=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM40
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM41=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM41
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM42=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM42
LTDIE_7:

	.byte 5
	.asciz "System_Boolean"

	.byte 17,16
LDIFF_SYM43=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM43
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM44=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2,35,16,0,7
	.asciz "System_Boolean"

LDIFF_SYM45=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM45
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM46=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM46
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM47=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM47
LTDIE_8:

	.byte 17
	.asciz "System_Collections_ICollection"

	.byte 16,7
	.asciz "System_Collections_ICollection"

LDIFF_SYM48=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM48
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM49=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM49
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM50=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM50
LTDIE_9:

	.byte 17
	.asciz "System_Collections_IEqualityComparer"

	.byte 16,7
	.asciz "System_Collections_IEqualityComparer"

LDIFF_SYM51=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM51
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM52=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM52
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM53=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM53
LTDIE_3:

	.byte 5
	.asciz "System_Collections_Hashtable"

	.byte 80,16
LDIFF_SYM54=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM54
	.byte 2,35,0,6
	.asciz "_buckets"

LDIFF_SYM55=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 2,35,16,6
	.asciz "_count"

LDIFF_SYM56=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 2,35,56,6
	.asciz "_occupancy"

LDIFF_SYM57=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM57
	.byte 2,35,60,6
	.asciz "_loadsize"

LDIFF_SYM58=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM58
	.byte 2,35,64,6
	.asciz "_loadFactor"

LDIFF_SYM59=LDIE_R4 - Ldebug_info_start
	.long LDIFF_SYM59
	.byte 2,35,68,6
	.asciz "_version"

LDIFF_SYM60=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 2,35,72,6
	.asciz "_isWriterInProgress"

LDIFF_SYM61=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM61
	.byte 2,35,76,6
	.asciz "_keys"

LDIFF_SYM62=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM62
	.byte 2,35,24,6
	.asciz "_values"

LDIFF_SYM63=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM63
	.byte 2,35,32,6
	.asciz "_keycomparer"

LDIFF_SYM64=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 2,35,40,6
	.asciz "_syncRoot"

LDIFF_SYM65=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM65
	.byte 2,35,48,0,7
	.asciz "System_Collections_Hashtable"

LDIFF_SYM66=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM66
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM67=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM67
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM68=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM68
LTDIE_2:

	.byte 5
	.asciz "NotificationCenter_NotificationCenterManager"

	.byte 24,16
LDIFF_SYM69=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 2,35,0,6
	.asciz "m_hashtable"

LDIFF_SYM70=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM70
	.byte 2,35,16,0,7
	.asciz "NotificationCenter_NotificationCenterManager"

LDIFF_SYM71=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM71
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM72=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM72
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM73=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM73
	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:.ctor"
	.asciz "NotificationCenter_NotificationCenterManager__ctor"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager__ctor
	.quad Lme_4

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM74=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM74
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM75=Lfde4_end - Lfde4_start
	.long LDIFF_SYM75
Lfde4_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager__ctor

LDIFF_SYM76=Lme_4 - NotificationCenter_NotificationCenterManager__ctor
	.long LDIFF_SYM76
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6
	.align 3
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:get_Instance"
	.asciz "NotificationCenter_NotificationCenterManager_get_Instance"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager_get_Instance
	.quad Lme_5

	.byte 2,118,16,11
	.asciz "V_0"

LDIFF_SYM77=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM77
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM78=Lfde5_end - Lfde5_start
	.long LDIFF_SYM78
Lfde5_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager_get_Instance

LDIFF_SYM79=Lme_5 - NotificationCenter_NotificationCenterManager_get_Instance
	.long LDIFF_SYM79
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,151,10,152,9,68,153,8,154,7
	.align 3
Lfde5_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_15:

	.byte 5
	.asciz "System_Reflection_MemberInfo"

	.byte 16,16
LDIFF_SYM80=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MemberInfo"

LDIFF_SYM81=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM81
LTDIE_15_POINTER:

	.byte 13
LDIFF_SYM82=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM82
LTDIE_15_REFERENCE:

	.byte 14
LDIFF_SYM83=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM83
LTDIE_14:

	.byte 5
	.asciz "System_Reflection_MethodBase"

	.byte 16,16
LDIFF_SYM84=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM84
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodBase"

LDIFF_SYM85=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM85
LTDIE_14_POINTER:

	.byte 13
LDIFF_SYM86=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM86
LTDIE_14_REFERENCE:

	.byte 14
LDIFF_SYM87=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM87
LTDIE_13:

	.byte 5
	.asciz "System_Reflection_MethodInfo"

	.byte 16,16
LDIFF_SYM88=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM88
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodInfo"

LDIFF_SYM89=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM89
LTDIE_13_POINTER:

	.byte 13
LDIFF_SYM90=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM90
LTDIE_13_REFERENCE:

	.byte 14
LDIFF_SYM91=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM91
LTDIE_17:

	.byte 5
	.asciz "System_Type"

	.byte 24,16
LDIFF_SYM92=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM92
	.byte 2,35,0,6
	.asciz "_impl"

LDIFF_SYM93=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM93
	.byte 2,35,16,0,7
	.asciz "System_Type"

LDIFF_SYM94=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM94
LTDIE_17_POINTER:

	.byte 13
LDIFF_SYM95=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM95
LTDIE_17_REFERENCE:

	.byte 14
LDIFF_SYM96=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM96
LTDIE_16:

	.byte 5
	.asciz "System_DelegateData"

	.byte 40,16
LDIFF_SYM97=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM97
	.byte 2,35,0,6
	.asciz "target_type"

LDIFF_SYM98=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM98
	.byte 2,35,16,6
	.asciz "method_name"

LDIFF_SYM99=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM99
	.byte 2,35,24,6
	.asciz "curried_first_arg"

LDIFF_SYM100=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM100
	.byte 2,35,32,0,7
	.asciz "System_DelegateData"

LDIFF_SYM101=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM101
LTDIE_16_POINTER:

	.byte 13
LDIFF_SYM102=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM102
LTDIE_16_REFERENCE:

	.byte 14
LDIFF_SYM103=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM103
LTDIE_12:

	.byte 5
	.asciz "System_Delegate"

	.byte 104,16
LDIFF_SYM104=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM104
	.byte 2,35,0,6
	.asciz "method_ptr"

LDIFF_SYM105=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM105
	.byte 2,35,16,6
	.asciz "invoke_impl"

LDIFF_SYM106=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 2,35,24,6
	.asciz "m_target"

LDIFF_SYM107=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM107
	.byte 2,35,32,6
	.asciz "method"

LDIFF_SYM108=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM108
	.byte 2,35,40,6
	.asciz "delegate_trampoline"

LDIFF_SYM109=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM109
	.byte 2,35,48,6
	.asciz "extra_arg"

LDIFF_SYM110=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 2,35,56,6
	.asciz "method_code"

LDIFF_SYM111=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM111
	.byte 2,35,64,6
	.asciz "method_info"

LDIFF_SYM112=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM112
	.byte 2,35,72,6
	.asciz "original_method_info"

LDIFF_SYM113=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 2,35,80,6
	.asciz "data"

LDIFF_SYM114=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM114
	.byte 2,35,88,6
	.asciz "method_is_virtual"

LDIFF_SYM115=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM115
	.byte 2,35,96,0,7
	.asciz "System_Delegate"

LDIFF_SYM116=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM116
LTDIE_12_POINTER:

	.byte 13
LDIFF_SYM117=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM117
LTDIE_12_REFERENCE:

	.byte 14
LDIFF_SYM118=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM118
LTDIE_11:

	.byte 5
	.asciz "System_MulticastDelegate"

	.byte 112,16
LDIFF_SYM119=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 2,35,0,6
	.asciz "delegates"

LDIFF_SYM120=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM120
	.byte 2,35,104,0,7
	.asciz "System_MulticastDelegate"

LDIFF_SYM121=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM121
LTDIE_11_POINTER:

	.byte 13
LDIFF_SYM122=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM122
LTDIE_11_REFERENCE:

	.byte 14
LDIFF_SYM123=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM123
LTDIE_10:

	.byte 5
	.asciz "_NotificationDelegate"

	.byte 112,16
LDIFF_SYM124=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM124
	.byte 2,35,0,0,7
	.asciz "_NotificationDelegate"

LDIFF_SYM125=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM125
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM126=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM126
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM127=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM127
LTDIE_18:

	.byte 5
	.asciz "System_Collections_Generic_List`1"

	.byte 32,16
LDIFF_SYM128=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM128
	.byte 2,35,0,6
	.asciz "_items"

LDIFF_SYM129=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM129
	.byte 2,35,16,6
	.asciz "_size"

LDIFF_SYM130=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM130
	.byte 2,35,24,6
	.asciz "_version"

LDIFF_SYM131=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM131
	.byte 2,35,28,0,7
	.asciz "System_Collections_Generic_List`1"

LDIFF_SYM132=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM132
LTDIE_18_POINTER:

	.byte 13
LDIFF_SYM133=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM133
LTDIE_18_REFERENCE:

	.byte 14
LDIFF_SYM134=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM134
	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:AddObserver"
	.asciz "NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
	.quad Lme_6

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM135=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM135
	.byte 1,104,3
	.asciz "p_notificationDelegate"

LDIFF_SYM136=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM136
	.byte 1,105,3
	.asciz "p_notificationName"

LDIFF_SYM137=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM137
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM138=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM138
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM139=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM139
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM140=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM140
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM141=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM141
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM142=Lfde6_end - Lfde6_start
	.long LDIFF_SYM142
Lfde6_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string

LDIFF_SYM143=Lme_6 - NotificationCenter_NotificationCenterManager_AddObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
	.long LDIFF_SYM143
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7
	.align 3
Lfde6_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:RemoveObserver"
	.asciz "NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
	.quad Lme_7

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM144=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM144
	.byte 3,141,200,0,3
	.asciz "p_notificationDelegate"

LDIFF_SYM145=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM145
	.byte 1,105,3
	.asciz "p_notificationName"

LDIFF_SYM146=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM146
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM147=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM147
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM148=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM148
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM149=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM149
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM150=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM150
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM151=Lfde7_end - Lfde7_start
	.long LDIFF_SYM151
Lfde7_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string

LDIFF_SYM152=Lme_7 - NotificationCenter_NotificationCenterManager_RemoveObserver_NotificationCenter_NotificationCenterManager_NotificationDelegate_string
	.long LDIFF_SYM152
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,68,153,9,154,8
	.align 3
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:PostNotification"
	.asciz "NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification
	.quad Lme_8

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM153=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM153
	.byte 3,141,200,0,3
	.asciz "p_notificationName"

LDIFF_SYM154=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM154
	.byte 1,105,3
	.asciz "p_notification"

LDIFF_SYM155=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM155
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM156=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM156
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM157=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM157
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM158=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM158
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM159=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM159
	.byte 1,100,11
	.asciz "V_4"

LDIFF_SYM160=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM160
	.byte 3,141,128,1,11
	.asciz "V_5"

LDIFF_SYM161=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM161
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM162=Lfde8_end - Lfde8_start
	.long LDIFF_SYM162
Lfde8_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification

LDIFF_SYM163=Lme_8 - NotificationCenter_NotificationCenterManager_PostNotification_string_NotificationCenter_Notification
	.long LDIFF_SYM163
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,68,147,26,148,25,68,149,24,150,23,68,151,22,68,153,21,154,20
	.align 3
Lfde8_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "NotificationCenter.NotificationCenterManager:PostNotification"
	.asciz "NotificationCenter_NotificationCenterManager_PostNotification_string"

	.byte 0,0
	.quad NotificationCenter_NotificationCenterManager_PostNotification_string
	.quad Lme_9

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM164=LTDIE_2_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM164
	.byte 2,141,56,3
	.asciz "p_notificationName"

LDIFF_SYM165=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM165
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM166=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM166
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM167=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM167
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM168=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM168
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM169=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM169
	.byte 3,141,240,0,11
	.asciz "V_4"

LDIFF_SYM170=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM170
	.byte 3,141,136,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM171=Lfde9_end - Lfde9_start
	.long LDIFF_SYM171
Lfde9_start:

	.long 0
	.align 3
	.quad NotificationCenter_NotificationCenterManager_PostNotification_string

LDIFF_SYM172=Lme_9 - NotificationCenter_NotificationCenterManager_PostNotification_string
	.long LDIFF_SYM172
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,68,149,28,150,27,68,151,26,152,25,68,154,24
	.align 3
Lfde9_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_19:

	.byte 5
	.asciz "System_Array"

	.byte 16,16
LDIFF_SYM173=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM173
	.byte 2,35,0,0,7
	.asciz "System_Array"

LDIFF_SYM174=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM174
LTDIE_19_POINTER:

	.byte 13
LDIFF_SYM175=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM175
LTDIE_19_REFERENCE:

	.byte 14
LDIFF_SYM176=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM176
	.byte 2
	.asciz "System.Array:InternalArray__IEnumerable_GetEnumerator<T_REF>"
	.asciz "System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF"

	.byte 1,70
	.quad System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF
	.quad Lme_f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM177=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM177
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM178=Lfde10_end - Lfde10_start
	.long LDIFF_SYM178
Lfde10_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF

LDIFF_SYM179=Lme_f - System_Array_InternalArray__IEnumerable_GetEnumerator_T_REF
	.long LDIFF_SYM179
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,154,12
	.align 3
Lfde10_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_get_Count"
	.asciz "System_Array_InternalArray__ICollection_get_Count"

	.byte 1,60
	.quad System_Array_InternalArray__ICollection_get_Count
	.quad Lme_10

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM180=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM180
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM181=Lfde11_end - Lfde11_start
	.long LDIFF_SYM181
Lfde11_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_get_Count

LDIFF_SYM182=Lme_10 - System_Array_InternalArray__ICollection_get_Count
	.long LDIFF_SYM182
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde11_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_get_IsReadOnly"
	.asciz "System_Array_InternalArray__ICollection_get_IsReadOnly"

	.byte 1,65
	.quad System_Array_InternalArray__ICollection_get_IsReadOnly
	.quad Lme_11

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM183=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM183
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM184=Lfde12_end - Lfde12_start
	.long LDIFF_SYM184
Lfde12_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_get_IsReadOnly

LDIFF_SYM185=Lme_11 - System_Array_InternalArray__ICollection_get_IsReadOnly
	.long LDIFF_SYM185
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde12_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_Clear"
	.asciz "System_Array_InternalArray__ICollection_Clear"

	.byte 1,78
	.quad System_Array_InternalArray__ICollection_Clear
	.quad Lme_12

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM186=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM186
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM187=Lfde13_end - Lfde13_start
	.long LDIFF_SYM187
Lfde13_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_Clear

LDIFF_SYM188=Lme_12 - System_Array_InternalArray__ICollection_Clear
	.long LDIFF_SYM188
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde13_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_Add<T_REF>"
	.asciz "System_Array_InternalArray__ICollection_Add_T_REF_T_REF"

	.byte 1,83
	.quad System_Array_InternalArray__ICollection_Add_T_REF_T_REF
	.quad Lme_13

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM189=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM189
	.byte 2,141,16,3
	.asciz "item"

LDIFF_SYM190=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM190
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM191=Lfde14_end - Lfde14_start
	.long LDIFF_SYM191
Lfde14_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_Add_T_REF_T_REF

LDIFF_SYM192=Lme_13 - System_Array_InternalArray__ICollection_Add_T_REF_T_REF
	.long LDIFF_SYM192
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde14_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_Remove<T_REF>"
	.asciz "System_Array_InternalArray__ICollection_Remove_T_REF_T_REF"

	.byte 1,88
	.quad System_Array_InternalArray__ICollection_Remove_T_REF_T_REF
	.quad Lme_14

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM193=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM193
	.byte 2,141,16,3
	.asciz "item"

LDIFF_SYM194=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM194
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM195=Lfde15_end - Lfde15_start
	.long LDIFF_SYM195
Lfde15_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_Remove_T_REF_T_REF

LDIFF_SYM196=Lme_14 - System_Array_InternalArray__ICollection_Remove_T_REF_T_REF
	.long LDIFF_SYM196
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde15_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_Contains<T_REF>"
	.asciz "System_Array_InternalArray__ICollection_Contains_T_REF_T_REF"

	.byte 1,93
	.quad System_Array_InternalArray__ICollection_Contains_T_REF_T_REF
	.quad Lme_15

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM197=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM197
	.byte 1,106,3
	.asciz "item"

LDIFF_SYM198=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM198
	.byte 2,141,40,11
	.asciz "length"

LDIFF_SYM199=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM199
	.byte 1,105,11
	.asciz "i"

LDIFF_SYM200=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM200
	.byte 1,104,11
	.asciz "value"

LDIFF_SYM201=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM201
	.byte 3,141,208,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM202=Lfde16_end - Lfde16_start
	.long LDIFF_SYM202
Lfde16_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_Contains_T_REF_T_REF

LDIFF_SYM203=Lme_15 - System_Array_InternalArray__ICollection_Contains_T_REF_T_REF
	.long LDIFF_SYM203
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,152,12,153,11,68,154,10
	.align 3
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Array:InternalArray__ICollection_CopyTo<T_REF>"
	.asciz "System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int"

	.byte 1,118
	.quad System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int
	.quad Lme_16

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM204=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM204
	.byte 1,104,3
	.asciz "array"

LDIFF_SYM205=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM205
	.byte 2,141,40,3
	.asciz "arrayIndex"

LDIFF_SYM206=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM206
	.byte 2,141,48,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM207=Lfde17_end - Lfde17_start
	.long LDIFF_SYM207
Lfde17_start:

	.long 0
	.align 3
	.quad System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int

LDIFF_SYM208=Lme_16 - System_Array_InternalArray__ICollection_CopyTo_T_REF_T_REF___int
	.long LDIFF_SYM208
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,149,14,150,13,68,152,12
	.align 3
Lfde17_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_20:

	.byte 5
	.asciz "System_Predicate`1"

	.byte 112,16
LDIFF_SYM209=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM209
	.byte 2,35,0,0,7
	.asciz "System_Predicate`1"

LDIFF_SYM210=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM210
LTDIE_20_POINTER:

	.byte 13
LDIFF_SYM211=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM211
LTDIE_20_REFERENCE:

	.byte 14
LDIFF_SYM212=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM212
	.byte 2
	.asciz "(wrapper_delegate-invoke)_System.Predicate`1<NotificationCenter.NotificationCenterManager/NotificationDelegate>:invoke_bool_T"
	.asciz "wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate"

	.byte 0,0
	.quad wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate
	.quad Lme_17

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM213=LTDIE_20_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM213
	.byte 1,105,3
	.asciz "param0"

LDIFF_SYM214=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM214
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM215=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM215
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM216=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM216
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM217=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM217
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM218=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM218
	.byte 1,101,11
	.asciz "V_4"

LDIFF_SYM219=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM219
	.byte 1,100,11
	.asciz "V_5"

LDIFF_SYM220=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM220
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM221=Lfde18_end - Lfde18_start
	.long LDIFF_SYM221
Lfde18_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate

LDIFF_SYM222=Lme_17 - wrapper_delegate_invoke_System_Predicate_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_bool_T_NotificationCenter_NotificationCenterManager_NotificationDelegate
	.long LDIFF_SYM222
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde18_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_21:

	.byte 5
	.asciz "System_Comparison`1"

	.byte 112,16
LDIFF_SYM223=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM223
	.byte 2,35,0,0,7
	.asciz "System_Comparison`1"

LDIFF_SYM224=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM224
LTDIE_21_POINTER:

	.byte 13
LDIFF_SYM225=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM225
LTDIE_21_REFERENCE:

	.byte 14
LDIFF_SYM226=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM226
	.byte 2
	.asciz "(wrapper_delegate-invoke)_System.Comparison`1<NotificationCenter.NotificationCenterManager/NotificationDelegate>:invoke_int_T_T"
	.asciz "wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate"

	.byte 0,0
	.quad wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate
	.quad Lme_18

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM227=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM227
	.byte 1,104,3
	.asciz "param0"

LDIFF_SYM228=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM228
	.byte 1,105,3
	.asciz "param1"

LDIFF_SYM229=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM229
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM230=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM230
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM231=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM231
	.byte 1,102,11
	.asciz "V_2"

LDIFF_SYM232=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM232
	.byte 1,101,11
	.asciz "V_3"

LDIFF_SYM233=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM233
	.byte 1,100,11
	.asciz "V_4"

LDIFF_SYM234=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM234
	.byte 1,99,11
	.asciz "V_5"

LDIFF_SYM235=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM235
	.byte 3,141,232,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM236=Lfde19_end - Lfde19_start
	.long LDIFF_SYM236
Lfde19_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate

LDIFF_SYM237=Lme_18 - wrapper_delegate_invoke_System_Comparison_1_NotificationCenter_NotificationCenterManager_NotificationDelegate_invoke_int_T_T_NotificationCenter_NotificationCenterManager_NotificationDelegate_NotificationCenter_NotificationCenterManager_NotificationDelegate
	.long LDIFF_SYM237
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde19_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_22:

	.byte 17
	.asciz "_<Module>"

	.byte 16,7
	.asciz "_<Module>"

LDIFF_SYM238=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM238
LTDIE_22_POINTER:

	.byte 13
LDIFF_SYM239=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM239
LTDIE_22_REFERENCE:

	.byte 14
LDIFF_SYM240=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM240
	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_void_Notification"
	.asciz "wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification
	.quad Lme_19

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM241=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM241
	.byte 1,105,3
	.asciz "param0"

LDIFF_SYM242=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM242
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM243=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM243
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM244=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM244
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM245=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM245
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM246=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM246
	.byte 1,101,11
	.asciz "V_4"

LDIFF_SYM247=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM247
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM248=Lfde20_end - Lfde20_start
	.long LDIFF_SYM248
Lfde20_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification

LDIFF_SYM249=Lme_19 - wrapper_delegate_invoke__Module_invoke_void_Notification_NotificationCenter_Notification
	.long LDIFF_SYM249
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7
	.align 3
Lfde20_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_23:

	.byte 5
	.asciz "System_AsyncCallback"

	.byte 112,16
LDIFF_SYM250=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM250
	.byte 2,35,0,0,7
	.asciz "System_AsyncCallback"

LDIFF_SYM251=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM251
LTDIE_23_POINTER:

	.byte 13
LDIFF_SYM252=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM252
LTDIE_23_REFERENCE:

	.byte 14
LDIFF_SYM253=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM253
	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object
	.quad Lme_1a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM254=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM254
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM255=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM255
	.byte 2,141,56,3
	.asciz "param1"

LDIFF_SYM256=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM256
	.byte 3,141,192,0,3
	.asciz "param2"

LDIFF_SYM257=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM257
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM258=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM258
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM259=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM259
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM260=Lfde21_end - Lfde21_start
	.long LDIFF_SYM260
Lfde21_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object

LDIFF_SYM261=Lme_1a - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___Notification_AsyncCallback_object_NotificationCenter_Notification_System_AsyncCallback_object
	.long LDIFF_SYM261
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152,12,153,11
	.align 3
Lfde21_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_24:

	.byte 17
	.asciz "System_IAsyncResult"

	.byte 16,7
	.asciz "System_IAsyncResult"

LDIFF_SYM262=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM262
LTDIE_24_POINTER:

	.byte 13
LDIFF_SYM263=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM263
LTDIE_24_REFERENCE:

	.byte 14
LDIFF_SYM264=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM264
	.byte 2
	.asciz "(wrapper_delegate-end-invoke)_<Module>:end_invoke_void__this___IAsyncResult"
	.asciz "wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult"

	.byte 0,0
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.quad Lme_1b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM265=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM265
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM266=LTDIE_24_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM266
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM267=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM267
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM268=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM268
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM269=Lfde22_end - Lfde22_start
	.long LDIFF_SYM269
Lfde22_start:

	.long 0
	.align 3
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult

LDIFF_SYM270=Lme_1b - wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.long LDIFF_SYM270
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152,8,153,7
	.align 3
Lfde22_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_25:

	.byte 5
	.asciz "_InternalEnumerator`1"

	.byte 32,16
LDIFF_SYM271=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM271
	.byte 2,35,0,6
	.asciz "array"

LDIFF_SYM272=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM272
	.byte 2,35,16,6
	.asciz "idx"

LDIFF_SYM273=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM273
	.byte 2,35,24,0,7
	.asciz "_InternalEnumerator`1"

LDIFF_SYM274=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM274
LTDIE_25_POINTER:

	.byte 13
LDIFF_SYM275=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM275
LTDIE_25_REFERENCE:

	.byte 14
LDIFF_SYM276=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM276
	.byte 2
	.asciz "System.Array/InternalEnumerator`1<T_REF>:.ctor"
	.asciz "System_Array_InternalEnumerator_1_T_REF__ctor_System_Array"

	.byte 1,217,1
	.quad System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
	.quad Lme_1c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM277=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM277
	.byte 1,105,3
	.asciz "array"

LDIFF_SYM278=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM278
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM279=Lfde23_end - Lfde23_start
	.long LDIFF_SYM279
Lfde23_start:

	.long 0
	.align 3
	.quad System_Array_InternalEnumerator_1_T_REF__ctor_System_Array

LDIFF_SYM280=Lme_1c - System_Array_InternalEnumerator_1_T_REF__ctor_System_Array
	.long LDIFF_SYM280
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,153,6
	.align 3
Lfde23_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:
