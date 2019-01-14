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
	.asciz "Microsoft.AppCenter.iOS.Bindings.dll"
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
	.no_dead_strip ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint:
.file 1 "<unknown>"
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa90267b8
.word 0xf9001bba
.word 0xf9001fa0
.word 0xf90023a1
.word 0xf90027a2
.word 0xf9002ba3
.word 0xf9002fa4
.word 0xf90033a5

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #200]
.word 0xf90037b0
.word 0xf9400a11
.word 0xf9003bb1
.word 0xd2800014
.word 0xd2800013
.word 0xf94037b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_1
.word 0xf90047a0
.word 0xf94037b1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xf90043a0
.word 0xaa0003f4
.word 0xf94037b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003e1
bl _p_2
.word 0xaa0003fa
.word 0xf94037b1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xb400017a
.word 0xf9400340
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #208]
.word 0xeb01001f
.word 0x10000011
.word 0x54000901
.word 0xaa1a03e0
.word 0xaa1a03f3
.word 0xf94037b1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb40005da
.word 0xf94037b1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303f9
.word 0xf94023a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #216]
bl _p_3
.word 0xaa0003f8
.word 0xf94037b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000178
.word 0xf9400300
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #224]
.word 0xeb01001f
.word 0x10000011
.word 0x540004c1
.word 0xaa1803e0
.word 0xf94027a0
.word 0xf90043a0
.word 0xf94037b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a2
.word 0xf9402ba3
.word 0xf9402fa4
.word 0xb94063a5
.word 0xaa1903e0
.word 0xaa1803e1
.word 0xf9400f30
.word 0xd63f0200
.word 0xf94037b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa94267b8
.word 0xf9401bba
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_4

Lme_6:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_SDMSLogHandler__cctor
ObjCRuntime_Trampolines_SDMSLogHandler__cctor:
.loc 1 1 0
.word 0xa9bd7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #232]
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
.word 0xd2800000

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #240]
.word 0xd2800e01
.word 0xd2800e01
bl _p_5
.word 0xaa0003e1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #248]
.word 0xf9001420

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #256]
.word 0xf9002020

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #264]
.word 0xf9401402
.word 0xf9000c22
.word 0xf9401000
.word 0xf9000820
.word 0xd2800000
.word 0x3901803f

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #272]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_7:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_
ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #280]
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
.word 0xf94013b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_6
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_7
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9000f20
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #288]
.word 0xaa1a03e0
bl _p_8
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf9000b20
.word 0x91004321
.word 0xd349fc21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_8:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize
ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #296]
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
.word 0xf9400c00
bl _p_9
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9001bbf
.word 0x94000005
.word 0xf9401ba0
.word 0xb4000040
bl _p_10
.word 0x14000012
.word 0xf90027be
.word 0xf9400fb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_11
.word 0xf9400fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027be
.word 0xd61f03c0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000001
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_9:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr
ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #304]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800019
.word 0xf9401bb1
.word 0xf9403e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #312]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_12
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000200
.word 0xf9401bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x14000098
.word 0xf9401bb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000700
.word 0xf9401bb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_1
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_2
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803f7
.word 0xeb1f031f
.word 0x54000160
.word 0xf9400300
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #208]
.word 0xeb01001f
.word 0x54000040
.word 0xd2800017
.word 0xaa1703e0
.word 0xaa1703f9
.word 0xf9401bb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb4000217
.word 0xf9401bb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x14000052
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9420e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_1
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #320]
bl _p_14
.word 0xf94037a1
.word 0xf90033a0
bl _p_15
.word 0xf9401bb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf9002fa0
.word 0xeb1f001f
.word 0x10000011
.word 0x540007c0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #328]
.word 0xd2800e01
.word 0xd2800e01
bl _p_5
.word 0xf9402fa1
.word 0xeb1f003f
.word 0x10000011
.word 0x54000620
.word 0xf9001001
.word 0x91008002
.word 0xd349fc42
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0042

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x3, [x16, #16]
.word 0x8b030042
.word 0xd280003e
.word 0x3900005e

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #336]
.word 0xf9001401

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #344]
.word 0xf9002001

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #352]
.word 0xf9401422
.word 0xf9000c02
.word 0xf9401021
.word 0xf9000801
.word 0xd2800001
.word 0x3901801f
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9432e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9401bb1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0
.word 0xd2801fe0
.word 0xaa1103e1
bl _p_4
.word 0xd2801340
.word 0xaa1103e1
bl _p_4

Lme_a:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0xa90157b4
.word 0xaa0003f5
.word 0xf90013a1
.word 0xf90017a2
.word 0xf9001ba3
.word 0xf9001fa4
.word 0xf90023a5

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #360]
.word 0xf90027b0
.word 0xf9400a11
.word 0xf9002bb1
.word 0xd2800014
.word 0x910183a0
.word 0xd2800000
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf94027b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910183a0
.word 0xd2800000
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf94027b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0x910183a0
.word 0xaa0003f4
.word 0xf94027b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0x910183a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #368]
.word 0xf9400021
.word 0xf94013a2
bl _p_16
.word 0xf94027b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf9400aa0
.word 0xf9005ba0
.word 0xaa1503e0
.word 0xf9400ea0
.word 0xf9004fa0
.word 0xaa1403e0
bl _p_6
.word 0xf90053a0
.word 0xf94027b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
.word 0xf90057a0
.word 0xf94027b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa1
.word 0xf94053a2
.word 0xf94057a3
.word 0xf9405ba7
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xb94043a6
.word 0xaa0703e0
.word 0xf9004ba7
.word 0xf9400cf0
.word 0xd63f0200
.word 0xf9404ba0
.word 0xf94027b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
bl _p_17
.word 0xf94027b1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94157b4
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_b:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xa90167b8
.word 0xf90013a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #376]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800019
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
.word 0xf94013a0
bl _p_1
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf90023a0
.word 0xaa0003f9
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xaa0003e1
bl _p_2
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xb4000178
.word 0xf9400300
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #224]
.word 0xeb01001f
.word 0x10000011
.word 0x54000481
.word 0xaa1803e0
.word 0xaa1803e0
.word 0xf9400f10
.word 0xd63f0200
.word 0xf90027a0
.word 0xf94017b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xd2800021
.word 0xd2800021
bl _p_18
.word 0xf90023a0
.word 0xf94017b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94017b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94167b8
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_4

Lme_10:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor
ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor:
.loc 1 1 0
.word 0xa9bd7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #384]
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
.word 0xd2800000

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #392]
.word 0xd2800e01
.word 0xd2800e01
bl _p_5
.word 0xaa0003e1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #400]
.word 0xf9001420

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #408]
.word 0xf9002020

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #416]
.word 0xf9401402
.word 0xf9000c22
.word 0xf9401000
.word 0xf9000820
.word 0xd2800000
.word 0x3901803f

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #368]
.word 0xf9000001
.word 0xf9400bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c37bfd
.word 0xd65f03c0

Lme_11:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_
ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
.word 0xf94013b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_6
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_7
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9000f20
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #432]
.word 0xaa1a03e0
bl _p_19
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf9000b20
.word 0x91004321
.word 0xd349fc21
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0021

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #16]
.word 0x8b020021
.word 0xd280003e
.word 0x3900003e
.word 0xf94013b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_12:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize
ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #440]
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
.word 0xf9400c00
bl _p_9
.word 0xf9400fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9001bbf
.word 0x94000005
.word 0xf9401ba0
.word 0xb4000040
bl _p_10
.word 0x14000012
.word 0xf90027be
.word 0xf9400fb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_11
.word 0xf9400fb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027be
.word 0xd61f03c0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000001
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_13:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr
ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #448]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800019
.word 0xf9401bb1
.word 0xf9403e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #312]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_12
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000200
.word 0xf9401bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x14000098
.word 0xf9401bb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_13
.word 0x53001c00
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0x34000700
.word 0xf9401bb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_1
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
bl _p_2
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803f7
.word 0xeb1f031f
.word 0x54000160
.word 0xf9400300
.word 0xf9400000
.word 0xf9400800
.word 0xf9400c00

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #224]
.word 0xeb01001f
.word 0x54000040
.word 0xd2800017
.word 0xaa1703e0
.word 0xaa1703f9
.word 0xf9401bb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb4000217
.word 0xf9401bb1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x14000052
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9420e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_1
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #456]
bl _p_14
.word 0xf94037a1
.word 0xf90033a0
bl _p_20
.word 0xf9401bb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf9002fa0
.word 0xeb1f001f
.word 0x10000011
.word 0x540007c0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #464]
.word 0xd2800e01
.word 0xd2800e01
bl _p_5
.word 0xf9402fa1
.word 0xeb1f003f
.word 0x10000011
.word 0x54000620
.word 0xf9001001
.word 0x91008002
.word 0xd349fc42
.word 0xd29ffffe
.word 0xf2a00ffe
.word 0x8a1e0042

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x3, [x16, #16]
.word 0x8b030042
.word 0xd280003e
.word 0x3900005e

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #472]
.word 0xf9001401

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #480]
.word 0xf9002001

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #488]
.word 0xf9401422
.word 0xf9000c02
.word 0xf9401021
.word 0xf9000801
.word 0xd2800001
.word 0x3901801f
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9432e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9401bb1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xa9426bb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0
.word 0xd2801fe0
.word 0xaa1103e1
bl _p_4
.word 0xd2801340
.word 0xaa1103e1
bl _p_4

Lme_14:
.text
	.align 4
	.no_dead_strip ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke
ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #496]
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
.word 0xf9400b42
.word 0xaa1a03e0
.word 0xf9400f41
.word 0xaa0203e0
.word 0xf90023a2
.word 0xf9400c50
.word 0xd63f0200
.word 0xaa0003e1
.word 0xf94023a0
.word 0xf9001fa1
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_21
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400fb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_15:
.text
	.align 4
	.no_dead_strip ApiDefinition_Messaging__cctor
ApiDefinition_Messaging__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #504]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #512]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #520]
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

Lme_27:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #528]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
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

Lme_28:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor
Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #544]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_29:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #568]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_2a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #576]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_2b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #584]
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
.word 0xf9400fa0
bl _p_29
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xf9002ba0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_1@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_1@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
.word 0xaa0203e3
bl _p_30
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
bl _p_31
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_2c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #592]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_2@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_2@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
.word 0xf9001fa0
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #600]
bl _p_32
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400bb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_2d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #608]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_3@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_3@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_33
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

Lme_2e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #616]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
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
bl _p_33
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

Lme_2f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #624]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_5@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_5@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_33
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

Lme_30:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #632]
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
bl _p_34
.word 0x93407c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xd2800101
.word 0x6b01001f
.word 0x54000421
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_6@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_6@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_35
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa0003fa
.word 0xf9400fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001d
.word 0xf9400fb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_6@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_6@PAGEOFF
ldr x0, [x0]
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xf94023a1
bl _p_36
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0x2a0003e0
.word 0xaa0003fa
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xf9400fb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_31:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xa9026bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #640]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9002fa0
adrp x0, L_OBJC_SELECTOR_REFERENCES_7@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_7@PAGEOFF
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
bl _p_25
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #312]
.word 0xf9400000
.word 0xaa0003f7
.word 0xaa1903e0
.word 0xaa1803e0
.word 0xaa1703e0
.word 0xaa1903e0
.word 0xaa1803e1
.word 0xaa1703e2
bl _p_30
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

Lme_32:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #648]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_8@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_8@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0x394043a2
bl _p_37
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

Lme_33:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa9016bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #656]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xd2800019
.word 0x9100e3a0
.word 0xd2800000
.word 0xf9001fa0
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf94013b1
.word 0xf9405a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2801ee1
.word 0xd2801ee1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0x9100e3a0
.word 0xd2800000
.word 0xf9001fa0
.word 0xf90023a0
.word 0xf90027a0
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0x9100e3a0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0x9100e3a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #272]
.word 0xf9400021
.word 0xaa1a03e2
.word 0xd2800022

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x4, [x16, #664]
.word 0xaa1a03e2
.word 0xd2800023
bl _p_40
.word 0xf94013b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9003ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_9@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_9@PAGEOFF
ldr x0, [x0]
.word 0xf9003fa0
.word 0xf94013b1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
bl _p_6
.word 0xf90043a0
.word 0xf94013b1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xf9403fa1
.word 0xf94043a2
bl _p_30
.word 0xf94013b1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
bl _p_17
.word 0xf94013b1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9416bb9
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_34:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #672]
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
bl _p_34
.word 0x93407c00
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xd2800101
.word 0x6b01001f
.word 0x54000401
.word 0xf9400fb1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_10@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_10@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_41
.word 0xf9400fb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400001f
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_10@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_10@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xaa1a03e2
.word 0xaa1a03e2
bl _p_42
.word 0xf9400fb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_35:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #680]
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
.word 0xf9400fa0
bl _p_29
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9407631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0
.word 0xf9002ba0
.word 0xaa0003f9
.word 0xf94013b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_11@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_11@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xf9402ba2
.word 0xaa0203e3
bl _p_30
.word 0xf94013b1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
bl _p_31
.word 0xf94013b1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb9
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_36:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #688]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2802e61
.word 0xd2802e61
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_12@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_12@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xf94023a2
bl _p_30
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

Lme_37:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #696]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf90023a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_13@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_13@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400bb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
.word 0xf9001fa0
.word 0xf9400bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #704]
bl _p_43
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9400bb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c57bfd
.word 0xd65f03c0

Lme_38:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xf90013ba
.word 0xf90017a0
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #712]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800018
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28038a1
.word 0xd28038a1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_29
.word 0xf90043a0
.word 0xf9401bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f8
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_44
.word 0xf9003fa0
.word 0xf9401bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xf9003ba0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9002ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_14@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_14@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba1
.word 0xaa1803e0
.word 0xf90033a0
.word 0xaa0103e0
.word 0xaa0103e0
.word 0x3940003e
bl _p_25
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xf94033a2
.word 0xf94037a3
bl _p_45
.word 0xf9401bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
bl _p_31
.word 0xf9401bb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e1
.word 0xaa0103e0
.word 0x3940003e
bl _p_46
.word 0xf9401bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9422231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94163b7
.word 0xf94013ba
.word 0x910003bf
.word 0xa8c97bfd
.word 0xd65f03c0

Lme_39:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class
Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #720]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2803fe1
.word 0xd2803fe1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9400fb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
.word 0xf9400000
.word 0xf9001ba0
adrp x0, L_OBJC_SELECTOR_REFERENCES_15@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_15@PAGEOFF
ldr x0, [x0]
.word 0xf9001fa0
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_47
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xf9401fa1
.word 0xf94023a2
bl _p_30
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

Lme_3a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor
Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #728]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #736]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #536]
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

Lme_3b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #744]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #752]
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

Lme_3c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #760]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_3d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #768]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_3e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #776]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_3f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb8
.word 0xf9000fa0
.word 0xf90013a1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #784]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xd2800018
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
.word 0xf94013a0
bl _p_29
.word 0xf9002ba0
.word 0xf94017b1
.word 0xf9407a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xaa0003f8
.word 0xf94017b1
.word 0xf9409231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
bl _p_25
.word 0xf90023a0
.word 0xf94017b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_16@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_16@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf94017b1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
.word 0xaa1803e2
bl _p_30
.word 0xf94017b1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
bl _p_31
.word 0xf94017b1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb8
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_40:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xf90013a0
.word 0xf90017a1
.word 0xf9001ba2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #792]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xd2800017
.word 0xd2800016
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
.word 0xf94017a0
bl _p_29
.word 0xf90037a0
.word 0xf9401fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xaa0003f7
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
bl _p_29
.word 0xf90033a0
.word 0xf9401fb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f6
.word 0xf9401fb1
.word 0xf940ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
bl _p_25
.word 0xf9002ba0
.word 0xf9401fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_17@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_17@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401fb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xaa1703e2
.word 0xaa1603e3
bl _p_45
.word 0xf9401fb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_31
.word 0xf9401fb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
bl _p_31
.word 0xf9401fb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_41:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb7
.word 0xf9000fb9
.word 0xf90013a0
.word 0xaa0103f9
.word 0xf90017a2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #800]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2805221
.word 0xd2805221
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_29
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
bl _p_25
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_18@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_18@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x3940033e
bl _p_25
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xf94033a2
.word 0xaa1703e3
bl _p_45
.word 0xf9401bb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_31
.word 0xf9401bb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb7
.word 0xf9400fb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_42:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb7
.word 0xf9000fa0
.word 0xf90013a1
.word 0xf90017a2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #808]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_29
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
bl _p_25
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_19@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_19@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0x394083a2
.word 0xaa1703e3
bl _p_49
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
.word 0xf9401bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9419631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_31
.word 0xf9401bb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb7
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_43:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb7
.word 0xf9000fb9
.word 0xf90013a0
.word 0xaa0103f9
.word 0xf90017a2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #816]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xd2800017
.word 0xf9401bb1
.word 0xf9404631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2805221
.word 0xd2805221
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9401bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_29
.word 0xf90037a0
.word 0xf9401bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
.word 0xaa0003f7
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
bl _p_25
.word 0xf9002ba0
.word 0xf9401bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_20@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_20@PAGEOFF
ldr x0, [x0]
.word 0xf9002fa0
.word 0xf9401bb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x3940033e
bl _p_25
.word 0xf90033a0
.word 0xf9401bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402ba0
.word 0xf9402fa1
.word 0xf94033a2
.word 0xaa1703e3
bl _p_45
.word 0xf9401bb1
.word 0xf941aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9420a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9424a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
bl _p_31
.word 0xf9401bb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9428231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bb7
.word 0xf9400fb9
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_44:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor
Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #824]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #832]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #752]
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

Lme_45:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #840]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #848]
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

Lme_46:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor
Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #856]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_50
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_47:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #864]
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
bl _p_50
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_48:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #872]
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
bl _p_51
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_49:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice
Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xf9000fa0
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #880]
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
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28064e1
.word 0xd28064e1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
bl _p_25
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_21@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_21@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_25
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xf9402fa2
bl _p_52
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94013b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_4a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #888]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_22@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_22@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_4b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #896]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_23@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_23@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_4c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #904]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_24@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_24@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_4d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #912]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_25@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_25@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_4e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #920]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_26@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_26@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_4f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #928]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_27@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_27@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_50:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #936]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_28@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_28@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_51:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #944]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_29@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_29@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_52:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #952]
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
bl _p_25
.word 0xf90033a0
.word 0xf94013b1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_30@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_30@PAGEOFF
ldr x0, [x0]
.word 0xf90037a0
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
bl _p_26
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #960]
bl _p_53
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

Lme_53:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #968]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_31@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_31@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_54:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #976]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_32@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_32@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_55:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #984]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_33@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_33@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_56:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #992]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_34@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_34@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_57:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1000]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_35@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_35@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_58:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1008]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_36@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_36@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_59:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset
Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xf9000fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1016]
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
bl _p_25
.word 0xf90033a0
.word 0xf94013b1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_37@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_37@PAGEOFF
ldr x0, [x0]
.word 0xf90037a0
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94037a1
bl _p_26
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fa0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x15, [x16, #960]
bl _p_53
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

Lme_5a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor
Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1024]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1032]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #848]
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

Lme_5b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1040]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1048]
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

Lme_5c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor
Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1056]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_5d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1064]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_5e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1072]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_5f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint
Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f5
.word 0xaa0103f6
.word 0xaa0203f7
.word 0xaa0303f8
.word 0xaa0403f9
.word 0xaa0503fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1080]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800014
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xd2800013
.word 0xf9402bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb5000255
.word 0xf9402bb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28093a1
.word 0xd28093a1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9402bb1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb5000257
.word 0xf9402bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28097a1
.word 0xd28097a1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9402bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xd2800000
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf90043a0
.word 0xf90047a0
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9419e31
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #368]
.word 0xf9400021
.word 0xaa1503e2
.word 0xd2800022

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x4, [x16, #1088]
.word 0xaa1503e2
.word 0xd2800023
bl _p_40
.word 0xf9402bb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_29
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9422a31
.word 0xb4000051
.word 0xd63f0220
bl _p_34
.word 0x93407c00
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9424631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xd2800101
.word 0x6b01001f
.word 0x54000621
.word 0xf9402bb1
.word 0xf9426631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1048]
.word 0xf9400000
.word 0xf90053a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_38@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_38@PAGEOFF
ldr x0, [x0]
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_6
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf942ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xf94057a1
.word 0xf9405ba2
.word 0xaa1603e3
.word 0xaa1303e3
.word 0xaa1803e3
.word 0xaa1903e3
.word 0xaa1a03e3
.word 0xaa1603e3
.word 0xaa1303e4
.word 0xaa1803e5
.word 0xaa1903e6
.word 0xaa1a03e7
bl _p_54
.word 0xf9402bb1
.word 0xf9430231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9431231
.word 0xb4000051
.word 0xd63f0220
.word 0x1400002c
.word 0xf9402bb1
.word 0xf9432631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1048]
.word 0xf9400000
.word 0xf90053a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_38@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_38@PAGEOFF
ldr x0, [x0]
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf9435a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_6
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9437a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94053a0
.word 0xf94057a1
.word 0xf9405ba2
.word 0xaa1603e3
.word 0xaa1603e3
.word 0xaa1303e4
.word 0xaa1803e4
.word 0xaa1903e4
.word 0xaa1a03e4
.word 0xaa1303e4
.word 0xaa1803e5
.word 0xaa1903e6
.word 0xaa1a03e7
bl _p_55
.word 0xf9402bb1
.word 0xf943c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_17
.word 0xf9402bb1
.word 0xf943fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9440e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_31
.word 0xf9402bb1
.word 0xf9442a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9443a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9444a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_60:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor
Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1096]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1104]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1048]
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

Lme_61:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool
Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1112]
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
bl _p_56
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

Lme_62:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSService__ctor
Microsoft_AppCenter_iOS_Bindings_MSService__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1120]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_57
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
bl _p_58
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf9425e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_63:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1128]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_64:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1136]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_65:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled
Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1144]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xd2801101
.word 0xd2801101
bl _p_5
.word 0xf9001ba0
bl _p_59
.word 0xf9400bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
bl _p_39
.word 0xf9400bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_66:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool
Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1160]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1152]
.word 0xd2801101
.word 0xd2801101
bl _p_5
.word 0xf9001ba0
bl _p_59
.word 0xf9400fb1
.word 0xf9408231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
bl _p_39
.word 0xf9400fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0x910003bf
.word 0xa8c47bfd
.word 0xd65f03c0

Lme_67:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1168]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1176]
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

Lme_68:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor
Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1184]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_60
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_69:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1192]
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
bl _p_60
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_6a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1200]
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
bl _p_61
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_6b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor
Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1208]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1216]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1176]
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

Lme_6c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1224]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1232]
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

Lme_6d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1240]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_6e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1248]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_6f:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1256]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_70:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001bba
.word 0xaa0003f8
.word 0xaa0103f9
.word 0xaa0203fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1264]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xd2800017
.word 0x910143a0
.word 0xd2800000
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xd2800016
.word 0xf9401fb1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xb5000258
.word 0xf9401fb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd280aaa1
.word 0xd280aaa1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9401fb1
.word 0xf940ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb5000259
.word 0xf9401fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd28097a1
.word 0xd28097a1
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf9401fb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xd2800000
.word 0xf9002ba0
.word 0xf9002fa0
.word 0xf90033a0
.word 0xf90037a0
.word 0xf9003ba0
.word 0xf9003fa0
.word 0xf9401fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xaa0003f7
.word 0xf9401fb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #368]
.word 0xf9400021
.word 0xaa1803e2
.word 0xd2800022

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x4, [x16, #1088]
.word 0xaa1803e2
.word 0xd2800023
bl _p_40
.word 0xf9401fb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_29
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9420231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
.word 0xaa0003f6
.word 0xf9401fb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
bl _p_34
.word 0x93407c00
.word 0xf90043a0
.word 0xf9401fb1
.word 0xf9423631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xd2800101
.word 0x6b01001f
.word 0x54000561
.word 0xf9401fb1
.word 0xf9425631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1232]
.word 0xf9400000
.word 0xf90043a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_39@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_39@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9428a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_6
.word 0xf9004ba0
.word 0xf9401fb1
.word 0xf942aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xaa1603e3
.word 0xaa1a03e3
.word 0xaa1603e3
.word 0xaa1a03e4
bl _p_62
.word 0xf9401fb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf942ea31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000026
.word 0xf9401fb1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1232]
.word 0xf9400000
.word 0xf90043a0
adrp x0, L_OBJC_SELECTOR_REFERENCES_39@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_39@PAGEOFF
ldr x0, [x0]
.word 0xf90047a0
.word 0xf9401fb1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_6
.word 0xf9004ba0
.word 0xf9401fb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xf94047a1
.word 0xf9404ba2
.word 0xaa1603e3
.word 0xaa1a03e3
.word 0xaa1a03e4
.word 0xaa1603e3
bl _p_63
.word 0xf9401fb1
.word 0xf9438231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_17
.word 0xf9401fb1
.word 0xf943be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_31
.word 0xf9401fb1
.word 0xf943ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf943fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9440a31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0xf9401bba
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_71:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor
Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1272]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1280]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1232]
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

Lme_72:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1288]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1296]
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

Lme_73:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1304]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1a03e0
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf9410e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a1
.word 0xaa1a03e0
bl _p_24
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
bl _p_25
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
bl _p_26
.word 0xf9001ba0
.word 0xf9400fb1
.word 0xf941ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #560]
.word 0xaa1a03e0
bl _p_27
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

Lme_74:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1312]
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
bl _p_22
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_75:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bb9
.word 0xaa0003f9
.word 0xf9000fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1320]
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
bl _p_28
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a1
.word 0xaa1903e0
bl _p_24
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

Lme_76:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xaa0003f4
.word 0xf90013a1
.word 0xf90017a2
.word 0xf9001ba3
.word 0xf9001fa4
.word 0xf90023a5
.word 0xf90027a6

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1328]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800013
.word 0xf90037bf
.word 0xf9003bbf
.word 0xf9003fbf
.word 0xf90043bf
.word 0xf90047bf
.word 0xf9402bb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #552]
.word 0xf9400001
.word 0xaa1403e0
bl _p_22
.word 0xf9402bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013a0
bl _p_29
.word 0xf90077a0
.word 0xf9402bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94077a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017a0
bl _p_29
.word 0xf90073a0
.word 0xf9402bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94073a0
.word 0xf90037a0
.word 0xf9402bb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
bl _p_29
.word 0xf9006fa0
.word 0xf9402bb1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406fa0
.word 0xf9003ba0
.word 0xf9402bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
bl _p_29
.word 0xf9006ba0
.word 0xf9402bb1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9406ba0
.word 0xf9003fa0
.word 0xf9402bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
bl _p_29
.word 0xf90067a0
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94067a0
.word 0xf90043a0
.word 0xf9402bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
bl _p_29
.word 0xf90063a0
.word 0xf9402bb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94063a0
.word 0xf90047a0
.word 0xf9402bb1
.word 0xf941fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0xf9400280
.word 0xf9400c00
.word 0xf9005fa0
.word 0xf9402bb1
.word 0xf9421e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405fa1
.word 0xaa0103e0
.word 0xf9400021
.word 0xf941a430
.word 0xd63f0200
.word 0xf9005ba0
.word 0xf9402bb1
.word 0xf9424631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9405ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #520]
.word 0xf9400021
bl _p_23
.word 0x53001c00
.word 0xf90057a0
.word 0xf9402bb1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94057a1
.word 0xaa1403e0
bl _p_24
.word 0xf9402bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942c231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_25
.word 0xf9004fa0
.word 0xf9402bb1
.word 0xf942f631
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_40@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_40@PAGEOFF
ldr x0, [x0]
.word 0xf90053a0
.word 0xf9402bb1
.word 0xf9431631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404fa0
.word 0xf94053a1
.word 0xaa1303e2
.word 0xf94037a3
.word 0xf9403ba4
.word 0xf9403fa5
.word 0xf94043a6
.word 0xf94047a7
bl _p_64
.word 0xf9004ba0
.word 0xf9402bb1
.word 0xf9434e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #1336]
.word 0xaa1403e0
bl _p_27
.word 0xf9402bb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9438631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9439631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf943f631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9440631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9441631
.word 0xb4000051
.word 0xd63f0220
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
.word 0xf9402bb1
.word 0xf9445631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9446631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9447631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
bl _p_31
.word 0xf9402bb1
.word 0xf9448e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9449e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037a0
bl _p_31
.word 0xf9402bb1
.word 0xf944b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
bl _p_31
.word 0xf9402bb1
.word 0xf944de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf944ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
bl _p_31
.word 0xf9402bb1
.word 0xf9450631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9451631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
bl _p_31
.word 0xf9402bb1
.word 0xf9452e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9453e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94047a0
bl _p_31
.word 0xf9402bb1
.word 0xf9455631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9456631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9457631
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_77:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk:
.loc 1 1 0
.word 0xa9ba7bfd
.word 0x910003fd
.word 0xf9000bba
.word 0xf9000fa0
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1344]
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
.word 0xaa1a03e0
.word 0xb500025a
.word 0xf94013b1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #0]
.word 0xd2802e61
.word 0xd2802e61
bl _p_38
.word 0xaa0003e1
.word 0xd2801360
.word 0xf2a04000
.word 0xd2801360
.word 0xf2a04000
bl _mono_create_corlib_exception_1
bl _p_39
.word 0xf94013b1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
bl _p_25
.word 0xf90027a0
.word 0xf94013b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_21@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_21@PAGEOFF
ldr x0, [x0]
.word 0xf9002ba0
.word 0xf94013b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x3940035e
bl _p_25
.word 0xf9002fa0
.word 0xf94013b1
.word 0xf9414631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027a0
.word 0xf9402ba1
.word 0xf9402fa2
bl _p_52
.word 0x53001c00
.word 0xf90023a0
.word 0xf94013b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94013b1
.word 0xf941a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400bba
.word 0x910003bf
.word 0xa8c67bfd
.word 0xd65f03c0

Lme_78:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1352]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_41@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_41@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_79:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1360]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_42@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_42@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_7a:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1368]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_43@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_43@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_7b:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1376]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_44@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_44@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_7c:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1384]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_45@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_45@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_7d:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion:
.loc 1 1 0
.word 0xa9bb7bfd
.word 0x910003fd
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1392]
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
bl _p_25
.word 0xf90023a0
.word 0xf9400fb1
.word 0xf9409e31
.word 0xb4000051
.word 0xd63f0220
adrp x0, L_OBJC_SELECTOR_REFERENCES_46@PAGE
add x0, x0, L_OBJC_SELECTOR_REFERENCES_46@PAGEOFF
ldr x0, [x0]
.word 0xf90027a0
.word 0xf9400fb1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023a0
.word 0xf94027a1
bl _p_26
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

Lme_7e:
.text
	.align 4
	.no_dead_strip Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor
Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor:
.loc 1 1 0
.word 0xa9bc7bfd
.word 0x910003fd

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1400]
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1408]
bl _p_48
.word 0xf9001ba0
.word 0xf9400bb1
.word 0xf9407231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1296]
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

Lme_7f:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f4
.word 0xaa0103f5
.word 0xaa0203f6
.word 0xaa0303f7
.word 0xaa0403f8
.word 0xf9002ba5
.word 0xf9002fa6

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1416]
.word 0xf90033b0
.word 0xf9400a11
.word 0xf90037b1
.word 0xd2800013
.word 0xb9007bbf
.word 0xd280001a
.word 0xd2800019
.word 0xf90043bf
.word 0xf94033b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf94033b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xf90047a0
.word 0xf94047a1
.word 0xf94047a0
.word 0xf9004ba1
.word 0xb4000060
.word 0xf9404ba0
bl _p_39
.word 0xf9404ba0
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x9101a280
.word 0xf9403680
.word 0xaa0003fa
.word 0xf94033b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb500093a
.word 0xf94033b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x91008280
.word 0xf9401280
.word 0xf90043a0
.word 0xf94033b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xb40003c0
.word 0xf94033b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa1503e1
.word 0xaa1603e1
.word 0xaa1703e1
.word 0xaa1803e1
.word 0xf9402ba5
.word 0xb9405ba6
.word 0xaa1403e1
.word 0xaa1403e1
.word 0x9100e281
.word 0xf9401e81
.word 0xaa1403e1
.word 0xaa1403e1
.word 0x91004281
.word 0xf9400a87
.word 0xaa1503e1
.word 0xaa1603e2
.word 0xaa1703e3
.word 0xaa1803e4
.word 0xd63f00e0
.word 0xf94033b1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0x14000068
.word 0xf94033b1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1603e0
.word 0xaa1703e0
.word 0xaa1803e0
.word 0xf9402ba4
.word 0xb9405ba5
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x9100e280
.word 0xf9401e80
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x91004280
.word 0xf9400a86
.word 0xaa1503e0
.word 0xaa1603e1
.word 0xaa1703e2
.word 0xaa1803e3
.word 0xd63f00c0
.word 0xf94033b1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400004c
.word 0xf94033b1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb9801b40
.word 0xb9007ba0
.word 0xf94033b1
.word 0xf9427e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800013
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf942a231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1303e0
.word 0x93407e60
.word 0xb9801b41
.word 0xeb00003f
.word 0x10000011
.word 0x54000789
.word 0xd37df000
.word 0x8b000340
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f9
.word 0xf94033b1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf90053a0
.word 0xaa1503e0
.word 0xaa1603e0
.word 0xaa1703e0
.word 0xaa1803e0
.word 0xf9402ba5
.word 0xb9405ba6
.word 0xaa1903e0
.word 0xaa1503e1
.word 0xaa1603e2
.word 0xaa1703e3
.word 0xaa1803e4
.word 0xf9400f30
.word 0xd63f0200
.word 0xf94053a0
.word 0xf94033b1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0x11000660
.word 0xaa0003f3
.word 0xf94033b1
.word 0xf9435e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xb9807ba0
.word 0x6b00027f
.word 0x54fff8cb
.word 0xf94033b1
.word 0xf9437e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9438e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_4

Lme_89:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001bbc
.word 0x910283bc
.word 0xf9001fa0
.word 0xf90023a1
.word 0xf90027a2
.word 0xf9002ba3
.word 0xf9002fa4
.word 0xf90033a5
.word 0xf90037a6
.word 0xf9003ba7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1432]
.word 0xf9003fb0
.word 0xf9400a11
.word 0xf90043b1
.word 0xd2800019
.word 0xd2800018
.word 0xf9403fb1
.word 0xf9406631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fb1
.word 0xf9408631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800917
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
.word 0xf9403fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603f8
.word 0xf9403fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x910103a0
.word 0xf90002c0
.word 0xf9403fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xd2800100
.word 0x93407c00
.word 0x910022c0
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910123a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910143a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf941be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910163a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf941da31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf941fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910183a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf9423e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9101a3a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf9425a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf9427e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9101c3a0
.word 0xf9000300
.word 0xf9403fb1
.word 0xf9429a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403fb1
.word 0xf942be31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1c03e0
.word 0xf900031c
.word 0xf9403fb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fa0
.word 0xaa1603e1
.word 0xaa1603e1
bl _p_66
.word 0xf9004ba0
.word 0xf94043b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fb1
.word 0xf9430e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xf9403fb1
.word 0xf9432231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0xf9401bbc
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_8a:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1440]
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
bl _p_67
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

Lme_8b:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint
wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003bbe
.word 0xa907d3b3
.word 0xa908dbb5
.word 0xa909e3b7
.word 0xa90aebb9
.word 0xa90bf3bb
.word 0xf90067bd
.word 0x910003f1
.word 0xf9006bb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1448]
.word 0xf90027b0
.word 0xf9400a11
.word 0xf9002bb1
.word 0xf9006fbf
.word 0xf90073bf
.word 0x3903a3bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f4
.word 0x910183a0
.word 0xf9400281
.word 0xf90033a1
.word 0xf9000280
.word 0xf94027b1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3903a3a0
.word 0xf94027b1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fa0
.word 0xf94013a1
.word 0xf94017a2
.word 0xf9401ba3
.word 0xf9401fa4
.word 0xb94043a5
.word 0xf9400ba6
.word 0xf94000c7
.word 0x3940b0e9
.word 0xeb1f013f
.word 0x10000011
.word 0x54000761
.word 0xf94000e7
.word 0xf94000e7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x9, [x16, #1456]
.word 0xeb0900ff
.word 0x10000011
.word 0x54000661
.word 0x910040c7
.word 0xf94008c6
.word 0xd63f00c0
.word 0xf94027b1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf94027b1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003fa
.word 0xaa1a03e0
.word 0xaa1a03e1
.word 0xaa0003f9
.word 0xb400009a
.word 0xaa1903e0
.word 0xaa1903e0
bl _p_39
.word 0xaa1903e0
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0x910183a0
.word 0xf94033a0
.word 0xf9000280
.word 0xf94027b1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043b4
.word 0xa94aebb9
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_4

Lme_8c:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b57bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f4
.word 0xaa0103f5
.word 0xaa0203f6
.word 0xaa0303f7
.word 0xf9002ba4
.word 0xf9002fa5
.word 0xf90033a6

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1464]
.word 0xf90037b0
.word 0xf9400a11
.word 0xf9003bb1
.word 0xd2800013
.word 0xd280001a
.word 0xd2800019
.word 0xd2800018
.word 0xf90043bf
.word 0xf94037b1
.word 0xf9406e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf94037b1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf940c231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xf90047a0
.word 0xf94047a1
.word 0xf94047a0
.word 0xf9004ba1
.word 0xb4000060
.word 0xf9404ba0
bl _p_39
.word 0xf9404ba0
.word 0xf9403bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9410631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x9101a280
.word 0xf9403680
.word 0xaa0003f9
.word 0xf94037b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb50004d9
.word 0xf94037b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1403e0
.word 0x91008280
.word 0xf9401280
.word 0xf90043a0
.word 0xf94037b1
.word 0xf9416631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa1503e1
.word 0xaa1603e1
.word 0xaa1703e1
.word 0xf9402ba4
.word 0xf9402fa5
.word 0xb94063a6
.word 0xaa1403e1
.word 0xaa1403e1
.word 0x9100e281
.word 0xf9401e81
.word 0xaa1403e1
.word 0xaa1403e1
.word 0x91004281
.word 0xf9400a87
.word 0xaa1503e1
.word 0xaa1603e2
.word 0xaa1703e3
.word 0xd63f00e0
.word 0xf94037b1
.word 0xf941c231
.word 0xb4000051
.word 0xd63f0220
.word 0x1400004b
.word 0xf94037b1
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xb9801b20
.word 0xaa0003fa
.word 0xf94037b1
.word 0xf941f231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800013
.word 0xf9403bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9421631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1303e0
.word 0x93407e60
.word 0xb9801b21
.word 0xeb00003f
.word 0x10000011
.word 0x54000769
.word 0xd37df000
.word 0x8b000320
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f8
.word 0xf94037b1
.word 0xf9425631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf90053a0
.word 0xaa1503e0
.word 0xaa1603e0
.word 0xaa1703e0
.word 0xf9402ba4
.word 0xf9402fa5
.word 0xb94063a6
.word 0xaa1803e0
.word 0xaa1503e1
.word 0xaa1603e2
.word 0xaa1703e3
.word 0xf9400f10
.word 0xd63f0200
.word 0xf94053a0
.word 0xf94037b1
.word 0xf942a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0x11000660
.word 0xaa0003f3
.word 0xf94037b1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xaa1a03e0
.word 0x6b1a027f
.word 0x54fff8eb
.word 0xf94037b1
.word 0xf942ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8cb7bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_4

Lme_8d:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr
wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1472]
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
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xf90037a0
.word 0xf94037a1
.word 0xf94037a0
.word 0xf9003ba1
.word 0xb4000060
.word 0xf9403ba0
bl _p_39
.word 0xf9403ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9101a320
.word 0xf9403720
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb50008d6
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91008320
.word 0xf9401320
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9415631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xb40003b4
.word 0xf9402bb1
.word 0xf9416e31
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
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x1400006c
.word 0xf9402bb1
.word 0xf941de31
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
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9422e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x14000052
.word 0xf9402bb1
.word 0xf9424631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb9801ac0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9426231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800018
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9428631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1803e0
.word 0x93407f00
.word 0xb9801ac1
.word 0xeb00003f
.word 0x10000011
.word 0x54000849
.word 0xd37df000
.word 0x8b0002c0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf90047a0
.word 0xaa1a03e0
.word 0xaa1503e0
.word 0xaa1a03e1
.word 0xf9400eb0
.word 0xd63f0200
.word 0xaa0003e1
.word 0xf94047a0
.word 0xf90043a1
.word 0xf9402bb1
.word 0xf942fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9431631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf9433231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1703e0
.word 0x6b17031f
.word 0x54fff94b
.word 0xf9402bb1
.word 0xf9435231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9437631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9402bb1
.word 0xf9438a31
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
bl _p_4

Lme_8e:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1
.word 0xf90023a2
.word 0xf90027a3

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1480]
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
bl _p_66
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

Lme_8f:
.text
	.align 4
	.no_dead_strip wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult
wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1488]
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
bl _p_67
.word 0xf9400001
.word 0x3940b022
.word 0xeb1f005f
.word 0x10000011
.word 0x540003c1
.word 0xf9400021
.word 0xf9400021

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x2, [x16, #1456]
.word 0xeb02003f
.word 0x10000011
.word 0x540002c1
.word 0x91004001
.word 0xf9400800
.word 0xf90033a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94023b1
.word 0xf9417e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_4

Lme_90:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1496]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
.word 0xf9400fa0
.word 0xf9400ba1
.word 0xf9400022
.word 0x3940b043
.word 0xeb1f007f
.word 0x10000011
.word 0x540008c1
.word 0xf9400042
.word 0xf9400042

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x3, [x16, #1456]
.word 0xeb03005f
.word 0x10000011
.word 0x540007c1
.word 0x91004022
.word 0xf9400821
.word 0xd63f0020
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf94013b1
.word 0xf9414e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
.word 0xaa1403e0
.word 0xf94017b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf941a631
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
.word 0xf941d631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xf94013b1
.word 0xf941ea31
.word 0xb4000051
.word 0xd63f0220
.word 0xa945d7b4
.word 0xa946dfb6
.word 0x910003bf
.word 0xa8cd7bfd
.word 0xd65f03c0
.word 0xd2801de0
.word 0xaa1103e1
bl _p_4

Lme_91:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr
wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr:
.loc 1 1 0
.word 0xa9b77bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f9
.word 0xaa0103fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1504]
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
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf9402bb1
.word 0xf940a231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940b231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xf90037a0
.word 0xf94037a1
.word 0xf94037a0
.word 0xf9003ba1
.word 0xb4000060
.word 0xf9403ba0
bl _p_39
.word 0xf9403ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x9101a320
.word 0xf9403720
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb50004d6
.word 0xf9402bb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1903e0
.word 0x91008320
.word 0xf9401320
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf9415631
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
.word 0xf90043a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0x14000052
.word 0xf9402bb1
.word 0xf941c631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xb9801ac0
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf941e231
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800018
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9420631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1803e0
.word 0x93407f00
.word 0xb9801ac1
.word 0xeb00003f
.word 0x10000011
.word 0x54000849
.word 0xd37df000
.word 0x8b0002c0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9424631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xf90047a0
.word 0xaa1a03e0
.word 0xaa1503e0
.word 0xaa1a03e1
.word 0xf9400eb0
.word 0xd63f0200
.word 0xaa0003e1
.word 0xf94047a0
.word 0xf90043a1
.word 0xf9402bb1
.word 0xf9427e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94043a0
.word 0xaa0003f3
.word 0xf9402bb1
.word 0xf9429631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x11000700
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xaa1703e0
.word 0x6b17031f
.word 0x54fff94b
.word 0xf9402bb1
.word 0xf942d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf942f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1303e0
.word 0xf9402bb1
.word 0xf9430a31
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
bl _p_4

Lme_92:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003f5
.word 0xaa0103f6
.word 0xaa0203f7
.word 0xaa0303f8
.word 0xf9002ba4
.word 0xf9002fa5

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1512]
.word 0xf90033b0
.word 0xf9400a11
.word 0xf90037b1
.word 0xd2800014
.word 0xd2800013
.word 0xd280001a
.word 0xd2800019
.word 0xf9003fbf
.word 0xf94033b1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf94033b1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf940be31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xf90043a0
.word 0xf94043a1
.word 0xf94043a0
.word 0xf90047a1
.word 0xb4000060
.word 0xf94047a0
bl _p_39
.word 0xf94047a0
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1503e0
.word 0x9101a2a0
.word 0xf94036a0
.word 0xaa0003fa
.word 0xf94033b1
.word 0xf9412631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb50008ba
.word 0xf94033b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1503e0
.word 0x910082a0
.word 0xf94012a0
.word 0xf9003fa0
.word 0xf94033b1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xb4000380
.word 0xf94033b1
.word 0xf9417a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fa0
.word 0xaa1603e1
.word 0xaa1703e1
.word 0xaa1803e1
.word 0xf9402ba4
.word 0xb9405ba5
.word 0xaa1503e1
.word 0xaa1503e1
.word 0x9100e2a1
.word 0xf9401ea1
.word 0xaa1503e1
.word 0xaa1503e1
.word 0x910042a1
.word 0xf9400aa6
.word 0xaa1603e1
.word 0xaa1703e2
.word 0xaa1803e3
.word 0xd63f00c0
.word 0xf94033b1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0x14000064
.word 0xf94033b1
.word 0xf941e631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1703e0
.word 0xaa1803e0
.word 0xf9402ba3
.word 0xb9405ba4
.word 0xaa1503e0
.word 0xaa1503e0
.word 0x9100e2a0
.word 0xf9401ea0
.word 0xaa1503e0
.word 0xaa1503e0
.word 0x910042a0
.word 0xf9400aa5
.word 0xaa1603e0
.word 0xaa1703e1
.word 0xaa1803e2
.word 0xd63f00a0
.word 0xf94033b1
.word 0xf9423a31
.word 0xb4000051
.word 0xd63f0220
.word 0x1400004a
.word 0xf94033b1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xb9801b40
.word 0xaa0003f3
.word 0xf94033b1
.word 0xf9426a31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800014
.word 0xf94037b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9428e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1403e0
.word 0x93407e80
.word 0xb9801b41
.word 0xeb00003f
.word 0x10000011
.word 0x54000749
.word 0xd37df000
.word 0x8b000340
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f9
.word 0xf94033b1
.word 0xf942ce31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9004ba0
.word 0xaa1603e0
.word 0xaa1703e0
.word 0xaa1803e0
.word 0xf9402ba4
.word 0xb9405ba5
.word 0xaa1903e0
.word 0xaa1603e1
.word 0xaa1703e2
.word 0xaa1803e3
.word 0xf9400f30
.word 0xd63f0200
.word 0xf9404ba0
.word 0xf94033b1
.word 0xf9431631
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9432631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0x11000680
.word 0xaa0003f4
.word 0xf94033b1
.word 0xf9434231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xaa1303e0
.word 0x6b13029f
.word 0x54fff90b
.word 0xf94033b1
.word 0xf9436231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033b1
.word 0xf9437231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94153b3
.word 0xa9425bb5
.word 0xa94363b7
.word 0xa9446bb9
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0
.word 0xd2801d60
.word 0xaa1103e1
bl _p_4

Lme_93:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1
.word 0xf90023a2
.word 0xf90027a3
.word 0xf9002ba4
.word 0xf9002fa5
.word 0xf90033a6
.word 0xf90037a7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1520]
.word 0xf9003bb0
.word 0xf9400a11
.word 0xf9003fb1
.word 0xd2800019
.word 0xd2800018
.word 0xf9403bb1
.word 0xf9405e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb1
.word 0xf9407e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800817
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
.word 0xf9403bb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603f8
.word 0xf9403bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x9100e3a0
.word 0xf90002c0
.word 0xf9403bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xd2800100
.word 0x93407c00
.word 0x910022c0
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910103a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910123a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910143a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf941f631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910163a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf9421231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf9423631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910183a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf9425231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xd2800100
.word 0x93407c00
.word 0x91002300
.word 0xaa0003f8
.word 0xf9403bb1
.word 0xf9427631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9101a3a0
.word 0xf9000300
.word 0xf9403bb1
.word 0xf9429231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa1603e1
.word 0xaa1603e1
bl _p_66
.word 0xf9004ba0
.word 0xf9403fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403bb1
.word 0xf942c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xf9403bb1
.word 0xf942da31
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_94:
.text
	.align 4
	.no_dead_strip wrapper_delegate_invoke__Module_invoke_string
wrapper_delegate_invoke__Module_invoke_string:
.loc 1 1 0
.word 0xa9b87bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xa9025bb5
.word 0xa90363b7
.word 0xa9046bb9
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1528]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xd2800019
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90037a0
.word 0xb4000073
.word 0xf94037a0
bl _p_39
.word 0xf94037a0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x9101a340
.word 0xf9403740
.word 0xaa0003f7
.word 0xf9402bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb5000857
.word 0xf9402bb1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x91008340
.word 0xf9401340
.word 0xaa0003f5
.word 0xf9402bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xb4000375
.word 0xf9402bb1
.word 0xf9416a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1503e0
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x9100e340
.word 0xf9401f40
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x91004340
.word 0xf9400b41
.word 0xaa1503e0
.word 0xd63f0020
.word 0xf9003ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x14000068
.word 0xf9402bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x9100e340
.word 0xf9401f40
.word 0xaa1a03e0
.word 0xaa1a03e0
.word 0x91004340
.word 0xf9400b40
.word 0xd63f0000
.word 0xf9003ba0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9421a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0x14000050
.word 0xf9402bb1
.word 0xf9423231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xb9801ae0
.word 0xaa0003f8
.word 0xf9402bb1
.word 0xf9424e31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800019
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9427231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1703e0
.word 0xaa1903e0
.word 0x93407f20
.word 0xb9801ae1
.word 0xeb00003f
.word 0x10000011
.word 0x54000809
.word 0xd37df000
.word 0x8b0002e0
.word 0x91008000
.word 0xf9400000
.word 0xaa0003f6
.word 0xf9402bb1
.word 0xf942b231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xf9003fa0
.word 0xaa1603e0
.word 0xf9400ed0
.word 0xd63f0200
.word 0xaa0003e1
.word 0xf9403fa0
.word 0xf9003ba1
.word 0xf9402bb1
.word 0xf942e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9403ba0
.word 0xaa0003f4
.word 0xf9402bb1
.word 0xf942fa31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x11000720
.word 0xaa0003f9
.word 0xf9402bb1
.word 0xf9431631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xaa1803e0
.word 0x6b18033f
.word 0x54fff98b
.word 0xf9402bb1
.word 0xf9433631
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9435a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1403e0
.word 0xf9402bb1
.word 0xf9436e31
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
bl _p_4

Lme_95:
.text
	.align 4
	.no_dead_strip wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object
wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1
.word 0xf90023a2

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1536]
.word 0xf90027b0
.word 0xf9400a11
.word 0xf9002bb1
.word 0xd2800019
.word 0xd2800018
.word 0xf94027b1
.word 0xf9404a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9406a31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800317
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
.word 0xf94027b1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xaa1603f8
.word 0xf94027b1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0x9100e3a0
.word 0xf90002c0
.word 0xf94027b1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1603e0
.word 0xd2800100
.word 0x93407c00
.word 0x910022c0
.word 0xaa0003f8
.word 0xf94027b1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x910103a0
.word 0xf9000300
.word 0xf94027b1
.word 0xf9413e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401ba0
.word 0xaa1603e1
.word 0xaa1603e1
bl _p_66
.word 0xf90033a0
.word 0xf9402bb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94027b1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94027b1
.word 0xf9418631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_96:
.text
	.align 4
	.no_dead_strip wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult
wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult:
.loc 1 1 0
.word 0xa9b97bfd
.word 0x910003fd
.word 0xa9015fb6
.word 0xa90267b8
.word 0xf9001ba0
.word 0xf9001fa1

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1544]
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
bl _p_67
.word 0xf90033a0
.word 0xf94027b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9412e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94033a0
.word 0xf94023b1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xa9415fb6
.word 0xa94267b8
.word 0x910003bf
.word 0xa8c77bfd
.word 0xd65f03c0

Lme_97:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90023be
.word 0xa904d3b3
.word 0xa905dbb5
.word 0xa906e3b7
.word 0xa907ebb9
.word 0xa908f3bb
.word 0xf9004fbd
.word 0x910003f1
.word 0xf90053b1
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1552]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf90057bf
.word 0xf9005bbf
.word 0x3902e3bf
.word 0xd2800018

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f7
.word 0x9100c3a0
.word 0xf94002e1
.word 0xf9001ba1
.word 0xf90002e0
.word 0xf9400fb1
.word 0xf9408e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3902e3a0
.word 0xf9400fb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_68
.word 0xaa0003f8
.word 0xf9400fb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9400fb1
.word 0xf9410a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f6
.word 0xaa1603e0
.word 0xaa1603e1
.word 0xaa0003f5
.word 0xb4000096
.word 0xaa1503e0
.word 0xaa1503e0
bl _p_39
.word 0xaa1503e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9416231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0x9100c3a0
.word 0xf9401ba0
.word 0xf90002e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1803e0
.word 0xf9400fb1
.word 0xf941a631
.word 0xb4000051
.word 0xd63f0220
.word 0xa945dbb5
.word 0xa946e3b7
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_98:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90023be
.word 0xa904d3b3
.word 0xa905dbb5
.word 0xa906e3b7
.word 0xa907ebb9
.word 0xa908f3bb
.word 0xf9004fbd
.word 0x910003f1
.word 0xf90053b1
.word 0xf9000ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1560]
.word 0xf9000fb0
.word 0xf9400a11
.word 0xf90013b1
.word 0xf90057bf
.word 0xf9005bbf
.word 0x3902e3bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f8
.word 0x9100c3a0
.word 0xf9400301
.word 0xf9001ba1
.word 0xf9000300
.word 0xf9400fb1
.word 0xf9408a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3902e3a0
.word 0xf9400fb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
bl _p_69
.word 0xf9400fb1
.word 0xf940de31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9400fb1
.word 0xf9410231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_39
.word 0xaa1603e0
.word 0xf94013b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400fb1
.word 0xf9415a31
.word 0xb4000051
.word 0xd63f0220
.word 0x9100c3a0
.word 0xf9401ba0
.word 0xf9000300
.word 0xf9400fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0xa9465fb6
.word 0xf9403bb8
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_99:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1568]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_70
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_9a:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1576]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_71
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_9b:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1584]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_72
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_9c:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1592]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f5
.word 0x910123a0
.word 0xf94002a1
.word 0xf90027a1
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9409631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940b631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390343a0
.word 0xf9401bb1
.word 0xf940d231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
bl _p_73
.word 0xf9401bb1
.word 0xf940f631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9401bb1
.word 0xf9411a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9412a31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_39
.word 0xaa1303e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9417231
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xf94027a0
.word 0xf90002a0
.word 0xf9401bb1
.word 0xf9418e31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_9d:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1600]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_74
.word 0x53001c00
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940f231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_9e:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1608]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_75
.word 0xf94017b1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_39
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

Lme_9f:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1616]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_76
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_a0:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1624]
.word 0xf90013b0
.word 0xf9400a11
.word 0xf90017b1
.word 0xf9005bbf
.word 0xf9005fbf
.word 0x390303bf
.word 0xd2800017

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_77
.word 0xaa0003f7
.word 0xf94013b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_a1:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1632]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
.word 0xb94023a2
bl _p_78
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_a2:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1640]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_79
.word 0xf94017b1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f5
.word 0xaa1503e0
.word 0xaa1503e1
.word 0xaa0003f4
.word 0xb4000095
.word 0xaa1403e0
.word 0xaa1403e0
bl _p_39
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

Lme_a3:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr:
.loc 1 1 0
.word 0xa9b27bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9002fbe
.word 0xa90653b3
.word 0xa9075bb5
.word 0xa90863b7
.word 0xa9096bb9
.word 0xa90a73bb
.word 0xf9005bbd
.word 0x910003f1
.word 0xf9005fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1648]
.word 0xf9001bb0
.word 0xf9400a11
.word 0xf9001fb1
.word 0xf90063bf
.word 0xf90067bf
.word 0x390343bf
.word 0xd2800015

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f4
.word 0x910123a0
.word 0xf9400281
.word 0xf90027a1
.word 0xf9000280
.word 0xf9401bb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390343a0
.word 0xf9401bb1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0x394083a0
.word 0x340000c0
.word 0xf9401bb1
.word 0xf940ee31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800035
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9411231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xaa1503e2
.word 0xf94017a3
.word 0xaa1503e2
bl _p_80
.word 0xf9401bb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9401bb1
.word 0xf9415e31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf9416e31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xaa0003fa
.word 0xb4000093
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _p_39
.word 0xaa1a03e0
.word 0xf9401fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401bb1
.word 0xf941b631
.word 0xb4000051
.word 0xd63f0220
.word 0x910123a0
.word 0xf94027a0
.word 0xf9000280
.word 0xf9401bb1
.word 0xf941d231
.word 0xb4000051
.word 0xd63f0220
.word 0xa94653b3
.word 0xf9403bb5
.word 0xf9404fba
.word 0x910003bf
.word 0xa8ce7bfd
.word 0xd65f03c0

Lme_a4:
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

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1656]
.word 0xf90017b0
.word 0xf9400a11
.word 0xf9001bb1
.word 0xf9005fbf
.word 0xf90063bf
.word 0x390323bf
.word 0xd2800016

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
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
bl _p_81
.word 0x53001c00
.word 0xaa0003f6
.word 0xf94017b1
.word 0xf940fa31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
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
bl _p_65
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_39
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

Lme_a5:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1664]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f9
.word 0x9101a3a0
.word 0xf9400321
.word 0xf90037a1
.word 0xf9000320
.word 0xf9402bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3903c3a0
.word 0xf9402bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xb9402ba3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xb9404ba7
bl _p_82
.word 0xf9402bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803e1
.word 0xaa0003f7
.word 0xb4000098
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_39
.word 0xaa1703e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000320
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94a63b7
.word 0xf9405bb9
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a6:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1672]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f9
.word 0x9101a3a0
.word 0xf9400321
.word 0xf90037a1
.word 0xf9000320
.word 0xf9402bb1
.word 0xf940a631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940c631
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3903c3a0
.word 0xf9402bb1
.word 0xf940e231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xb9404ba7
bl _p_83
.word 0xf9402bb1
.word 0xf9411631
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9413a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9414a31
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803e1
.word 0xaa0003f7
.word 0xb4000098
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_39
.word 0xaa1703e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000320
.word 0xf9402bb1
.word 0xf941ae31
.word 0xb4000051
.word 0xd63f0220
.word 0xa94a63b7
.word 0xf9405bb9
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_a7:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1680]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f4
.word 0x910143a0
.word 0xf9400281
.word 0xf9002ba1
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390363a0
.word 0xf9401fb1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xb94033a4
bl _p_84
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90073a0
.word 0xb4000073
.word 0xf94073a0
bl _p_39
.word 0xf94073a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_a8:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong:
.loc 1 1 0
.word 0xa9b17bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf90033be
.word 0xa906d3b3
.word 0xa907dbb5
.word 0xa908e3b7
.word 0xa909ebb9
.word 0xa90af3bb
.word 0xf9005fbd
.word 0x910003f1
.word 0xf90063b1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1688]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf90067bf
.word 0xf9006bbf
.word 0x390363bf

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f4
.word 0x910143a0
.word 0xf9400281
.word 0xf9002ba1
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9409a31
.word 0xb4000051
.word 0xd63f0220
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf940ba31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x390363a0
.word 0xf9401fb1
.word 0xf940d631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
bl _p_85
.word 0xf9401fb1
.word 0xf940fe31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000240
.word 0xf9401fb1
.word 0xf9412231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9413231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f3
.word 0xaa1303e0
.word 0xaa1303e1
.word 0xf90073a0
.word 0xb4000073
.word 0xf94073a0
bl _p_39
.word 0xf94073a0
.word 0xf94023b1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9401fb1
.word 0xf9417631
.word 0xb4000051
.word 0xd63f0220
.word 0x910143a0
.word 0xf9402ba0
.word 0xf9000280
.word 0xf9401fb1
.word 0xf9419231
.word 0xb4000051
.word 0xd63f0220
.word 0xa946d3b3
.word 0x910003bf
.word 0xa8cf7bfd
.word 0xd65f03c0

Lme_a9:
.text
	.align 4
	.no_dead_strip wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
.loc 1 1 0
.word 0xa9b07bfd
.word 0x910003fd
.word 0x1000001e
.word 0xf9003fbe
.word 0xa90853b3
.word 0xa9095bb5
.word 0xa90a63b7
.word 0xa90b6bb9
.word 0xa90c73bb
.word 0xf9006bbd
.word 0x910003f1
.word 0xf9006fb1
.word 0xf9000ba0
.word 0xf9000fa1
.word 0xf90013a2
.word 0xf90017a3
.word 0xf9001ba4
.word 0xf9001fa5
.word 0xf90023a6
.word 0xf90027a7

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1696]
.word 0xf9002bb0
.word 0xf9400a11
.word 0xf9002fb1
.word 0xf90073bf
.word 0xf90077bf
.word 0x3903c3bf
.word 0xd2800019

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #112]
.word 0xd63f0000
.word 0xaa0003f8
.word 0x9101a3a0
.word 0xf9400301
.word 0xf90037a1
.word 0xf9000300
.word 0xf9402bb1
.word 0xf940aa31
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf940ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xd2800000
.word 0x53001c01
.word 0x3903c3a0
.word 0xf9402bb1
.word 0xf940e631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9400ba0
.word 0xf9400fa1
.word 0xf94013a2
.word 0xf94017a3
.word 0xf9401ba4
.word 0xf9401fa5
.word 0xf94023a6
.word 0xf94027a7
bl _p_86
.word 0xaa0003f9
.word 0xf9402bb1
.word 0xf9411e31
.word 0xb4000051
.word 0xd63f0220

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000260
.word 0xf9402bb1
.word 0xf9414231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
bl _p_65
.word 0xaa0003f7
.word 0xaa1703e0
.word 0xaa1703e1
.word 0xaa0003f6
.word 0xb4000097
.word 0xaa1603e0
.word 0xaa1603e0
bl _p_39
.word 0xaa1603e0
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf9419a31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0x9101a3a0
.word 0xf94037a0
.word 0xf9000300
.word 0xf9402fb1
.word 0xf9400231
.word 0xb4000051
.word 0xd63f0220
.word 0xf9402bb1
.word 0xf941ca31
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1903e0
.word 0xf9402bb1
.word 0xf941de31
.word 0xb4000051
.word 0xd63f0220
.word 0xa949dfb6
.word 0xa94ae7b8
.word 0x910003bf
.word 0xa8d07bfd
.word 0xd65f03c0

Lme_aa:
.text
	.align 4
	.no_dead_strip wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint:
.loc 1 1 0
.word 0xa9b47bfd
.word 0x910003fd
.word 0xa90163b7
.word 0xf90013ba
.word 0xf90017a0
.word 0xf9001ba1
.word 0xf9001fa2
.word 0xf90023a3
.word 0xf90027a4
.word 0xf9002ba5

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1704]
.word 0xf9002fb0
.word 0xf9400a11
.word 0xf90033b1
.word 0xf9003bbf
.word 0xf9003fbf
.word 0x390203bf
.word 0xb9008bbf
.word 0xf9004bbf
.word 0xf9004fbf
.word 0xf90053bf
.word 0xd2800000
.word 0x53001c01
.word 0x390203a0
.word 0x92800000
.word 0xf2bfffe0
.word 0x92800000
.word 0xf2bfffe0
.word 0x9280001e
.word 0xf2bffffe
.word 0xb9008bbe
.word 0xd2800000
.word 0xd280001a

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xf9005ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #64]
.word 0xd63f0000
.word 0xaa0003e1
.word 0xf9405ba0
.word 0xf90057a1
.word 0xd2800001
.word 0xeb01001f
.word 0x54000061
.word 0xf94057a0
.word 0xb5000100
.word 0xd2800000

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #128]
.word 0xd2800000
.word 0xd63f0020
.word 0xaa0003fa

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000160
bl _p_65
.word 0xaa0003f8
.word 0xaa1803e0
.word 0xaa1803e1
.word 0xaa0003f7
.word 0xb4000098
.word 0xaa1703e0
.word 0xaa1703e0
bl _p_39
.word 0xaa1703e0
.word 0xf94017a0
.word 0xf9401ba1
.word 0xf9401fa2
.word 0xf94023a3
.word 0xf94027a4
.word 0xb94053a5
bl _p_87
.word 0xf9402fb1
.word 0xf9415231
.word 0xb4000051
.word 0xd63f0220
.word 0xaa1a03e0
.word 0xaa1a03e0
bl _mono_jit_set_domain
.word 0xa94163b7
.word 0xf94013ba
.word 0x910003bf
.word 0xa8cc7bfd
.word 0xd65f03c0

Lme_ab:
.text
	.align 4
	.no_dead_strip wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr:
.loc 1 1 0
.word 0xa9b67bfd
.word 0x910003fd
.word 0xa90153b3
.word 0xf90013b6
.word 0xf90017b8
.word 0xf9001ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1712]
.word 0xf9001fb0
.word 0xf9400a11
.word 0xf90023b1
.word 0xf9002bbf
.word 0xf9002fbf
.word 0x390183bf
.word 0xd2800018
.word 0xb9006bbf
.word 0xf9003bbf
.word 0xf9003fbf
.word 0xf90043bf
.word 0xd2800000
.word 0x53001c01
.word 0x390183a0
.word 0x92800000
.word 0xf2bfffe0
.word 0x92800000
.word 0xf2bfffe0
.word 0x9280001e
.word 0xf2bffffe
.word 0xb9006bbe
.word 0xd2800000
.word 0xd2800016

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #80]
.word 0xd63f0000
.word 0xf9004ba0

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #64]
.word 0xd63f0000
.word 0xaa0003e1
.word 0xf9404ba0
.word 0xf90047a1
.word 0xd2800001
.word 0xeb01001f
.word 0x54000061
.word 0xf94047a0
.word 0xb5000100
.word 0xd2800000

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x1, [x16, #128]
.word 0xd2800000
.word 0xd63f0020
.word 0xaa0003f6

adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x0, [x16, #1424]
.word 0xb9400000
.word 0x34000160
bl _p_65
.word 0xaa0003f4
.word 0xaa1403e0
.word 0xaa1403e1
.word 0xaa0003f3
.word 0xb4000094
.word 0xaa1303e0
.word 0xaa1303e0
bl _p_39
.word 0xaa1303e0
.word 0xf9401ba0
bl _p_88
.word 0xf9004ba0
.word 0xf9401fb1
.word 0xf9413631
.word 0xb4000051
.word 0xd63f0220
.word 0xf9404ba0
.word 0xaa0003f8
.word 0xaa1603e0
.word 0xaa1603e0
bl _mono_jit_set_domain
.word 0xaa1803e0
.word 0xa94153b3
.word 0xf94013b6
.word 0xf94017b8
.word 0x910003bf
.word 0xa8ca7bfd
.word 0xd65f03c0

Lme_ac:
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
bl ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
bl ObjCRuntime_Trampolines_SDMSLogHandler__cctor
bl ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_
bl ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize
bl ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr
bl ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
bl ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor
bl ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_
bl ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize
bl ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr
bl ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl ApiDefinition_Messaging__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class
bl Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string
bl Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion
bl Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset
bl Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint
bl Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool
bl Microsoft_AppCenter_iOS_Bindings_MSService__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled
bl Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool
bl Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion
bl Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl method_addresses
bl wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object
bl wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
bl wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint
bl wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
bl wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object
bl wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult
bl wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr
bl wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr
bl wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object
bl wrapper_delegate_invoke__Module_invoke_string
bl wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object
bl wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult
bl wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
bl wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
bl wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
bl wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
bl wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
bl wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
bl wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
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

	.byte 27,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,152,14,153,13,68,154,12,13,12,31,0
	.byte 68,14,48,157,6,158,5,68,13,29,18,12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9,13,12,31
	.byte 0,68,14,80,157,10,158,9,68,13,29,23,12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,152,11,68,153
	.byte 10,154,9,19,12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,148,22,149,21,18,12,31,0,68,14,80,157,10
	.byte 158,9,68,13,29,68,152,8,153,7,16,12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8,13,12,31,0,68
	.byte 14,64,157,8,158,7,68,13,29,16,12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10,16,12,31,0,68,14
	.byte 96,157,12,158,11,68,13,29,68,153,10,23,12,31,0,68,14,96,157,12,158,11,68,13,29,68,151,10,152,9,68,153
	.byte 8,154,7,19,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,153,16,154,15,16,12,31,0,68,14,64,157,8
	.byte 158,7,68,13,29,68,154,6,22,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,151,16,152,15,68,154,14,16
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,152,10,18,12,31,0,68,14,112,157,14,158,13,68,13,29,68,150
	.byte 12,151,11,19,12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,68,153,11,16,12,31,0,68,14,112,157,14
	.byte 158,13,68,13,29,68,151,12,16,12,31,0,68,14,112,157,14,158,13,68,13,29,68,153,12,34,12,31,0,68,14,192
	.byte 1,157,24,158,23,68,13,29,68,147,22,148,21,68,149,20,150,19,68,151,18,152,17,68,153,16,154,15,27,12,31,0
	.byte 68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15,68,154,14,19,12,31,0,68,14,240,1
	.byte 157,30,158,29,68,13,29,68,147,28,148,27,34,12,31,0,68,14,176,1,157,22,158,21,68,13,29,68,147,20,148,19
	.byte 68,149,18,150,17,68,151,16,152,15,68,153,14,154,13,27,12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150
	.byte 18,151,17,68,152,16,153,15,68,156,14,23,12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152
	.byte 8,153,7,39,12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152
	.byte 10,68,153,9,154,8,68,155,7,156,6,34,12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68
	.byte 149,14,150,13,68,151,12,152,11,68,153,10,154,9,24,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14
	.byte 151,13,68,152,12,153,11,23,12,31,0,68,14,112,157,14,158,13,68,13,29,68,150,12,151,11,68,152,10,153,9,39
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7,34,12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,149,16,150,15
	.byte 68,151,14,152,13,68,153,12,154,11,24,12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152
	.byte 16,153,15,34,12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,152
	.byte 9,68,153,8,154,7,39,12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15,148,14,68,149,13,150,12,68
	.byte 151,11,152,10,68,153,9,154,8,68,155,7,156,6,39,12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15
	.byte 148,14,68,149,13,150,12,68,151,11,152,10,68,153,9,154,8,68,155,7,156,6,39,12,31,0,68,14,224,1,157,28
	.byte 158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10,154,9,68,155,8,156,7,39,12
	.byte 31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10,154
	.byte 9,68,155,8,156,7,39,12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68
	.byte 151,13,152,12,68,153,11,154,10,68,155,9,156,8,22,12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,151,22
	.byte 152,21,68,154,20,25,12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,150,16,68,152,15

.text
	.align 4
plt:
mono_aot_Microsoft_AppCenter_iOS_Bindings_plt:
	.no_dead_strip plt_intptr_op_Explicit_intptr
plt_intptr_op_Explicit_intptr:
_p_1:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1728]
br x16
.word 2032
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_get_Target
plt_ObjCRuntime_BlockLiteral_get_Target:
_p_2:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1736]
br x16
.word 2037
	.no_dead_strip plt_System_Runtime_InteropServices_Marshal_GetDelegateForFunctionPointer_intptr_System_Type
plt_System_Runtime_InteropServices_Marshal_GetDelegateForFunctionPointer_intptr_System_Type:
_p_3:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1744]
br x16
.word 2042
	.no_dead_strip plt__jit_icall_mono_arch_throw_corlib_exception
plt__jit_icall_mono_arch_throw_corlib_exception:
_p_4:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1752]
br x16
.word 2047
	.no_dead_strip plt_wrapper_alloc_object_AllocSmall_intptr_intptr
plt_wrapper_alloc_object_AllocSmall_intptr_intptr:
_p_5:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1760]
br x16
.word 2082
	.no_dead_strip plt_intptr_op_Explicit_void_
plt_intptr_op_Explicit_void_:
_p_6:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1768]
br x16
.word 2090
	.no_dead_strip plt_ObjCRuntime_Trampolines__Block_copy_intptr
plt_ObjCRuntime_Trampolines__Block_copy_intptr:
_p_7:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1776]
br x16
.word 2095
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DMSLogHandler
plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DMSLogHandler:
_p_8:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1784]
br x16
.word 2097
	.no_dead_strip plt_ObjCRuntime_Trampolines__Block_release_intptr
plt_ObjCRuntime_Trampolines__Block_release_intptr:
_p_9:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1792]
br x16
.word 2109
	.no_dead_strip plt__jit_icall_ves_icall_thread_finish_async_abort
plt__jit_icall_ves_icall_thread_finish_async_abort:
_p_10:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1800]
br x16
.word 2111
	.no_dead_strip plt_object_Finalize
plt_object_Finalize:
_p_11:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1808]
br x16
.word 2149
	.no_dead_strip plt_intptr_op_Equality_intptr_intptr
plt_intptr_op_Equality_intptr_intptr:
_p_12:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1816]
br x16
.word 2154
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_IsManagedBlock_intptr
plt_ObjCRuntime_BlockLiteral_IsManagedBlock_intptr:
_p_13:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1824]
br x16
.word 2159
	.no_dead_strip plt__jit_icall_ves_icall_object_new_specific
plt__jit_icall_ves_icall_object_new_specific:
_p_14:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1832]
br x16
.word 2164
	.no_dead_strip plt_ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_
plt_ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_:
_p_15:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1840]
br x16
.word 2196
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_SetupBlock_System_Delegate_System_Delegate
plt_ObjCRuntime_BlockLiteral_SetupBlock_System_Delegate_System_Delegate:
_p_16:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1848]
br x16
.word 2198
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_CleanupBlock
plt_ObjCRuntime_BlockLiteral_CleanupBlock:
_p_17:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1856]
br x16
.word 2203
	.no_dead_strip plt_Foundation_NSString_CreateNative_string_bool
plt_Foundation_NSString_CreateNative_string_bool:
_p_18:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1864]
br x16
.word 2208
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DMSLogMessageProvider
plt_ObjCRuntime_BlockLiteral_GetDelegateForBlock_ObjCRuntime_Trampolines_DMSLogMessageProvider:
_p_19:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1872]
br x16
.word 2213
	.no_dead_strip plt_ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_
plt_ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_:
_p_20:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1880]
br x16
.word 2225
	.no_dead_strip plt_Foundation_NSString_FromHandle_intptr
plt_Foundation_NSString_FromHandle_intptr:
_p_21:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1888]
br x16
.word 2227
	.no_dead_strip plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag
plt_Foundation_NSObject__ctor_Foundation_NSObjectFlag:
_p_22:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1896]
br x16
.word 2232
	.no_dead_strip plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly
plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly:
_p_23:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1904]
br x16
.word 2237
	.no_dead_strip plt_Foundation_NSObject_set_IsDirectBinding_bool
plt_Foundation_NSObject_set_IsDirectBinding_bool:
_p_24:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1912]
br x16
.word 2242
	.no_dead_strip plt_Foundation_NSObject_get_Handle
plt_Foundation_NSObject_get_Handle:
_p_25:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1920]
br x16
.word 2247
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_26:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1928]
br x16
.word 2252
	.no_dead_strip plt_Foundation_NSObject_InitializeHandle_intptr_string
plt_Foundation_NSObject_InitializeHandle_intptr_string:
_p_27:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1936]
br x16
.word 2254
	.no_dead_strip plt_Foundation_NSObject__ctor_intptr
plt_Foundation_NSObject__ctor_intptr:
_p_28:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1944]
br x16
.word 2259
	.no_dead_strip plt_Foundation_NSString_CreateNative_string
plt_Foundation_NSString_CreateNative_string:
_p_29:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1952]
br x16
.word 2264
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_30:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1960]
br x16
.word 2269
	.no_dead_strip plt_Foundation_NSString_ReleaseNative_intptr
plt_Foundation_NSString_ReleaseNative_intptr:
_p_31:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1968]
br x16
.word 2271
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSUuid_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSUuid_intptr:
_p_32:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1976]
br x16
.word 2276
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_33:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1984]
br x16
.word 2288
	.no_dead_strip plt_intptr_get_Size
plt_intptr_get_Size:
_p_34:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #1992]
br x16
.word 2290
	.no_dead_strip plt_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr:
_p_35:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2000]
br x16
.word 2295
	.no_dead_strip plt_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
plt_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr:
_p_36:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2008]
br x16
.word 2297
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_37:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2016]
br x16
.word 2299
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_38:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2024]
br x16
.word 2301
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_39:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2032]
br x16
.word 2321
	.no_dead_strip plt_ObjCRuntime_BlockLiteral_SetupBlockImpl_System_Delegate_System_Delegate_bool_string
plt_ObjCRuntime_BlockLiteral_SetupBlockImpl_System_Delegate_System_Delegate_bool_string:
_p_40:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2040]
br x16
.word 2349
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
plt_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong:
_p_41:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2048]
br x16
.word 2354
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
plt_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint:
_p_42:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2056]
br x16
.word 2356
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Microsoft_AppCenter_iOS_Bindings_MSAppCenter_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Microsoft_AppCenter_iOS_Bindings_MSAppCenter_intptr:
_p_43:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2064]
br x16
.word 2358
	.no_dead_strip plt_Foundation_NSArray_FromNSObjects_ObjCRuntime_INativeObject__
plt_Foundation_NSArray_FromNSObjects_ObjCRuntime_INativeObject__:
_p_44:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2072]
br x16
.word 2370
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_45:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2080]
br x16
.word 2375
	.no_dead_strip plt_Foundation_NSObject_Dispose
plt_Foundation_NSObject_Dispose:
_p_46:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2088]
br x16
.word 2377
	.no_dead_strip plt_ObjCRuntime_Class_get_Handle
plt_ObjCRuntime_Class_get_Handle:
_p_47:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2096]
br x16
.word 2382
	.no_dead_strip plt_ObjCRuntime_Class_GetHandle_string
plt_ObjCRuntime_Class_GetHandle_string:
_p_48:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2104]
br x16
.word 2387
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
plt_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr:
_p_49:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2112]
br x16
.word 2392
	.no_dead_strip plt_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag
plt_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag:
_p_50:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2120]
br x16
.word 2394
	.no_dead_strip plt_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr
plt_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr:
_p_51:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2128]
br x16
.word 2396
	.no_dead_strip plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_52:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2136]
br x16
.word 2398
	.no_dead_strip plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSNumber_intptr
plt_ObjCRuntime_Runtime_GetNSObject_Foundation_NSNumber_intptr:
_p_53:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2144]
br x16
.word 2400
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint:
_p_54:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2152]
br x16
.word 2412
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint:
_p_55:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2160]
br x16
.word 2414
	.no_dead_strip plt_ObjCRuntime_BaseWrapper__ctor_intptr_bool
plt_ObjCRuntime_BaseWrapper__ctor_intptr_bool:
_p_56:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2168]
br x16
.word 2416
	.no_dead_strip plt_Foundation_NSObject_get_SuperHandle
plt_Foundation_NSObject_get_SuperHandle:
_p_57:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2176]
br x16
.word 2421
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_58:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2184]
br x16
.word 2426
	.no_dead_strip plt_Foundation_You_Should_Not_Call_base_In_This_Method__ctor
plt_Foundation_You_Should_Not_Call_base_In_This_Method__ctor:
_p_59:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2192]
br x16
.word 2428
	.no_dead_strip plt_Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag
plt_Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag:
_p_60:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2200]
br x16
.word 2433
	.no_dead_strip plt_Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr
plt_Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr:
_p_61:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2208]
br x16
.word 2435
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong:
_p_62:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2216]
br x16
.word 2437
	.no_dead_strip plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
plt_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint:
_p_63:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2224]
br x16
.word 2439
	.no_dead_strip plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_64:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2232]
br x16
.word 2441
	.no_dead_strip plt__jit_icall_mono_thread_interruption_checkpoint
plt__jit_icall_mono_thread_interruption_checkpoint:
_p_65:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2240]
br x16
.word 2443
	.no_dead_strip plt__jit_icall_mono_delegate_begin_invoke
plt__jit_icall_mono_delegate_begin_invoke:
_p_66:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2248]
br x16
.word 2481
	.no_dead_strip plt__jit_icall_mono_delegate_end_invoke
plt__jit_icall_mono_delegate_end_invoke:
_p_67:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2256]
br x16
.word 2510
	.no_dead_strip plt__icall_native_ObjCRuntime_Trampolines__Block_copy_intptr
plt__icall_native_ObjCRuntime_Trampolines__Block_copy_intptr:
_p_68:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2264]
br x16
.word 2537
	.no_dead_strip plt__icall_native_ObjCRuntime_Trampolines__Block_release_intptr
plt__icall_native_ObjCRuntime_Trampolines__Block_release_intptr:
_p_69:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2272]
br x16
.word 2539
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr:
_p_70:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2280]
br x16
.word 2541
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr:
_p_71:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2288]
br x16
.word 2543
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_72:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2296]
br x16
.word 2545
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr:
_p_73:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2304]
br x16
.word 2547
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr:
_p_74:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2312]
br x16
.word 2549
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool:
_p_75:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2320]
br x16
.word 2551
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr:
_p_76:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2328]
br x16
.word 2553
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr:
_p_77:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2336]
br x16
.word 2555
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint:
_p_78:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2344]
br x16
.word 2557
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong:
_p_79:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2352]
br x16
.word 2559
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr:
_p_80:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2360]
br x16
.word 2561
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr:
_p_81:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2368]
br x16
.word 2563
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint:
_p_82:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2376]
br x16
.word 2565
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint:
_p_83:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2384]
br x16
.word 2567
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint:
_p_84:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2392]
br x16
.word 2569
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
plt__icall_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong:
_p_85:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2400]
br x16
.word 2571
	.no_dead_strip plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
plt__icall_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr:
_p_86:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2408]
br x16
.word 2573
	.no_dead_strip plt_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
plt_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint:
_p_87:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2416]
br x16
.word 2575
	.no_dead_strip plt_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
plt_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr:
_p_88:
adrp x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGE+0
add x16, x16, mono_aot_Microsoft_AppCenter_iOS_Bindings_got@PAGEOFF
ldr x16, [x16, #2424]
br x16
.word 2577
plt_end:
.section __DATA, __bss
	.align 3
.lcomm mono_aot_Microsoft_AppCenter_iOS_Bindings_got, 2432
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
L_OBJC_SELECTOR_REFERENCES_10:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_10
L_OBJC_SELECTOR_REFERENCES_11:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_11
L_OBJC_SELECTOR_REFERENCES_12:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_12
L_OBJC_SELECTOR_REFERENCES_13:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_13
L_OBJC_SELECTOR_REFERENCES_14:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_14
L_OBJC_SELECTOR_REFERENCES_15:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_15
L_OBJC_SELECTOR_REFERENCES_16:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_16
L_OBJC_SELECTOR_REFERENCES_17:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_17
L_OBJC_SELECTOR_REFERENCES_18:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_18
L_OBJC_SELECTOR_REFERENCES_19:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_19
L_OBJC_SELECTOR_REFERENCES_20:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_20
L_OBJC_SELECTOR_REFERENCES_21:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_21
L_OBJC_SELECTOR_REFERENCES_22:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_22
L_OBJC_SELECTOR_REFERENCES_23:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_23
L_OBJC_SELECTOR_REFERENCES_24:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_24
L_OBJC_SELECTOR_REFERENCES_25:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_25
L_OBJC_SELECTOR_REFERENCES_26:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_26
L_OBJC_SELECTOR_REFERENCES_27:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_27
L_OBJC_SELECTOR_REFERENCES_28:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_28
L_OBJC_SELECTOR_REFERENCES_29:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_29
L_OBJC_SELECTOR_REFERENCES_30:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_30
L_OBJC_SELECTOR_REFERENCES_31:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_31
L_OBJC_SELECTOR_REFERENCES_32:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_32
L_OBJC_SELECTOR_REFERENCES_33:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_33
L_OBJC_SELECTOR_REFERENCES_34:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_34
L_OBJC_SELECTOR_REFERENCES_35:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_35
L_OBJC_SELECTOR_REFERENCES_36:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_36
L_OBJC_SELECTOR_REFERENCES_37:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_37
L_OBJC_SELECTOR_REFERENCES_38:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_38
L_OBJC_SELECTOR_REFERENCES_39:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_39
L_OBJC_SELECTOR_REFERENCES_40:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_40
L_OBJC_SELECTOR_REFERENCES_41:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_41
L_OBJC_SELECTOR_REFERENCES_42:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_42
L_OBJC_SELECTOR_REFERENCES_43:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_43
L_OBJC_SELECTOR_REFERENCES_44:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_44
L_OBJC_SELECTOR_REFERENCES_45:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_45
L_OBJC_SELECTOR_REFERENCES_46:
	.align 3
	.quad L_OBJC_METH_VAR_NAME_46
.section	__TEXT,__cstring,cstring_literals
L_OBJC_METH_VAR_NAME_0:
.asciz "init"
L_OBJC_METH_VAR_NAME_1:
.asciz "configureWithAppSecret:"
L_OBJC_METH_VAR_NAME_2:
.asciz "installId"
L_OBJC_METH_VAR_NAME_3:
.asciz "isConfigured"
L_OBJC_METH_VAR_NAME_4:
.asciz "isDebuggerAttached"
L_OBJC_METH_VAR_NAME_5:
.asciz "isEnabled"
L_OBJC_METH_VAR_NAME_6:
.asciz "logLevel"
L_OBJC_METH_VAR_NAME_7:
.asciz "setCustomProperties:"
L_OBJC_METH_VAR_NAME_8:
.asciz "setEnabled:"
L_OBJC_METH_VAR_NAME_9:
.asciz "setLogHandler:"
L_OBJC_METH_VAR_NAME_10:
.asciz "setLogLevel:"
L_OBJC_METH_VAR_NAME_11:
.asciz "setLogUrl:"
L_OBJC_METH_VAR_NAME_12:
.asciz "setWrapperSdk:"
L_OBJC_METH_VAR_NAME_13:
.asciz "sharedInstance"
L_OBJC_METH_VAR_NAME_14:
.asciz "start:withServices:"
L_OBJC_METH_VAR_NAME_15:
.asciz "startService:"
L_OBJC_METH_VAR_NAME_16:
.asciz "clearPropertyForKey:"
L_OBJC_METH_VAR_NAME_17:
.asciz "setString:forKey:"
L_OBJC_METH_VAR_NAME_18:
.asciz "setNumber:forKey:"
L_OBJC_METH_VAR_NAME_19:
.asciz "setBool:forKey:"
L_OBJC_METH_VAR_NAME_20:
.asciz "setDate:forKey:"
L_OBJC_METH_VAR_NAME_21:
.asciz "isEqual:"
L_OBJC_METH_VAR_NAME_22:
.asciz "appBuild"
L_OBJC_METH_VAR_NAME_23:
.asciz "appNamespace"
L_OBJC_METH_VAR_NAME_24:
.asciz "appVersion"
L_OBJC_METH_VAR_NAME_25:
.asciz "carrierCountry"
L_OBJC_METH_VAR_NAME_26:
.asciz "carrierName"
L_OBJC_METH_VAR_NAME_27:
.asciz "locale"
L_OBJC_METH_VAR_NAME_28:
.asciz "model"
L_OBJC_METH_VAR_NAME_29:
.asciz "oemName"
L_OBJC_METH_VAR_NAME_30:
.asciz "osApiLevel"
L_OBJC_METH_VAR_NAME_31:
.asciz "osBuild"
L_OBJC_METH_VAR_NAME_32:
.asciz "osName"
L_OBJC_METH_VAR_NAME_33:
.asciz "osVersion"
L_OBJC_METH_VAR_NAME_34:
.asciz "screenSize"
L_OBJC_METH_VAR_NAME_35:
.asciz "sdkName"
L_OBJC_METH_VAR_NAME_36:
.asciz "sdkVersion"
L_OBJC_METH_VAR_NAME_37:
.asciz "timeZoneOffset"
L_OBJC_METH_VAR_NAME_38:
.asciz "logMessage:level:tag:file:function:line:"
L_OBJC_METH_VAR_NAME_39:
.asciz "MSWrapperLog:tag:level:"
L_OBJC_METH_VAR_NAME_40:
.asciz "initWithWrapperSdkVersion:wrapperSdkName:wrapperRuntimeVersion:liveUpdateReleaseLabel:liveUpdateDeploymentKey:liveUpdatePackageHash:"
L_OBJC_METH_VAR_NAME_41:
.asciz "liveUpdateDeploymentKey"
L_OBJC_METH_VAR_NAME_42:
.asciz "liveUpdatePackageHash"
L_OBJC_METH_VAR_NAME_43:
.asciz "liveUpdateReleaseLabel"
L_OBJC_METH_VAR_NAME_44:
.asciz "wrapperRuntimeVersion"
L_OBJC_METH_VAR_NAME_45:
.asciz "wrapperSdkName"
L_OBJC_METH_VAR_NAME_46:
.asciz "wrapperSdkVersion"
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
	.asciz "03F8EE78-4FB7-4187-8697-A4BADA3FBD3E"
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "Microsoft.AppCenter.iOS.Bindings"
.data
	.align 3
_mono_aot_file_info:

	.long 144,0
	.align 3
	.quad mono_aot_Microsoft_AppCenter_iOS_Bindings_got
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

	.long 215,2432,89,173,70,387000831,0,25735
	.long 128,8,8,8,0,25,28440,2696
	.long 2408,1536,0,2016,2344,1712,0,1240
	.long 256,2688,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0
	.byte 44,248,14,34,135,55,44,35,42,106,102,150,222,140,60,96
	.globl _mono_aot_module_Microsoft_AppCenter_iOS_Bindings_info
	.align 3
_mono_aot_module_Microsoft_AppCenter_iOS_Bindings_info:
	.align 3
	.quad _mono_aot_file_info
.section __DWARF, __debug_info,regular,debug
LTDIE_2:

	.byte 17
	.asciz "System_Object"

	.byte 16,7
	.asciz "System_Object"

LDIFF_SYM3=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM3
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM4=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM5=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_1:

	.byte 5
	.asciz "System_ValueType"

	.byte 16,16
LDIFF_SYM6=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM6
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM7=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM8=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM9=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_0:

	.byte 5
	.asciz "System_UInt32"

	.byte 20,16
LDIFF_SYM10=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM10
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM11=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM11
	.byte 2,35,16,0,7
	.asciz "System_UInt32"

LDIFF_SYM12=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM12
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM13=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM13
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM14=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM14
LTDIE_8:

	.byte 5
	.asciz "System_Reflection_MemberInfo"

	.byte 16,16
LDIFF_SYM15=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MemberInfo"

LDIFF_SYM16=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM16
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM17=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM17
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM18=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM18
LTDIE_7:

	.byte 5
	.asciz "System_Reflection_MethodBase"

	.byte 16,16
LDIFF_SYM19=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodBase"

LDIFF_SYM20=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM20
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM21=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM21
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM22=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM22
LTDIE_6:

	.byte 5
	.asciz "System_Reflection_MethodInfo"

	.byte 16,16
LDIFF_SYM23=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM23
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodInfo"

LDIFF_SYM24=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM24
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM25=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM25
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM26=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM26
LTDIE_10:

	.byte 5
	.asciz "System_Type"

	.byte 24,16
LDIFF_SYM27=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM27
	.byte 2,35,0,6
	.asciz "_impl"

LDIFF_SYM28=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM28
	.byte 2,35,16,0,7
	.asciz "System_Type"

LDIFF_SYM29=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM29
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM30=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM30
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM31=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM31
LTDIE_11:

	.byte 5
	.asciz "System_Boolean"

	.byte 17,16
LDIFF_SYM32=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM32
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM33=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 2,35,16,0,7
	.asciz "System_Boolean"

LDIFF_SYM34=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM34
LTDIE_11_POINTER:

	.byte 13
LDIFF_SYM35=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM35
LTDIE_11_REFERENCE:

	.byte 14
LDIFF_SYM36=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM36
LTDIE_9:

	.byte 5
	.asciz "System_DelegateData"

	.byte 40,16
LDIFF_SYM37=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM37
	.byte 2,35,0,6
	.asciz "target_type"

LDIFF_SYM38=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM38
	.byte 2,35,16,6
	.asciz "method_name"

LDIFF_SYM39=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM39
	.byte 2,35,24,6
	.asciz "curried_first_arg"

LDIFF_SYM40=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM40
	.byte 2,35,32,0,7
	.asciz "System_DelegateData"

LDIFF_SYM41=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM41
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM42=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM42
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM43=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM43
LTDIE_5:

	.byte 5
	.asciz "System_Delegate"

	.byte 104,16
LDIFF_SYM44=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2,35,0,6
	.asciz "method_ptr"

LDIFF_SYM45=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM45
	.byte 2,35,16,6
	.asciz "invoke_impl"

LDIFF_SYM46=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM46
	.byte 2,35,24,6
	.asciz "m_target"

LDIFF_SYM47=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM47
	.byte 2,35,32,6
	.asciz "method"

LDIFF_SYM48=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM48
	.byte 2,35,40,6
	.asciz "delegate_trampoline"

LDIFF_SYM49=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM49
	.byte 2,35,48,6
	.asciz "extra_arg"

LDIFF_SYM50=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM50
	.byte 2,35,56,6
	.asciz "method_code"

LDIFF_SYM51=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM51
	.byte 2,35,64,6
	.asciz "method_info"

LDIFF_SYM52=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 2,35,72,6
	.asciz "original_method_info"

LDIFF_SYM53=LTDIE_6_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM53
	.byte 2,35,80,6
	.asciz "data"

LDIFF_SYM54=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM54
	.byte 2,35,88,6
	.asciz "method_is_virtual"

LDIFF_SYM55=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM55
	.byte 2,35,96,0,7
	.asciz "System_Delegate"

LDIFF_SYM56=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM56
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM57=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM57
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM58=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM58
LTDIE_4:

	.byte 5
	.asciz "System_MulticastDelegate"

	.byte 112,16
LDIFF_SYM59=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM59
	.byte 2,35,0,6
	.asciz "delegates"

LDIFF_SYM60=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 2,35,104,0,7
	.asciz "System_MulticastDelegate"

LDIFF_SYM61=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM61
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM62=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM62
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM63=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM63
LTDIE_3:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogHandler"

	.byte 112,16
LDIFF_SYM64=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogHandler"

LDIFF_SYM65=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM65
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM66=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM66
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM67=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM67
	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDMSLogHandler:Invoke"
	.asciz "ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
	.quad Lme_6

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM68=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 2,141,56,3
	.asciz "arg0"

LDIFF_SYM69=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 3,141,192,0,3
	.asciz "arg1"

LDIFF_SYM70=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM70
	.byte 3,141,200,0,3
	.asciz "arg2"

LDIFF_SYM71=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM71
	.byte 3,141,208,0,3
	.asciz "arg3"

LDIFF_SYM72=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM72
	.byte 3,141,216,0,3
	.asciz "arg4"

LDIFF_SYM73=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM73
	.byte 3,141,224,0,11
	.asciz "V_0"

LDIFF_SYM74=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM74
	.byte 1,100,11
	.asciz "V_1"

LDIFF_SYM75=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM75
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM76=Lfde0_end - Lfde0_start
	.long LDIFF_SYM76
Lfde0_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint

LDIFF_SYM77=Lme_6 - ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
	.long LDIFF_SYM77
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,152,14,153,13,68,154,12
	.align 3
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDMSLogHandler:.cctor"
	.asciz "ObjCRuntime_Trampolines_SDMSLogHandler__cctor"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDMSLogHandler__cctor
	.quad Lme_7

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM78=Lfde1_end - Lfde1_start
	.long LDIFF_SYM78
Lfde1_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDMSLogHandler__cctor

LDIFF_SYM79=Lme_7 - ObjCRuntime_Trampolines_SDMSLogHandler__cctor
	.long LDIFF_SYM79
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde1_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_13:

	.byte 5
	.asciz "_DMSLogHandler"

	.byte 112,16
LDIFF_SYM80=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 2,35,0,0,7
	.asciz "_DMSLogHandler"

LDIFF_SYM81=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM81
LTDIE_13_POINTER:

	.byte 13
LDIFF_SYM82=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM82
LTDIE_13_REFERENCE:

	.byte 14
LDIFF_SYM83=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM83
LTDIE_12:

	.byte 5
	.asciz "_NIDMSLogHandler"

	.byte 32,16
LDIFF_SYM84=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM84
	.byte 2,35,0,6
	.asciz "blockPtr"

LDIFF_SYM85=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM85
	.byte 2,35,24,6
	.asciz "invoker"

LDIFF_SYM86=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM86
	.byte 2,35,16,0,7
	.asciz "_NIDMSLogHandler"

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
	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogHandler:.ctor"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_
	.quad Lme_8

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM90=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM90
	.byte 1,105,3
	.asciz "block"

LDIFF_SYM91=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM91
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM92=Lfde2_end - Lfde2_start
	.long LDIFF_SYM92
Lfde2_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_

LDIFF_SYM93=Lme_8 - ObjCRuntime_Trampolines_NIDMSLogHandler__ctor_ObjCRuntime_BlockLiteral_
	.long LDIFF_SYM93
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogHandler:Finalize"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize
	.quad Lme_9

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM94=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM95=Lfde3_end - Lfde3_start
	.long LDIFF_SYM95
Lfde3_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize

LDIFF_SYM96=Lme_9 - ObjCRuntime_Trampolines_NIDMSLogHandler_Finalize
	.long LDIFF_SYM96
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogHandler:Create"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr
	.quad Lme_a

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM97=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM97
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM98=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM98
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM99=Lfde4_end - Lfde4_start
	.long LDIFF_SYM99
Lfde4_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr

LDIFF_SYM100=Lme_a - ObjCRuntime_Trampolines_NIDMSLogHandler_Create_intptr
	.long LDIFF_SYM100
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,152,11,68,153,10,154,9
	.align 3
Lfde4_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_14:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider"

	.byte 112,16
LDIFF_SYM101=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM101
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider"

LDIFF_SYM102=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM102
LTDIE_14_POINTER:

	.byte 13
LDIFF_SYM103=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM103
LTDIE_14_REFERENCE:

	.byte 14
LDIFF_SYM104=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM104
LTDIE_15:

	.byte 8
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogLevel"

	.byte 8
LDIFF_SYM105=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM105
	.byte 9
	.asciz "Verbose"

	.byte 2,9
	.asciz "Debug"

	.byte 3,9
	.asciz "Info"

	.byte 4,9
	.asciz "Warning"

	.byte 5,9
	.asciz "Error"

	.byte 6,9
	.asciz "Assert"

	.byte 7,9
	.asciz "None"

	.byte 227,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogLevel"

LDIFF_SYM106=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM106
LTDIE_15_POINTER:

	.byte 13
LDIFF_SYM107=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM107
LTDIE_15_REFERENCE:

	.byte 14
LDIFF_SYM108=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM108
	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogHandler:Invoke"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
	.quad Lme_b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM109=LTDIE_12_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM109
	.byte 1,101,3
	.asciz "arg0"

LDIFF_SYM110=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 2,141,32,3
	.asciz "arg1"

LDIFF_SYM111=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM111
	.byte 2,141,40,3
	.asciz "arg2"

LDIFF_SYM112=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM112
	.byte 2,141,48,3
	.asciz "arg3"

LDIFF_SYM113=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 2,141,56,3
	.asciz "arg4"

LDIFF_SYM114=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM114
	.byte 3,141,192,0,11
	.asciz "V_0"

LDIFF_SYM115=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM115
	.byte 1,100,11
	.asciz "V_1"

LDIFF_SYM116=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM116
	.byte 3,141,224,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM117=Lfde5_end - Lfde5_start
	.long LDIFF_SYM117
Lfde5_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint

LDIFF_SYM118=Lme_b - ObjCRuntime_Trampolines_NIDMSLogHandler_Invoke_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
	.long LDIFF_SYM118
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,148,22,149,21
	.align 3
Lfde5_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDMSLogMessageProvider:Invoke"
	.asciz "ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
	.quad Lme_10

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM119=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM120=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM120
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM121=Lfde6_end - Lfde6_start
	.long LDIFF_SYM121
Lfde6_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr

LDIFF_SYM122=Lme_10 - ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
	.long LDIFF_SYM122
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,152,8,153,7
	.align 3
Lfde6_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/SDMSLogMessageProvider:.cctor"
	.asciz "ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor
	.quad Lme_11

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM123=Lfde7_end - Lfde7_start
	.long LDIFF_SYM123
Lfde7_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor

LDIFF_SYM124=Lme_11 - ObjCRuntime_Trampolines_SDMSLogMessageProvider__cctor
	.long LDIFF_SYM124
	.long 0
	.byte 12,31,0,68,14,48,157,6,158,5,68,13,29
	.align 3
Lfde7_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_17:

	.byte 5
	.asciz "_DMSLogMessageProvider"

	.byte 112,16
LDIFF_SYM125=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM125
	.byte 2,35,0,0,7
	.asciz "_DMSLogMessageProvider"

LDIFF_SYM126=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM126
LTDIE_17_POINTER:

	.byte 13
LDIFF_SYM127=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM127
LTDIE_17_REFERENCE:

	.byte 14
LDIFF_SYM128=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM128
LTDIE_16:

	.byte 5
	.asciz "_NIDMSLogMessageProvider"

	.byte 32,16
LDIFF_SYM129=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM129
	.byte 2,35,0,6
	.asciz "blockPtr"

LDIFF_SYM130=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM130
	.byte 2,35,24,6
	.asciz "invoker"

LDIFF_SYM131=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM131
	.byte 2,35,16,0,7
	.asciz "_NIDMSLogMessageProvider"

LDIFF_SYM132=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM132
LTDIE_16_POINTER:

	.byte 13
LDIFF_SYM133=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM133
LTDIE_16_REFERENCE:

	.byte 14
LDIFF_SYM134=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM134
	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogMessageProvider:.ctor"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_
	.quad Lme_12

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM135=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM135
	.byte 1,105,3
	.asciz "block"

LDIFF_SYM136=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM136
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM137=Lfde8_end - Lfde8_start
	.long LDIFF_SYM137
Lfde8_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_

LDIFF_SYM138=Lme_12 - ObjCRuntime_Trampolines_NIDMSLogMessageProvider__ctor_ObjCRuntime_BlockLiteral_
	.long LDIFF_SYM138
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10,154,9
	.align 3
Lfde8_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogMessageProvider:Finalize"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize
	.quad Lme_13

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM139=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM139
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM140=Lfde9_end - Lfde9_start
	.long LDIFF_SYM140
Lfde9_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize

LDIFF_SYM141=Lme_13 - ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Finalize
	.long LDIFF_SYM141
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde9_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogMessageProvider:Create"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr
	.quad Lme_14

	.byte 2,118,16,3
	.asciz "block"

LDIFF_SYM142=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM142
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM143=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM143
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM144=Lfde10_end - Lfde10_start
	.long LDIFF_SYM144
Lfde10_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr

LDIFF_SYM145=Lme_14 - ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Create_intptr
	.long LDIFF_SYM145
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,152,11,68,153,10,154,9
	.align 3
Lfde10_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ObjCRuntime.Trampolines/NIDMSLogMessageProvider:Invoke"
	.asciz "ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke"

	.byte 0,0
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke
	.quad Lme_15

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM146=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM146
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM147=Lfde11_end - Lfde11_start
	.long LDIFF_SYM147
Lfde11_start:

	.long 0
	.align 3
	.quad ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke

LDIFF_SYM148=Lme_15 - ObjCRuntime_Trampolines_NIDMSLogMessageProvider_Invoke
	.long LDIFF_SYM148
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde11_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "ApiDefinition.Messaging:.cctor"
	.asciz "ApiDefinition_Messaging__cctor"

	.byte 0,0
	.quad ApiDefinition_Messaging__cctor
	.quad Lme_27

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM149=Lfde12_end - Lfde12_start
	.long LDIFF_SYM149
Lfde12_start:

	.long 0
	.align 3
	.quad ApiDefinition_Messaging__cctor

LDIFF_SYM150=Lme_27 - ApiDefinition_Messaging__cctor
	.long LDIFF_SYM150
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde12_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_20:

	.byte 8
	.asciz "_Flags"

	.byte 1
LDIFF_SYM151=LDIE_U1 - Ldebug_info_start
	.long LDIFF_SYM151
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

LDIFF_SYM152=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM152
LTDIE_20_POINTER:

	.byte 13
LDIFF_SYM153=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM153
LTDIE_20_REFERENCE:

	.byte 14
LDIFF_SYM154=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM154
LTDIE_19:

	.byte 5
	.asciz "Foundation_NSObject"

	.byte 40,16
LDIFF_SYM155=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM155
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM156=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM156
	.byte 2,35,16,6
	.asciz "class_handle"

LDIFF_SYM157=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM157
	.byte 2,35,24,6
	.asciz "flags"

LDIFF_SYM158=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM158
	.byte 2,35,32,0,7
	.asciz "Foundation_NSObject"

LDIFF_SYM159=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM159
LTDIE_19_POINTER:

	.byte 13
LDIFF_SYM160=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM160
LTDIE_19_REFERENCE:

	.byte 14
LDIFF_SYM161=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM161
LTDIE_18:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter"

	.byte 40,16
LDIFF_SYM162=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM162
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter"

LDIFF_SYM163=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM163
LTDIE_18_POINTER:

	.byte 13
LDIFF_SYM164=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM164
LTDIE_18_REFERENCE:

	.byte 14
LDIFF_SYM165=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM165
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle
	.quad Lme_28

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM166=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM166
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM167=Lfde13_end - Lfde13_start
	.long LDIFF_SYM167
Lfde13_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle

LDIFF_SYM168=Lme_28 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_get_ClassHandle
	.long LDIFF_SYM168
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde13_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor
	.quad Lme_29

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM169=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM169
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM170=Lfde14_end - Lfde14_start
	.long LDIFF_SYM170
Lfde14_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor

LDIFF_SYM171=Lme_29 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor
	.long LDIFF_SYM171
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde14_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_21:

	.byte 5
	.asciz "Foundation_NSObjectFlag"

	.byte 16,16
LDIFF_SYM172=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM172
	.byte 2,35,0,0,7
	.asciz "Foundation_NSObjectFlag"

LDIFF_SYM173=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM173
LTDIE_21_POINTER:

	.byte 13
LDIFF_SYM174=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM174
LTDIE_21_REFERENCE:

	.byte 14
LDIFF_SYM175=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM175
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag
	.quad Lme_2a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM176=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM176
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM177=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM177
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM178=Lfde15_end - Lfde15_start
	.long LDIFF_SYM178
Lfde15_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag

LDIFF_SYM179=Lme_2a - Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM179
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde15_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr
	.quad Lme_2b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM180=LTDIE_18_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM180
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM181=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM181
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM182=Lfde16_end - Lfde16_start
	.long LDIFF_SYM182
Lfde16_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr

LDIFF_SYM183=Lme_2b - Microsoft_AppCenter_iOS_Bindings_MSAppCenter__ctor_intptr
	.long LDIFF_SYM183
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:ConfigureWithAppSecret"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string
	.quad Lme_2c

	.byte 2,118,16,3
	.asciz "appSecret"

LDIFF_SYM184=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM184
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM185=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM185
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM186=Lfde17_end - Lfde17_start
	.long LDIFF_SYM186
Lfde17_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string

LDIFF_SYM187=Lme_2c - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_ConfigureWithAppSecret_string
	.long LDIFF_SYM187
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde17_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:InstallId"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId
	.quad Lme_2d

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM188=Lfde18_end - Lfde18_start
	.long LDIFF_SYM188
Lfde18_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId

LDIFF_SYM189=Lme_2d - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_InstallId
	.long LDIFF_SYM189
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde18_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:IsConfigured"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured
	.quad Lme_2e

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM190=Lfde19_end - Lfde19_start
	.long LDIFF_SYM190
Lfde19_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured

LDIFF_SYM191=Lme_2e - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsConfigured
	.long LDIFF_SYM191
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde19_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:IsDebuggerAttached"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached
	.quad Lme_2f

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM192=Lfde20_end - Lfde20_start
	.long LDIFF_SYM192
Lfde20_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached

LDIFF_SYM193=Lme_2f - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsDebuggerAttached
	.long LDIFF_SYM193
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde20_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:IsEnabled"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled
	.quad Lme_30

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM194=Lfde21_end - Lfde21_start
	.long LDIFF_SYM194
Lfde21_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled

LDIFF_SYM195=Lme_30 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_IsEnabled
	.long LDIFF_SYM195
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde21_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:LogLevel"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel
	.quad Lme_31

	.byte 2,118,16,11
	.asciz "V_0"

LDIFF_SYM196=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM196
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM197=Lfde22_end - Lfde22_start
	.long LDIFF_SYM197
Lfde22_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel

LDIFF_SYM198=Lme_31 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_LogLevel
	.long LDIFF_SYM198
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde22_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_22:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties"

	.byte 40,16
LDIFF_SYM199=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM199
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties"

LDIFF_SYM200=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM200
LTDIE_22_POINTER:

	.byte 13
LDIFF_SYM201=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM201
LTDIE_22_REFERENCE:

	.byte 14
LDIFF_SYM202=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM202
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetCustomProperties"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties
	.quad Lme_32

	.byte 2,118,16,3
	.asciz "properties"

LDIFF_SYM203=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM203
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM204=Lfde23_end - Lfde23_start
	.long LDIFF_SYM204
Lfde23_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties

LDIFF_SYM205=Lme_32 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetCustomProperties_Microsoft_AppCenter_iOS_Bindings_MSCustomProperties
	.long LDIFF_SYM205
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,151,10,152,9,68,153,8,154,7
	.align 3
Lfde23_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetEnabled"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool
	.quad Lme_33

	.byte 2,118,16,3
	.asciz "isEnabled"

LDIFF_SYM206=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM206
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM207=Lfde24_end - Lfde24_start
	.long LDIFF_SYM207
Lfde24_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool

LDIFF_SYM208=Lme_33 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetEnabled_bool
	.long LDIFF_SYM208
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde24_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetLogHandler"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler
	.quad Lme_34

	.byte 2,118,16,3
	.asciz "logHandler"

LDIFF_SYM209=LTDIE_3_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM209
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM210=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM210
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM211=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM211
	.byte 2,141,56,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM212=Lfde25_end - Lfde25_start
	.long LDIFF_SYM212
Lfde25_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler

LDIFF_SYM213=Lme_34 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogHandler_Microsoft_AppCenter_iOS_Bindings_MSLogHandler
	.long LDIFF_SYM213
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,153,16,154,15
	.align 3
Lfde25_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetLogLevel"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
	.quad Lme_35

	.byte 2,118,16,3
	.asciz "logLevel"

LDIFF_SYM214=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM214
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM215=Lfde26_end - Lfde26_start
	.long LDIFF_SYM215
Lfde26_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel

LDIFF_SYM216=Lme_35 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogLevel_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
	.long LDIFF_SYM216
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29,68,154,6
	.align 3
Lfde26_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetLogUrl"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string
	.quad Lme_36

	.byte 2,118,16,3
	.asciz "logUrl"

LDIFF_SYM217=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM217
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM218=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM218
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM219=Lfde27_end - Lfde27_start
	.long LDIFF_SYM219
Lfde27_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string

LDIFF_SYM220=Lme_36 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetLogUrl_string
	.long LDIFF_SYM220
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde27_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_23:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk"

	.byte 40,16
LDIFF_SYM221=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM221
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk"

LDIFF_SYM222=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM222
LTDIE_23_POINTER:

	.byte 13
LDIFF_SYM223=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM223
LTDIE_23_REFERENCE:

	.byte 14
LDIFF_SYM224=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM224
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SetWrapperSdk"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
	.quad Lme_37

	.byte 2,118,16,3
	.asciz "wrapperSdk"

LDIFF_SYM225=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM225
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM226=Lfde28_end - Lfde28_start
	.long LDIFF_SYM226
Lfde28_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk

LDIFF_SYM227=Lme_37 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SetWrapperSdk_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
	.long LDIFF_SYM227
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde28_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:SharedInstance"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance
	.quad Lme_38

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM228=Lfde29_end - Lfde29_start
	.long LDIFF_SYM228
Lfde29_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance

LDIFF_SYM229=Lme_38 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_SharedInstance
	.long LDIFF_SYM229
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde29_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_24:

	.byte 5
	.asciz "Foundation_NSArray"

	.byte 40,16
LDIFF_SYM230=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM230
	.byte 2,35,0,0,7
	.asciz "Foundation_NSArray"

LDIFF_SYM231=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM231
LTDIE_24_POINTER:

	.byte 13
LDIFF_SYM232=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM232
LTDIE_24_REFERENCE:

	.byte 14
LDIFF_SYM233=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM233
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:Start"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__
	.quad Lme_39

	.byte 2,118,16,3
	.asciz "appSecret"

LDIFF_SYM234=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM234
	.byte 2,141,40,3
	.asciz "services"

LDIFF_SYM235=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM235
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM236=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM236
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM237=LTDIE_24_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM237
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM238=Lfde30_end - Lfde30_start
	.long LDIFF_SYM238
Lfde30_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__

LDIFF_SYM239=Lme_39 - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_Start_string_ObjCRuntime_Class__
	.long LDIFF_SYM239
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,151,16,152,15,68,154,14
	.align 3
Lfde30_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_25:

	.byte 5
	.asciz "ObjCRuntime_Class"

	.byte 24,16
LDIFF_SYM240=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM240
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM241=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM241
	.byte 2,35,16,0,7
	.asciz "ObjCRuntime_Class"

LDIFF_SYM242=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM242
LTDIE_25_POINTER:

	.byte 13
LDIFF_SYM243=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM243
LTDIE_25_REFERENCE:

	.byte 14
LDIFF_SYM244=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM244
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:StartService"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class
	.quad Lme_3a

	.byte 2,118,16,3
	.asciz "service"

LDIFF_SYM245=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM245
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM246=Lfde31_end - Lfde31_start
	.long LDIFF_SYM246
Lfde31_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class

LDIFF_SYM247=Lme_3a - Microsoft_AppCenter_iOS_Bindings_MSAppCenter_StartService_ObjCRuntime_Class
	.long LDIFF_SYM247
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29,68,154,8
	.align 3
Lfde31_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSAppCenter:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor
	.quad Lme_3b

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM248=Lfde32_end - Lfde32_start
	.long LDIFF_SYM248
Lfde32_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor

LDIFF_SYM249=Lme_3b - Microsoft_AppCenter_iOS_Bindings_MSAppCenter__cctor
	.long LDIFF_SYM249
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde32_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle
	.quad Lme_3c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM250=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM250
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM251=Lfde33_end - Lfde33_start
	.long LDIFF_SYM251
Lfde33_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle

LDIFF_SYM252=Lme_3c - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_get_ClassHandle
	.long LDIFF_SYM252
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde33_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor
	.quad Lme_3d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM253=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM253
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM254=Lfde34_end - Lfde34_start
	.long LDIFF_SYM254
Lfde34_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor

LDIFF_SYM255=Lme_3d - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor
	.long LDIFF_SYM255
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde34_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag
	.quad Lme_3e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM256=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM256
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM257=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM257
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM258=Lfde35_end - Lfde35_start
	.long LDIFF_SYM258
Lfde35_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag

LDIFF_SYM259=Lme_3e - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM259
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde35_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr
	.quad Lme_3f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM260=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM260
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM261=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM261
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM262=Lfde36_end - Lfde36_start
	.long LDIFF_SYM262
Lfde36_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr

LDIFF_SYM263=Lme_3f - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__ctor_intptr
	.long LDIFF_SYM263
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde36_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:Clear"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string
	.quad Lme_40

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM264=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM264
	.byte 2,141,24,3
	.asciz "key"

LDIFF_SYM265=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM265
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM266=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM266
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM267=Lfde37_end - Lfde37_start
	.long LDIFF_SYM267
Lfde37_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string

LDIFF_SYM268=Lme_40 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Clear_string
	.long LDIFF_SYM268
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,152,10
	.align 3
Lfde37_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:Set"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string
	.quad Lme_41

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM269=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM269
	.byte 2,141,32,3
	.asciz "value"

LDIFF_SYM270=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM270
	.byte 2,141,40,3
	.asciz "key"

LDIFF_SYM271=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM271
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM272=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM272
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM273=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM273
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM274=Lfde38_end - Lfde38_start
	.long LDIFF_SYM274
Lfde38_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string

LDIFF_SYM275=Lme_41 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_string_string
	.long LDIFF_SYM275
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,150,12,151,11
	.align 3
Lfde38_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_27:

	.byte 5
	.asciz "Foundation_NSValue"

	.byte 40,16
LDIFF_SYM276=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM276
	.byte 2,35,0,0,7
	.asciz "Foundation_NSValue"

LDIFF_SYM277=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM277
LTDIE_27_POINTER:

	.byte 13
LDIFF_SYM278=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM278
LTDIE_27_REFERENCE:

	.byte 14
LDIFF_SYM279=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM279
LTDIE_26:

	.byte 5
	.asciz "Foundation_NSNumber"

	.byte 40,16
LDIFF_SYM280=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM280
	.byte 2,35,0,0,7
	.asciz "Foundation_NSNumber"

LDIFF_SYM281=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM281
LTDIE_26_POINTER:

	.byte 13
LDIFF_SYM282=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM282
LTDIE_26_REFERENCE:

	.byte 14
LDIFF_SYM283=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM283
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:Set"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string
	.quad Lme_42

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM284=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM284
	.byte 2,141,32,3
	.asciz "value"

LDIFF_SYM285=LTDIE_26_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM285
	.byte 1,105,3
	.asciz "key"

LDIFF_SYM286=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM286
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM287=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM287
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM288=Lfde39_end - Lfde39_start
	.long LDIFF_SYM288
Lfde39_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string

LDIFF_SYM289=Lme_42 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSNumber_string
	.long LDIFF_SYM289
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,68,153,11
	.align 3
Lfde39_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:Set"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string
	.quad Lme_43

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM290=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM290
	.byte 2,141,24,3
	.asciz "value"

LDIFF_SYM291=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM291
	.byte 2,141,32,3
	.asciz "key"

LDIFF_SYM292=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM292
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM293=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM293
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM294=Lfde40_end - Lfde40_start
	.long LDIFF_SYM294
Lfde40_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string

LDIFF_SYM295=Lme_43 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_bool_string
	.long LDIFF_SYM295
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12
	.align 3
Lfde40_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_28:

	.byte 5
	.asciz "Foundation_NSDate"

	.byte 40,16
LDIFF_SYM296=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM296
	.byte 2,35,0,0,7
	.asciz "Foundation_NSDate"

LDIFF_SYM297=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM297
LTDIE_28_POINTER:

	.byte 13
LDIFF_SYM298=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM298
LTDIE_28_REFERENCE:

	.byte 14
LDIFF_SYM299=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM299
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:Set"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string
	.quad Lme_44

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM300=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM300
	.byte 2,141,32,3
	.asciz "value"

LDIFF_SYM301=LTDIE_28_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM301
	.byte 1,105,3
	.asciz "key"

LDIFF_SYM302=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM302
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM303=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM303
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM304=Lfde41_end - Lfde41_start
	.long LDIFF_SYM304
Lfde41_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string

LDIFF_SYM305=Lme_44 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties_Set_Foundation_NSDate_string
	.long LDIFF_SYM305
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,151,12,68,153,11
	.align 3
Lfde41_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSCustomProperties:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor
	.quad Lme_45

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM306=Lfde42_end - Lfde42_start
	.long LDIFF_SYM306
Lfde42_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor

LDIFF_SYM307=Lme_45 - Microsoft_AppCenter_iOS_Bindings_MSCustomProperties__cctor
	.long LDIFF_SYM307
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde42_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_29:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice"

	.byte 40,16
LDIFF_SYM308=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM308
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice"

LDIFF_SYM309=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM309
LTDIE_29_POINTER:

	.byte 13
LDIFF_SYM310=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM310
LTDIE_29_REFERENCE:

	.byte 14
LDIFF_SYM311=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM311
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle
	.quad Lme_46

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM312=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM312
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM313=Lfde43_end - Lfde43_start
	.long LDIFF_SYM313
Lfde43_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle

LDIFF_SYM314=Lme_46 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ClassHandle
	.long LDIFF_SYM314
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde43_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor
	.quad Lme_47

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM315=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM315
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM316=Lfde44_end - Lfde44_start
	.long LDIFF_SYM316
Lfde44_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor

LDIFF_SYM317=Lme_47 - Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor
	.long LDIFF_SYM317
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde44_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag
	.quad Lme_48

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM318=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM318
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM319=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM319
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM320=Lfde45_end - Lfde45_start
	.long LDIFF_SYM320
Lfde45_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag

LDIFF_SYM321=Lme_48 - Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM321
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde45_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr
	.quad Lme_49

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM322=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM322
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM323=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM323
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM324=Lfde46_end - Lfde46_start
	.long LDIFF_SYM324
Lfde46_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr

LDIFF_SYM325=Lme_49 - Microsoft_AppCenter_iOS_Bindings_MSDevice__ctor_intptr
	.long LDIFF_SYM325
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde46_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:IsEqual"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice
	.quad Lme_4a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM326=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM326
	.byte 2,141,24,3
	.asciz "device"

LDIFF_SYM327=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM327
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM328=Lfde47_end - Lfde47_start
	.long LDIFF_SYM328
Lfde47_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice

LDIFF_SYM329=Lme_4a - Microsoft_AppCenter_iOS_Bindings_MSDevice_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSDevice
	.long LDIFF_SYM329
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde47_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_AppBuild"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild
	.quad Lme_4b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM330=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM330
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM331=Lfde48_end - Lfde48_start
	.long LDIFF_SYM331
Lfde48_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild

LDIFF_SYM332=Lme_4b - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppBuild
	.long LDIFF_SYM332
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde48_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_AppNamespace"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace
	.quad Lme_4c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM333=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM333
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM334=Lfde49_end - Lfde49_start
	.long LDIFF_SYM334
Lfde49_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace

LDIFF_SYM335=Lme_4c - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppNamespace
	.long LDIFF_SYM335
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde49_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_AppVersion"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion
	.quad Lme_4d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM336=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM336
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM337=Lfde50_end - Lfde50_start
	.long LDIFF_SYM337
Lfde50_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion

LDIFF_SYM338=Lme_4d - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_AppVersion
	.long LDIFF_SYM338
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde50_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_CarrierCountry"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry
	.quad Lme_4e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM339=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM339
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM340=Lfde51_end - Lfde51_start
	.long LDIFF_SYM340
Lfde51_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry

LDIFF_SYM341=Lme_4e - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierCountry
	.long LDIFF_SYM341
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde51_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_CarrierName"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName
	.quad Lme_4f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM342=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM342
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM343=Lfde52_end - Lfde52_start
	.long LDIFF_SYM343
Lfde52_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName

LDIFF_SYM344=Lme_4f - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_CarrierName
	.long LDIFF_SYM344
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde52_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_Locale"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale
	.quad Lme_50

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM345=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM345
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM346=Lfde53_end - Lfde53_start
	.long LDIFF_SYM346
Lfde53_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale

LDIFF_SYM347=Lme_50 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Locale
	.long LDIFF_SYM347
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde53_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_Model"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model
	.quad Lme_51

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM348=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM348
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM349=Lfde54_end - Lfde54_start
	.long LDIFF_SYM349
Lfde54_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model

LDIFF_SYM350=Lme_51 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_Model
	.long LDIFF_SYM350
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde54_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_OemName"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName
	.quad Lme_52

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM351=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM351
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM352=Lfde55_end - Lfde55_start
	.long LDIFF_SYM352
Lfde55_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName

LDIFF_SYM353=Lme_52 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OemName
	.long LDIFF_SYM353
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde55_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_OsApiLevel"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel
	.quad Lme_53

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM354=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM354
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM355=LTDIE_26_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM355
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM356=Lfde56_end - Lfde56_start
	.long LDIFF_SYM356
Lfde56_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel

LDIFF_SYM357=Lme_53 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsApiLevel
	.long LDIFF_SYM357
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,153,12
	.align 3
Lfde56_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_OsBuild"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild
	.quad Lme_54

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM358=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM358
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM359=Lfde57_end - Lfde57_start
	.long LDIFF_SYM359
Lfde57_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild

LDIFF_SYM360=Lme_54 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsBuild
	.long LDIFF_SYM360
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde57_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_OsName"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName
	.quad Lme_55

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM361=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM361
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM362=Lfde58_end - Lfde58_start
	.long LDIFF_SYM362
Lfde58_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName

LDIFF_SYM363=Lme_55 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsName
	.long LDIFF_SYM363
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde58_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_OsVersion"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion
	.quad Lme_56

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM364=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM364
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM365=Lfde59_end - Lfde59_start
	.long LDIFF_SYM365
Lfde59_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion

LDIFF_SYM366=Lme_56 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_OsVersion
	.long LDIFF_SYM366
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde59_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_ScreenSize"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize
	.quad Lme_57

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM367=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM367
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM368=Lfde60_end - Lfde60_start
	.long LDIFF_SYM368
Lfde60_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize

LDIFF_SYM369=Lme_57 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_ScreenSize
	.long LDIFF_SYM369
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde60_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_SdkName"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName
	.quad Lme_58

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM370=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM370
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM371=Lfde61_end - Lfde61_start
	.long LDIFF_SYM371
Lfde61_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName

LDIFF_SYM372=Lme_58 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkName
	.long LDIFF_SYM372
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde61_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_SdkVersion"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion
	.quad Lme_59

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM373=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM373
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM374=Lfde62_end - Lfde62_start
	.long LDIFF_SYM374
Lfde62_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion

LDIFF_SYM375=Lme_59 - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_SdkVersion
	.long LDIFF_SYM375
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde62_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:get_TimeZoneOffset"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset
	.quad Lme_5a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM376=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM376
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM377=LTDIE_26_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM377
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM378=Lfde63_end - Lfde63_start
	.long LDIFF_SYM378
Lfde63_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset

LDIFF_SYM379=Lme_5a - Microsoft_AppCenter_iOS_Bindings_MSDevice_get_TimeZoneOffset
	.long LDIFF_SYM379
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,153,12
	.align 3
Lfde63_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSDevice:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor
	.quad Lme_5b

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM380=Lfde64_end - Lfde64_start
	.long LDIFF_SYM380
Lfde64_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor

LDIFF_SYM381=Lme_5b - Microsoft_AppCenter_iOS_Bindings_MSDevice__cctor
	.long LDIFF_SYM381
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde64_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_30:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger"

	.byte 40,16
LDIFF_SYM382=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM382
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger"

LDIFF_SYM383=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM383
LTDIE_30_POINTER:

	.byte 13
LDIFF_SYM384=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM384
LTDIE_30_REFERENCE:

	.byte 14
LDIFF_SYM385=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM385
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle
	.quad Lme_5c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM386=LTDIE_30_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM386
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM387=Lfde65_end - Lfde65_start
	.long LDIFF_SYM387
Lfde65_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle

LDIFF_SYM388=Lme_5c - Microsoft_AppCenter_iOS_Bindings_MSLogger_get_ClassHandle
	.long LDIFF_SYM388
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde65_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor
	.quad Lme_5d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM389=LTDIE_30_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM389
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM390=Lfde66_end - Lfde66_start
	.long LDIFF_SYM390
Lfde66_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor

LDIFF_SYM391=Lme_5d - Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor
	.long LDIFF_SYM391
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde66_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag
	.quad Lme_5e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM392=LTDIE_30_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM392
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM393=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM393
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM394=Lfde67_end - Lfde67_start
	.long LDIFF_SYM394
Lfde67_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag

LDIFF_SYM395=Lme_5e - Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM395
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde67_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr
	.quad Lme_5f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM396=LTDIE_30_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM396
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM397=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM397
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM398=Lfde68_end - Lfde68_start
	.long LDIFF_SYM398
Lfde68_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr

LDIFF_SYM399=Lme_5f - Microsoft_AppCenter_iOS_Bindings_MSLogger__ctor_intptr
	.long LDIFF_SYM399
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde68_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:LogMessage"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint
	.quad Lme_60

	.byte 2,118,16,3
	.asciz "messageProvider"

LDIFF_SYM400=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM400
	.byte 1,101,3
	.asciz "loglevel"

LDIFF_SYM401=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM401
	.byte 1,102,3
	.asciz "tag"

LDIFF_SYM402=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM402
	.byte 1,103,3
	.asciz "file"

LDIFF_SYM403=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM403
	.byte 1,104,3
	.asciz "function"

LDIFF_SYM404=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM404
	.byte 1,105,3
	.asciz "line"

LDIFF_SYM405=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM405
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM406=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM406
	.byte 1,100,11
	.asciz "V_1"

LDIFF_SYM407=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM407
	.byte 3,141,232,0,11
	.asciz "V_2"

LDIFF_SYM408=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM408
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM409=Lfde69_end - Lfde69_start
	.long LDIFF_SYM409
Lfde69_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint

LDIFF_SYM410=Lme_60 - Microsoft_AppCenter_iOS_Bindings_MSLogger_LogMessage_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_string_intptr_intptr_uint
	.long LDIFF_SYM410
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,147,22,148,21,68,149,20,150,19,68,151,18,152,17,68,153,16
	.byte 154,15
	.align 3
Lfde69_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSLogger:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor
	.quad Lme_61

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM411=Lfde70_end - Lfde70_start
	.long LDIFF_SYM411
Lfde70_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor

LDIFF_SYM412=Lme_61 - Microsoft_AppCenter_iOS_Bindings_MSLogger__cctor
	.long LDIFF_SYM412
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde70_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_32:

	.byte 5
	.asciz "ObjCRuntime_BaseWrapper"

	.byte 24,16
LDIFF_SYM413=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM413
	.byte 2,35,0,6
	.asciz "<Handle>k__BackingField"

LDIFF_SYM414=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM414
	.byte 2,35,16,0,7
	.asciz "ObjCRuntime_BaseWrapper"

LDIFF_SYM415=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM415
LTDIE_32_POINTER:

	.byte 13
LDIFF_SYM416=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM416
LTDIE_32_REFERENCE:

	.byte 14
LDIFF_SYM417=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM417
LTDIE_31:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper"

	.byte 24,16
LDIFF_SYM418=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM418
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper"

LDIFF_SYM419=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM419
LTDIE_31_POINTER:

	.byte 13
LDIFF_SYM420=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM420
LTDIE_31_REFERENCE:

	.byte 14
LDIFF_SYM421=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM421
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceWrapper:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool
	.quad Lme_62

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM422=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM422
	.byte 2,141,16,3
	.asciz "handle"

LDIFF_SYM423=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM423
	.byte 2,141,24,3
	.asciz "owns"

LDIFF_SYM424=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM424
	.byte 2,141,32,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM425=Lfde71_end - Lfde71_start
	.long LDIFF_SYM425
Lfde71_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool

LDIFF_SYM426=Lme_62 - Microsoft_AppCenter_iOS_Bindings_MSServiceWrapper__ctor_intptr_bool
	.long LDIFF_SYM426
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde71_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_33:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService"

	.byte 40,16
LDIFF_SYM427=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM427
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService"

LDIFF_SYM428=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM428
LTDIE_33_POINTER:

	.byte 13
LDIFF_SYM429=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM429
LTDIE_33_REFERENCE:

	.byte 14
LDIFF_SYM430=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM430
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSService:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor
	.quad Lme_63

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM431=LTDIE_33_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM431
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM432=Lfde72_end - Lfde72_start
	.long LDIFF_SYM432
Lfde72_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor

LDIFF_SYM433=Lme_63 - Microsoft_AppCenter_iOS_Bindings_MSService__ctor
	.long LDIFF_SYM433
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde72_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSService:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag
	.quad Lme_64

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM434=LTDIE_33_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM434
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM435=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM435
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM436=Lfde73_end - Lfde73_start
	.long LDIFF_SYM436
Lfde73_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag

LDIFF_SYM437=Lme_64 - Microsoft_AppCenter_iOS_Bindings_MSService__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM437
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde73_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSService:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr
	.quad Lme_65

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM438=LTDIE_33_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM438
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM439=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM439
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM440=Lfde74_end - Lfde74_start
	.long LDIFF_SYM440
Lfde74_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr

LDIFF_SYM441=Lme_65 - Microsoft_AppCenter_iOS_Bindings_MSService__ctor_intptr
	.long LDIFF_SYM441
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde74_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSService:GetEnabled"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled
	.quad Lme_66

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM442=Lfde75_end - Lfde75_start
	.long LDIFF_SYM442
Lfde75_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled

LDIFF_SYM443=Lme_66 - Microsoft_AppCenter_iOS_Bindings_MSService_GetEnabled
	.long LDIFF_SYM443
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde75_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSService:SetEnabled"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool
	.quad Lme_67

	.byte 2,118,16,3
	.asciz "val"

LDIFF_SYM444=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM444
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM445=Lfde76_end - Lfde76_start
	.long LDIFF_SYM445
Lfde76_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool

LDIFF_SYM446=Lme_67 - Microsoft_AppCenter_iOS_Bindings_MSService_SetEnabled_bool
	.long LDIFF_SYM446
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde76_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_34:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract"

	.byte 40,16
LDIFF_SYM447=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM447
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract"

LDIFF_SYM448=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM448
LTDIE_34_POINTER:

	.byte 13
LDIFF_SYM449=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM449
LTDIE_34_REFERENCE:

	.byte 14
LDIFF_SYM450=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM450
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle
	.quad Lme_68

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM451=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM451
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM452=Lfde77_end - Lfde77_start
	.long LDIFF_SYM452
Lfde77_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle

LDIFF_SYM453=Lme_68 - Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract_get_ClassHandle
	.long LDIFF_SYM453
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde77_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor
	.quad Lme_69

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM454=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM454
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM455=Lfde78_end - Lfde78_start
	.long LDIFF_SYM455
Lfde78_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor

LDIFF_SYM456=Lme_69 - Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor
	.long LDIFF_SYM456
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde78_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag
	.quad Lme_6a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM457=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM457
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM458=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM458
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM459=Lfde79_end - Lfde79_start
	.long LDIFF_SYM459
Lfde79_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag

LDIFF_SYM460=Lme_6a - Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM460
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde79_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr
	.quad Lme_6b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM461=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM461
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM462=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM462
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM463=Lfde80_end - Lfde80_start
	.long LDIFF_SYM463
Lfde80_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr

LDIFF_SYM464=Lme_6b - Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__ctor_intptr
	.long LDIFF_SYM464
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde80_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor
	.quad Lme_6c

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM465=Lfde81_end - Lfde81_start
	.long LDIFF_SYM465
Lfde81_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor

LDIFF_SYM466=Lme_6c - Microsoft_AppCenter_iOS_Bindings_MSServiceAbstract__cctor
	.long LDIFF_SYM466
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde81_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_35:

	.byte 5
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger"

	.byte 40,16
LDIFF_SYM467=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM467
	.byte 2,35,0,0,7
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger"

LDIFF_SYM468=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM468
LTDIE_35_POINTER:

	.byte 13
LDIFF_SYM469=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM469
LTDIE_35_REFERENCE:

	.byte 14
LDIFF_SYM470=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM470
	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle
	.quad Lme_6d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM471=LTDIE_35_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM471
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM472=Lfde82_end - Lfde82_start
	.long LDIFF_SYM472
Lfde82_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle

LDIFF_SYM473=Lme_6d - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_get_ClassHandle
	.long LDIFF_SYM473
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde82_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor
	.quad Lme_6e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM474=LTDIE_35_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM474
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM475=Lfde83_end - Lfde83_start
	.long LDIFF_SYM475
Lfde83_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor

LDIFF_SYM476=Lme_6e - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor
	.long LDIFF_SYM476
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde83_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag
	.quad Lme_6f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM477=LTDIE_35_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM477
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM478=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM478
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM479=Lfde84_end - Lfde84_start
	.long LDIFF_SYM479
Lfde84_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag

LDIFF_SYM480=Lme_6f - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM480
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde84_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr
	.quad Lme_70

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM481=LTDIE_35_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM481
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM482=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM482
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM483=Lfde85_end - Lfde85_start
	.long LDIFF_SYM483
Lfde85_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr

LDIFF_SYM484=Lme_70 - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__ctor_intptr
	.long LDIFF_SYM484
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde85_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:MSWrapperLog"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
	.quad Lme_71

	.byte 2,118,16,3
	.asciz "message"

LDIFF_SYM485=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM485
	.byte 1,104,3
	.asciz "tag"

LDIFF_SYM486=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM486
	.byte 1,105,3
	.asciz "level"

LDIFF_SYM487=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM487
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM488=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM488
	.byte 1,103,11
	.asciz "V_1"

LDIFF_SYM489=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM489
	.byte 3,141,208,0,11
	.asciz "V_2"

LDIFF_SYM490=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM490
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM491=Lfde86_end - Lfde86_start
	.long LDIFF_SYM491
Lfde86_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel

LDIFF_SYM492=Lme_71 - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger_MSWrapperLog_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_string_Microsoft_AppCenter_iOS_Bindings_MSLogLevel
	.long LDIFF_SYM492
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15,68,154,14
	.align 3
Lfde86_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor
	.quad Lme_72

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM493=Lfde87_end - Lfde87_start
	.long LDIFF_SYM493
Lfde87_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor

LDIFF_SYM494=Lme_72 - Microsoft_AppCenter_iOS_Bindings_MSWrapperLogger__cctor
	.long LDIFF_SYM494
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde87_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_ClassHandle"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle
	.quad Lme_73

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM495=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM495
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM496=Lfde88_end - Lfde88_start
	.long LDIFF_SYM496
Lfde88_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle

LDIFF_SYM497=Lme_73 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_ClassHandle
	.long LDIFF_SYM497
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde88_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor
	.quad Lme_74

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM498=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM498
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM499=Lfde89_end - Lfde89_start
	.long LDIFF_SYM499
Lfde89_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor

LDIFF_SYM500=Lme_74 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor
	.long LDIFF_SYM500
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde89_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag
	.quad Lme_75

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM501=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM501
	.byte 1,105,3
	.asciz "t"

LDIFF_SYM502=LTDIE_21_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM502
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM503=Lfde90_end - Lfde90_start
	.long LDIFF_SYM503
Lfde90_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag

LDIFF_SYM504=Lme_75 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_Foundation_NSObjectFlag
	.long LDIFF_SYM504
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde90_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr
	.quad Lme_76

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM505=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM505
	.byte 1,105,3
	.asciz "handle"

LDIFF_SYM506=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM506
	.byte 2,141,24,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM507=Lfde91_end - Lfde91_start
	.long LDIFF_SYM507
Lfde91_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr

LDIFF_SYM508=Lme_76 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_intptr
	.long LDIFF_SYM508
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,153,10
	.align 3
Lfde91_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:.ctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string
	.quad Lme_77

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM509=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM509
	.byte 1,100,3
	.asciz "wrapperSdkVersion"

LDIFF_SYM510=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM510
	.byte 2,141,32,3
	.asciz "wrapperSdkName"

LDIFF_SYM511=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM511
	.byte 2,141,40,3
	.asciz "wrapperRuntimeVersion"

LDIFF_SYM512=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM512
	.byte 2,141,48,3
	.asciz "liveUpdateReleaseLabel"

LDIFF_SYM513=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM513
	.byte 2,141,56,3
	.asciz "liveUpdateDeploymentKey"

LDIFF_SYM514=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM514
	.byte 3,141,192,0,3
	.asciz "liveUpdatePackageHash"

LDIFF_SYM515=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM515
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM516=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM516
	.byte 1,99,11
	.asciz "V_1"

LDIFF_SYM517=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM517
	.byte 3,141,232,0,11
	.asciz "V_2"

LDIFF_SYM518=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM518
	.byte 3,141,240,0,11
	.asciz "V_3"

LDIFF_SYM519=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM519
	.byte 3,141,248,0,11
	.asciz "V_4"

LDIFF_SYM520=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM520
	.byte 3,141,128,1,11
	.asciz "V_5"

LDIFF_SYM521=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM521
	.byte 3,141,136,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM522=Lfde92_end - Lfde92_start
	.long LDIFF_SYM522
Lfde92_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string

LDIFF_SYM523=Lme_77 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__ctor_string_string_string_string_string_string
	.long LDIFF_SYM523
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,68,147,28,148,27
	.align 3
Lfde92_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:IsEqual"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
	.quad Lme_78

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM524=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM524
	.byte 2,141,24,3
	.asciz "wrapperSdk"

LDIFF_SYM525=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM525
	.byte 1,106,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM526=Lfde93_end - Lfde93_start
	.long LDIFF_SYM526
Lfde93_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk

LDIFF_SYM527=Lme_78 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_IsEqual_Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk
	.long LDIFF_SYM527
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,154,10
	.align 3
Lfde93_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_LiveUpdateDeploymentKey"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey
	.quad Lme_79

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM528=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM528
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM529=Lfde94_end - Lfde94_start
	.long LDIFF_SYM529
Lfde94_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey

LDIFF_SYM530=Lme_79 - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateDeploymentKey
	.long LDIFF_SYM530
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde94_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_LiveUpdatePackageHash"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash
	.quad Lme_7a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM531=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM531
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM532=Lfde95_end - Lfde95_start
	.long LDIFF_SYM532
Lfde95_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash

LDIFF_SYM533=Lme_7a - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdatePackageHash
	.long LDIFF_SYM533
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde95_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_LiveUpdateReleaseLabel"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel
	.quad Lme_7b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM534=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM534
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM535=Lfde96_end - Lfde96_start
	.long LDIFF_SYM535
Lfde96_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel

LDIFF_SYM536=Lme_7b - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_LiveUpdateReleaseLabel
	.long LDIFF_SYM536
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde96_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_WrapperRuntimeVersion"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion
	.quad Lme_7c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM537=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM537
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM538=Lfde97_end - Lfde97_start
	.long LDIFF_SYM538
Lfde97_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion

LDIFF_SYM539=Lme_7c - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperRuntimeVersion
	.long LDIFF_SYM539
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde97_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_WrapperSdkName"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName
	.quad Lme_7d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM540=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM540
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM541=Lfde98_end - Lfde98_start
	.long LDIFF_SYM541
Lfde98_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName

LDIFF_SYM542=Lme_7d - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkName
	.long LDIFF_SYM542
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde98_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:get_WrapperSdkVersion"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion
	.quad Lme_7e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM543=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM543
	.byte 2,141,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM544=Lfde99_end - Lfde99_start
	.long LDIFF_SYM544
Lfde99_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion

LDIFF_SYM545=Lme_7e - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk_get_WrapperSdkVersion
	.long LDIFF_SYM545
	.long 0
	.byte 12,31,0,68,14,80,157,10,158,9,68,13,29
	.align 3
Lfde99_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk:.cctor"
	.asciz "Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor"

	.byte 0,0
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor
	.quad Lme_7f

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM546=Lfde100_end - Lfde100_start
	.long LDIFF_SYM546
Lfde100_start:

	.long 0
	.align 3
	.quad Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor

LDIFF_SYM547=Lme_7f - Microsoft_AppCenter_iOS_Bindings_MSWrapperSdk__cctor
	.long LDIFF_SYM547
	.long 0
	.byte 12,31,0,68,14,64,157,8,158,7,68,13,29
	.align 3
Lfde100_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_36:

	.byte 17
	.asciz "_<Module>"

	.byte 16,7
	.asciz "_<Module>"

LDIFF_SYM548=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM548
LTDIE_36_POINTER:

	.byte 13
LDIFF_SYM549=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM549
LTDIE_36_REFERENCE:

	.byte 14
LDIFF_SYM550=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM550
LTDIE_37:

	.byte 5
	.asciz "System_Int32"

	.byte 20,16
LDIFF_SYM551=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM551
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM552=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM552
	.byte 2,35,16,0,7
	.asciz "System_Int32"

LDIFF_SYM553=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM553
LTDIE_37_POINTER:

	.byte 13
LDIFF_SYM554=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM554
LTDIE_37_REFERENCE:

	.byte 14
LDIFF_SYM555=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM555
LTDIE_38:

	.byte 5
	.asciz "System_Array"

	.byte 16,16
LDIFF_SYM556=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM556
	.byte 2,35,0,0,7
	.asciz "System_Array"

LDIFF_SYM557=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM557
LTDIE_38_POINTER:

	.byte 13
LDIFF_SYM558=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM558
LTDIE_38_REFERENCE:

	.byte 14
LDIFF_SYM559=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM559
	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_void_intptr_intptr_nuint_intptr_intptr_uint"
	.asciz "wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
	.quad Lme_89

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM560=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM560
	.byte 1,100,3
	.asciz "param0"

LDIFF_SYM561=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM561
	.byte 1,101,3
	.asciz "param1"

LDIFF_SYM562=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM562
	.byte 1,102,3
	.asciz "param2"

LDIFF_SYM563=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM563
	.byte 1,103,3
	.asciz "param3"

LDIFF_SYM564=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM564
	.byte 1,104,3
	.asciz "param4"

LDIFF_SYM565=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM565
	.byte 3,141,208,0,3
	.asciz "param5"

LDIFF_SYM566=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM566
	.byte 3,141,216,0,11
	.asciz "V_0"

LDIFF_SYM567=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM567
	.byte 1,99,11
	.asciz "V_1"

LDIFF_SYM568=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM568
	.byte 3,141,248,0,11
	.asciz "V_2"

LDIFF_SYM569=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM569
	.byte 1,106,11
	.asciz "V_3"

LDIFF_SYM570=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM570
	.byte 1,105,11
	.asciz "V_4"

LDIFF_SYM571=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM571
	.byte 3,141,128,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM572=Lfde101_end - Lfde101_start
	.long LDIFF_SYM572
Lfde101_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint

LDIFF_SYM573=Lme_89 - wrapper_delegate_invoke__Module_invoke_void_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
	.long LDIFF_SYM573
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,68,147,20,148,19,68,149,18,150,17,68,151,16,152,15,68,153,14
	.byte 154,13
	.align 3
Lfde101_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_39:

	.byte 5
	.asciz "System_AsyncCallback"

	.byte 112,16
LDIFF_SYM574=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM574
	.byte 2,35,0,0,7
	.asciz "System_AsyncCallback"

LDIFF_SYM575=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM575
LTDIE_39_POINTER:

	.byte 13
LDIFF_SYM576=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM576
LTDIE_39_REFERENCE:

	.byte 14
LDIFF_SYM577=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM577
	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object
	.quad Lme_8a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM578=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM578
	.byte 2,141,56,3
	.asciz "param0"

LDIFF_SYM579=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM579
	.byte 3,141,192,0,3
	.asciz "param1"

LDIFF_SYM580=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM580
	.byte 3,141,200,0,3
	.asciz "param2"

LDIFF_SYM581=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM581
	.byte 3,141,208,0,3
	.asciz "param3"

LDIFF_SYM582=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM582
	.byte 3,141,216,0,3
	.asciz "param4"

LDIFF_SYM583=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM583
	.byte 3,141,224,0,3
	.asciz "param5"

LDIFF_SYM584=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM584
	.byte 3,141,232,0,3
	.asciz "param6"

LDIFF_SYM585=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM585
	.byte 3,141,240,0,3
	.asciz "param7"

LDIFF_SYM586=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM586
	.byte 2,140,0,11
	.asciz "V_0"

LDIFF_SYM587=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM587
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM588=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM588
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM589=Lfde102_end - Lfde102_start
	.long LDIFF_SYM589
Lfde102_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object

LDIFF_SYM590=Lme_8a - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_intptr_nuint_intptr_intptr_uint_AsyncCallback_object_intptr_intptr_System_nuint_intptr_intptr_uint_System_AsyncCallback_object
	.long LDIFF_SYM590
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15,68,156,14
	.align 3
Lfde102_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_40:

	.byte 17
	.asciz "System_IAsyncResult"

	.byte 16,7
	.asciz "System_IAsyncResult"

LDIFF_SYM591=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM591
LTDIE_40_POINTER:

	.byte 13
LDIFF_SYM592=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM592
LTDIE_40_REFERENCE:

	.byte 14
LDIFF_SYM593=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM593
	.byte 2
	.asciz "(wrapper_delegate-end-invoke)_<Module>:end_invoke_void__this___IAsyncResult"
	.asciz "wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult"

	.byte 0,0
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.quad Lme_8b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM594=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM594
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM595=LTDIE_40_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM595
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM596=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM596
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM597=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM597
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM598=Lfde103_end - Lfde103_start
	.long LDIFF_SYM598
Lfde103_start:

	.long 0
	.align 3
	.quad wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult

LDIFF_SYM599=Lme_8b - wrapper_delegate_end_invoke__Module_end_invoke_void__this___IAsyncResult_System_IAsyncResult
	.long LDIFF_SYM599
	.long 0
	.byte 12,31,0,68,14,96,157,12,158,11,68,13,29,68,150,10,151,9,68,152,8,153,7
	.align 3
Lfde103_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines/DMSLogHandler:wrapper_aot_native"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint
	.quad Lme_8c

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM600=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM600
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM601=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM601
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM602=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM602
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM603=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM603
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM604=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM604
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM605=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM605
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM606=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM606
	.byte 3,141,192,0,11
	.asciz "V_0"

LDIFF_SYM607=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM607
	.byte 3,141,216,1,11
	.asciz "V_1"

LDIFF_SYM608=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM608
	.byte 3,141,224,1,11
	.asciz "V_2"

LDIFF_SYM609=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM609
	.byte 3,141,232,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM610=Lfde104_end - Lfde104_start
	.long LDIFF_SYM610
Lfde104_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint

LDIFF_SYM611=Lme_8c - wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogHandler_wrapper_aot_native_object_intptr_intptr_System_nuint_intptr_intptr_uint
	.long LDIFF_SYM611
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde104_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint"
	.asciz "wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
	.quad Lme_8d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM612=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM612
	.byte 1,100,3
	.asciz "param0"

LDIFF_SYM613=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM613
	.byte 1,101,3
	.asciz "param1"

LDIFF_SYM614=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM614
	.byte 1,102,3
	.asciz "param2"

LDIFF_SYM615=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM615
	.byte 1,103,3
	.asciz "param3"

LDIFF_SYM616=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM616
	.byte 3,141,208,0,3
	.asciz "param4"

LDIFF_SYM617=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM617
	.byte 3,141,216,0,3
	.asciz "param5"

LDIFF_SYM618=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM618
	.byte 3,141,224,0,11
	.asciz "V_0"

LDIFF_SYM619=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM619
	.byte 1,99,11
	.asciz "V_1"

LDIFF_SYM620=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM620
	.byte 1,106,11
	.asciz "V_2"

LDIFF_SYM621=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM621
	.byte 1,105,11
	.asciz "V_3"

LDIFF_SYM622=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM622
	.byte 1,104,11
	.asciz "V_4"

LDIFF_SYM623=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM623
	.byte 3,141,128,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM624=Lfde105_end - Lfde105_start
	.long LDIFF_SYM624
Lfde105_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint

LDIFF_SYM625=Lme_8d - wrapper_delegate_invoke__Module_invoke_bound_void_object_intptr_intptr_nuint_intptr_intptr_uint_intptr_intptr_System_nuint_intptr_intptr_uint
	.long LDIFF_SYM625
	.long 0
	.byte 12,31,0,68,14,176,1,157,22,158,21,68,13,29,68,147,20,148,19,68,149,18,150,17,68,151,16,152,15,68,153,14
	.byte 154,13
	.align 3
Lfde105_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_intptr_intptr"
	.asciz "wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr
	.quad Lme_8e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM626=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM626
	.byte 1,105,3
	.asciz "param0"

LDIFF_SYM627=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM627
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM628=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM628
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM629=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM629
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM630=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM630
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM631=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM631
	.byte 1,101,11
	.asciz "V_4"

LDIFF_SYM632=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM632
	.byte 1,100,11
	.asciz "V_5"

LDIFF_SYM633=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM633
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM634=Lfde106_end - Lfde106_start
	.long LDIFF_SYM634
Lfde106_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr

LDIFF_SYM635=Lme_8e - wrapper_delegate_invoke__Module_invoke_intptr_intptr_intptr
	.long LDIFF_SYM635
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde106_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object
	.quad Lme_8f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM636=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM636
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM637=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM637
	.byte 2,141,56,3
	.asciz "param1"

LDIFF_SYM638=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM638
	.byte 3,141,192,0,3
	.asciz "param2"

LDIFF_SYM639=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM639
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM640=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM640
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM641=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM641
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM642=Lfde107_end - Lfde107_start
	.long LDIFF_SYM642
Lfde107_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object

LDIFF_SYM643=Lme_8f - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___intptr_AsyncCallback_object_intptr_System_AsyncCallback_object
	.long LDIFF_SYM643
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,150,14,151,13,68,152,12,153,11
	.align 3
Lfde107_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-end-invoke)_<Module>:end_invoke_intptr__this___IAsyncResult"
	.asciz "wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult"

	.byte 0,0
	.quad wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult
	.quad Lme_90

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM644=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM644
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM645=LTDIE_40_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM645
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM646=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM646
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM647=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM647
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM648=Lfde108_end - Lfde108_start
	.long LDIFF_SYM648
Lfde108_start:

	.long 0
	.align 3
	.quad wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult

LDIFF_SYM649=Lme_90 - wrapper_delegate_end_invoke__Module_end_invoke_intptr__this___IAsyncResult_System_IAsyncResult
	.long LDIFF_SYM649
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,150,12,151,11,68,152,10,153,9
	.align 3
Lfde108_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines/DMSLogMessageProvider:wrapper_aot_native"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr
	.quad Lme_91

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM650=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM650
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM651=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM651
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM652=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM652
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM653=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM653
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM654=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM654
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM655=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM655
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM656=Lfde109_end - Lfde109_start
	.long LDIFF_SYM656
Lfde109_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr

LDIFF_SYM657=Lme_91 - wrapper_managed_to_native_ObjCRuntime_Trampolines_DMSLogMessageProvider_wrapper_aot_native_object_intptr
	.long LDIFF_SYM657
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde109_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_bound_intptr_object_intptr"
	.asciz "wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr
	.quad Lme_92

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM658=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM658
	.byte 1,105,3
	.asciz "param0"

LDIFF_SYM659=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM659
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM660=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM660
	.byte 1,104,11
	.asciz "V_1"

LDIFF_SYM661=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM661
	.byte 1,103,11
	.asciz "V_2"

LDIFF_SYM662=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM662
	.byte 1,102,11
	.asciz "V_3"

LDIFF_SYM663=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM663
	.byte 1,101,11
	.asciz "V_4"

LDIFF_SYM664=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM664
	.byte 1,100,11
	.asciz "V_5"

LDIFF_SYM665=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM665
	.byte 1,99,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM666=Lfde110_end - Lfde110_start
	.long LDIFF_SYM666
Lfde110_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr

LDIFF_SYM667=Lme_92 - wrapper_delegate_invoke__Module_invoke_bound_intptr_object_intptr_intptr
	.long LDIFF_SYM667
	.long 0
	.byte 12,31,0,68,14,144,1,157,18,158,17,68,13,29,68,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9
	.align 3
Lfde110_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint"
	.asciz "wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
	.quad Lme_93

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM668=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM668
	.byte 1,101,3
	.asciz "param0"

LDIFF_SYM669=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM669
	.byte 1,102,3
	.asciz "param1"

LDIFF_SYM670=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM670
	.byte 1,103,3
	.asciz "param2"

LDIFF_SYM671=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM671
	.byte 1,104,3
	.asciz "param3"

LDIFF_SYM672=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM672
	.byte 3,141,208,0,3
	.asciz "param4"

LDIFF_SYM673=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM673
	.byte 3,141,216,0,11
	.asciz "V_0"

LDIFF_SYM674=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM674
	.byte 1,100,11
	.asciz "V_1"

LDIFF_SYM675=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM675
	.byte 1,99,11
	.asciz "V_2"

LDIFF_SYM676=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM676
	.byte 1,106,11
	.asciz "V_3"

LDIFF_SYM677=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM677
	.byte 1,105,11
	.asciz "V_4"

LDIFF_SYM678=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM678
	.byte 3,141,248,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM679=Lfde111_end - Lfde111_start
	.long LDIFF_SYM679
Lfde111_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint

LDIFF_SYM680=Lme_93 - wrapper_delegate_invoke__Module_invoke_void_MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint
	.long LDIFF_SYM680
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,149,16,150,15,68,151,14,152,13,68,153,12
	.byte 154,11
	.align 3
Lfde111_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object
	.quad Lme_94

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM681=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM681
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM682=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM682
	.byte 2,141,56,3
	.asciz "param1"

LDIFF_SYM683=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM683
	.byte 3,141,192,0,3
	.asciz "param2"

LDIFF_SYM684=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM684
	.byte 3,141,200,0,3
	.asciz "param3"

LDIFF_SYM685=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM685
	.byte 3,141,208,0,3
	.asciz "param4"

LDIFF_SYM686=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM686
	.byte 3,141,216,0,3
	.asciz "param5"

LDIFF_SYM687=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM687
	.byte 3,141,224,0,3
	.asciz "param6"

LDIFF_SYM688=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM688
	.byte 3,141,232,0,11
	.asciz "V_0"

LDIFF_SYM689=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM689
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM690=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM690
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM691=Lfde112_end - Lfde112_start
	.long LDIFF_SYM691
Lfde112_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object

LDIFF_SYM692=Lme_94 - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___MSLogMessageProvider_MSLogLevel_intptr_intptr_uint_AsyncCallback_object_Microsoft_AppCenter_iOS_Bindings_MSLogMessageProvider_Microsoft_AppCenter_iOS_Bindings_MSLogLevel_intptr_intptr_uint_System_AsyncCallback_object
	.long LDIFF_SYM692
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,150,18,151,17,68,152,16,153,15
	.align 3
Lfde112_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-invoke)_<Module>:invoke_string"
	.asciz "wrapper_delegate_invoke__Module_invoke_string"

	.byte 0,0
	.quad wrapper_delegate_invoke__Module_invoke_string
	.quad Lme_95

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM693=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM693
	.byte 1,106,11
	.asciz "V_0"

LDIFF_SYM694=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM694
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM695=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM695
	.byte 1,104,11
	.asciz "V_2"

LDIFF_SYM696=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM696
	.byte 1,103,11
	.asciz "V_3"

LDIFF_SYM697=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM697
	.byte 1,102,11
	.asciz "V_4"

LDIFF_SYM698=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM698
	.byte 1,101,11
	.asciz "V_5"

LDIFF_SYM699=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM699
	.byte 1,100,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM700=Lfde113_end - Lfde113_start
	.long LDIFF_SYM700
Lfde113_start:

	.long 0
	.align 3
	.quad wrapper_delegate_invoke__Module_invoke_string

LDIFF_SYM701=Lme_95 - wrapper_delegate_invoke__Module_invoke_string
	.long LDIFF_SYM701
	.long 0
	.byte 12,31,0,68,14,128,1,157,16,158,15,68,13,29,68,147,14,148,13,68,149,12,150,11,68,151,10,152,9,68,153,8
	.byte 154,7
	.align 3
Lfde113_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-begin-invoke)_<Module>:begin_invoke_IAsyncResult__this___AsyncCallback_object"
	.asciz "wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object"

	.byte 0,0
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object
	.quad Lme_96

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM702=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM702
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM703=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM703
	.byte 2,141,56,3
	.asciz "param1"

LDIFF_SYM704=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM704
	.byte 3,141,192,0,11
	.asciz "V_0"

LDIFF_SYM705=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM705
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM706=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM706
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM707=Lfde114_end - Lfde114_start
	.long LDIFF_SYM707
Lfde114_start:

	.long 0
	.align 3
	.quad wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object

LDIFF_SYM708=Lme_96 - wrapper_delegate_begin_invoke__Module_begin_invoke_IAsyncResult__this___AsyncCallback_object_System_AsyncCallback_object
	.long LDIFF_SYM708
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,150,12,151,11,68,152,10,153,9
	.align 3
Lfde114_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_delegate-end-invoke)_<Module>:end_invoke_string__this___IAsyncResult"
	.asciz "wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult"

	.byte 0,0
	.quad wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult
	.quad Lme_97

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM709=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM709
	.byte 2,141,48,3
	.asciz "param0"

LDIFF_SYM710=LTDIE_40_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM710
	.byte 2,141,56,11
	.asciz "V_0"

LDIFF_SYM711=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM711
	.byte 1,105,11
	.asciz "V_1"

LDIFF_SYM712=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM712
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM713=Lfde115_end - Lfde115_start
	.long LDIFF_SYM713
Lfde115_start:

	.long 0
	.align 3
	.quad wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult

LDIFF_SYM714=Lme_97 - wrapper_delegate_end_invoke__Module_end_invoke_string__this___IAsyncResult_System_IAsyncResult
	.long LDIFF_SYM714
	.long 0
	.byte 12,31,0,68,14,112,157,14,158,13,68,13,29,68,150,12,151,11,68,152,10,153,9
	.align 3
Lfde115_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines:_Block_copy"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
	.quad Lme_98

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM715=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM715
	.byte 2,141,16,11
	.asciz "V_0"

LDIFF_SYM716=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM716
	.byte 3,141,168,1,11
	.asciz "V_1"

LDIFF_SYM717=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM717
	.byte 3,141,176,1,11
	.asciz "V_2"

LDIFF_SYM718=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM718
	.byte 3,141,184,1,11
	.asciz "V_3"

LDIFF_SYM719=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM719
	.byte 1,104,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM720=Lfde116_end - Lfde116_start
	.long LDIFF_SYM720
Lfde116_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr

LDIFF_SYM721=Lme_98 - wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_copy_intptr
	.long LDIFF_SYM721
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde116_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ObjCRuntime.Trampolines:_Block_release"
	.asciz "wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
	.quad Lme_99

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM722=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM722
	.byte 2,141,16,11
	.asciz "V_0"

LDIFF_SYM723=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM723
	.byte 3,141,168,1,11
	.asciz "V_1"

LDIFF_SYM724=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM724
	.byte 3,141,176,1,11
	.asciz "V_2"

LDIFF_SYM725=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM725
	.byte 3,141,184,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM726=Lfde117_end - Lfde117_start
	.long LDIFF_SYM726
Lfde117_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr

LDIFF_SYM727=Lme_99 - wrapper_managed_to_native_ObjCRuntime_Trampolines__Block_release_intptr
	.long LDIFF_SYM727
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde117_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.quad Lme_9a

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM728=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM728
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM729=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM729
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM730=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM730
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM731=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM731
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM732=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM732
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM733=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM733
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM734=Lfde118_end - Lfde118_start
	.long LDIFF_SYM734
Lfde118_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr

LDIFF_SYM735=Lme_9a - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_intptr_intptr
	.long LDIFF_SYM735
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde118_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSendSuper"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.quad Lme_9b

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM736=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM736
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM737=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM737
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM738=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM738
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM739=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM739
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM740=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM740
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM741=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM741
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM742=Lfde119_end - Lfde119_start
	.long LDIFF_SYM742
Lfde119_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr

LDIFF_SYM743=Lme_9b - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSendSuper_intptr_intptr
	.long LDIFF_SYM743
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde119_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_9c

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM744=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM744
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM745=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM745
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM746=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM746
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM747=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM747
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM748=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM748
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM749=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM749
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM750=Lfde120_end - Lfde120_start
	.long LDIFF_SYM750
Lfde120_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM751=Lme_9c - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM751
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde120_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.quad Lme_9d

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM752=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM752
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM753=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM753
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM754=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM754
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM755=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM755
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM756=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM756
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM757=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM757
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM758=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM758
	.byte 3,141,208,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM759=Lfde121_end - Lfde121_start
	.long LDIFF_SYM759
Lfde121_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr

LDIFF_SYM760=Lme_9d - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM760
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde121_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.quad Lme_9e

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM761=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM761
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM762=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM762
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM763=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM763
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM764=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM764
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM765=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM765
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM766=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM766
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM767=Lfde122_end - Lfde122_start
	.long LDIFF_SYM767
Lfde122_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr

LDIFF_SYM768=Lme_9e - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_intptr_intptr
	.long LDIFF_SYM768
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde122_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_bool"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.quad Lme_9f

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM769=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM769
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM770=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM770
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM771=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM771
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM772=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM772
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM773=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM773
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM774=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM774
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM775=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM775
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM776=Lfde123_end - Lfde123_start
	.long LDIFF_SYM776
Lfde123_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool

LDIFF_SYM777=Lme_9f - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_intptr_intptr_bool
	.long LDIFF_SYM777
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde123_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:UInt32_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
	.quad Lme_a0

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM778=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM778
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM779=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM779
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM780=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM780
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM781=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM781
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM782=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM782
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM783=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM783
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM784=Lfde124_end - Lfde124_start
	.long LDIFF_SYM784
Lfde124_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr

LDIFF_SYM785=Lme_a0 - wrapper_managed_to_native_ApiDefinition_Messaging_UInt32_objc_msgSend_intptr_intptr
	.long LDIFF_SYM785
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde124_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_41:

	.byte 5
	.asciz "System_UInt64"

	.byte 24,16
LDIFF_SYM786=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM786
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM787=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM787
	.byte 2,35,16,0,7
	.asciz "System_UInt64"

LDIFF_SYM788=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM788
LTDIE_41_POINTER:

	.byte 13
LDIFF_SYM789=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM789
LTDIE_41_REFERENCE:

	.byte 14
LDIFF_SYM790=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM790
	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:UInt64_objc_msgSend"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
	.quad Lme_a1

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM791=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM791
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM792=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM792
	.byte 2,141,24,11
	.asciz "V_0"

LDIFF_SYM793=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM793
	.byte 3,141,176,1,11
	.asciz "V_1"

LDIFF_SYM794=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM794
	.byte 3,141,184,1,11
	.asciz "V_2"

LDIFF_SYM795=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM795
	.byte 3,141,192,1,11
	.asciz "V_3"

LDIFF_SYM796=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM796
	.byte 1,103,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM797=Lfde125_end - Lfde125_start
	.long LDIFF_SYM797
Lfde125_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr

LDIFF_SYM798=Lme_a1 - wrapper_managed_to_native_ApiDefinition_Messaging_UInt64_objc_msgSend_intptr_intptr
	.long LDIFF_SYM798
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde125_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_UInt32"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
	.quad Lme_a2

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM799=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM799
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM800=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM800
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM801=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM801
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM802=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM802
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM803=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM803
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM804=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM804
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM805=Lfde126_end - Lfde126_start
	.long LDIFF_SYM805
Lfde126_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint

LDIFF_SYM806=Lme_a2 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt32_intptr_intptr_uint
	.long LDIFF_SYM806
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde126_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_UInt64"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
	.quad Lme_a3

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM807=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM807
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM808=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM808
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM809=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM809
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM810=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM810
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM811=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM811
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM812=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM812
	.byte 3,141,200,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM813=Lfde127_end - Lfde127_start
	.long LDIFF_SYM813
Lfde127_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong

LDIFF_SYM814=Lme_a3 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_UInt64_intptr_intptr_ulong
	.long LDIFF_SYM814
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde127_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_bool_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
	.quad Lme_a4

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM815=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM815
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM816=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM816
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM817=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM817
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM818=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM818
	.byte 2,141,40,11
	.asciz "V_0"

LDIFF_SYM819=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM819
	.byte 3,141,192,1,11
	.asciz "V_1"

LDIFF_SYM820=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM820
	.byte 3,141,200,1,11
	.asciz "V_2"

LDIFF_SYM821=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM821
	.byte 3,141,208,1,11
	.asciz "V_3"

LDIFF_SYM822=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM822
	.byte 1,101,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM823=Lfde128_end - Lfde128_start
	.long LDIFF_SYM823
Lfde128_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr

LDIFF_SYM824=Lme_a4 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_bool_IntPtr_intptr_intptr_bool_intptr
	.long LDIFF_SYM824
	.long 0
	.byte 12,31,0,68,14,224,1,157,28,158,27,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde128_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:bool_objc_msgSend_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
	.quad Lme_a5

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM825=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM825
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM826=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM826
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM827=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM827
	.byte 2,141,32,11
	.asciz "V_0"

LDIFF_SYM828=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM828
	.byte 3,141,184,1,11
	.asciz "V_1"

LDIFF_SYM829=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM829
	.byte 3,141,192,1,11
	.asciz "V_2"

LDIFF_SYM830=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM830
	.byte 3,141,200,1,11
	.asciz "V_3"

LDIFF_SYM831=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM831
	.byte 1,102,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM832=Lfde129_end - Lfde129_start
	.long LDIFF_SYM832
Lfde129_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr

LDIFF_SYM833=Lme_a5 - wrapper_managed_to_native_ApiDefinition_Messaging_bool_objc_msgSend_IntPtr_intptr_intptr_intptr
	.long LDIFF_SYM833
	.long 0
	.byte 12,31,0,68,14,208,1,157,26,158,25,68,13,29,76,147,15,148,14,68,149,13,150,12,68,151,11,152,10,68,153,9
	.byte 154,8,68,155,7,156,6
	.align 3
Lfde129_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
	.quad Lme_a6

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM834=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM834
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM835=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM835
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM836=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM836
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM837=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM837
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM838=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM838
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM839=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM839
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM840=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM840
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM841=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM841
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM842=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM842
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM843=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM843
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM844=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM844
	.byte 3,141,240,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM845=Lfde130_end - Lfde130_start
	.long LDIFF_SYM845
Lfde130_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint

LDIFF_SYM846=Lme_a6 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt32_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_uint_intptr_intptr_intptr_uint
	.long LDIFF_SYM846
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde130_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
	.quad Lme_a7

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM847=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM847
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM848=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM848
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM849=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM849
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM850=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM850
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM851=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM851
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM852=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM852
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM853=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM853
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM854=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM854
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM855=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM855
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM856=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM856
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM857=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM857
	.byte 3,141,240,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM858=Lfde131_end - Lfde131_start
	.long LDIFF_SYM858
Lfde131_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint

LDIFF_SYM859=Lme_a7 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_UInt64_IntPtr_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_ulong_intptr_intptr_intptr_uint
	.long LDIFF_SYM859
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde131_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr_UInt32"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
	.quad Lme_a8

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM860=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM860
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM861=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM861
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM862=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM862
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM863=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM863
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM864=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM864
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM865=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM865
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM866=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM866
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM867=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM867
	.byte 3,141,216,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM868=Lfde132_end - Lfde132_start
	.long LDIFF_SYM868
Lfde132_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint

LDIFF_SYM869=Lme_a8 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt32_intptr_intptr_intptr_intptr_uint
	.long LDIFF_SYM869
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde132_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:void_objc_msgSend_IntPtr_IntPtr_UInt64"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
	.quad Lme_a9

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM870=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM870
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM871=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM871
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM872=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM872
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM873=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM873
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM874=LDIE_U8 - Ldebug_info_start
	.long LDIFF_SYM874
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM875=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM875
	.byte 3,141,200,1,11
	.asciz "V_1"

LDIFF_SYM876=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM876
	.byte 3,141,208,1,11
	.asciz "V_2"

LDIFF_SYM877=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM877
	.byte 3,141,216,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM878=Lfde133_end - Lfde133_start
	.long LDIFF_SYM878
Lfde133_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong

LDIFF_SYM879=Lme_a9 - wrapper_managed_to_native_ApiDefinition_Messaging_void_objc_msgSend_IntPtr_IntPtr_UInt64_intptr_intptr_intptr_intptr_ulong
	.long LDIFF_SYM879
	.long 0
	.byte 12,31,0,68,14,240,1,157,30,158,29,68,13,29,76,147,17,148,16,68,149,15,150,14,68,151,13,152,12,68,153,11
	.byte 154,10,68,155,9,156,8
	.align 3
Lfde133_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_managed-to-native)_ApiDefinition.Messaging:IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr"
	.asciz "wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr"

	.byte 0,0
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.quad Lme_aa

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM880=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM880
	.byte 2,141,16,3
	.asciz "param1"

LDIFF_SYM881=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM881
	.byte 2,141,24,3
	.asciz "param2"

LDIFF_SYM882=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM882
	.byte 2,141,32,3
	.asciz "param3"

LDIFF_SYM883=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM883
	.byte 2,141,40,3
	.asciz "param4"

LDIFF_SYM884=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM884
	.byte 2,141,48,3
	.asciz "param5"

LDIFF_SYM885=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM885
	.byte 2,141,56,3
	.asciz "param6"

LDIFF_SYM886=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM886
	.byte 3,141,192,0,3
	.asciz "param7"

LDIFF_SYM887=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM887
	.byte 3,141,200,0,11
	.asciz "V_0"

LDIFF_SYM888=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM888
	.byte 3,141,224,1,11
	.asciz "V_1"

LDIFF_SYM889=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM889
	.byte 3,141,232,1,11
	.asciz "V_2"

LDIFF_SYM890=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM890
	.byte 3,141,240,1,11
	.asciz "V_3"

LDIFF_SYM891=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM891
	.byte 1,105,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM892=Lfde134_end - Lfde134_start
	.long LDIFF_SYM892
Lfde134_start:

	.long 0
	.align 3
	.quad wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr

LDIFF_SYM893=Lme_aa - wrapper_managed_to_native_ApiDefinition_Messaging_IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr_intptr_intptr_intptr_intptr_intptr_intptr_intptr_intptr
	.long LDIFF_SYM893
	.long 0
	.byte 12,31,0,68,14,128,2,157,32,158,31,68,13,29,76,147,16,148,15,68,149,14,150,13,68,151,12,152,11,68,153,10
	.byte 154,9,68,155,8,156,7
	.align 3
Lfde134_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_43:

	.byte 17
	.asciz "System_Collections_IDictionary"

	.byte 16,7
	.asciz "System_Collections_IDictionary"

LDIFF_SYM894=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM894
LTDIE_43_POINTER:

	.byte 13
LDIFF_SYM895=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM895
LTDIE_43_REFERENCE:

	.byte 14
LDIFF_SYM896=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM896
LTDIE_45:

	.byte 17
	.asciz "System_Collections_Generic_IList`1"

	.byte 16,7
	.asciz "System_Collections_Generic_IList`1"

LDIFF_SYM897=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM897
LTDIE_45_POINTER:

	.byte 13
LDIFF_SYM898=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM898
LTDIE_45_REFERENCE:

	.byte 14
LDIFF_SYM899=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM899
LTDIE_48:

	.byte 17
	.asciz "System_Collections_Generic_IEqualityComparer`1"

	.byte 16,7
	.asciz "System_Collections_Generic_IEqualityComparer`1"

LDIFF_SYM900=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM900
LTDIE_48_POINTER:

	.byte 13
LDIFF_SYM901=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM901
LTDIE_48_REFERENCE:

	.byte 14
LDIFF_SYM902=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM902
LTDIE_49:

	.byte 5
	.asciz "_KeyCollection"

	.byte 24,16
LDIFF_SYM903=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM903
	.byte 2,35,0,6
	.asciz "_dictionary"

LDIFF_SYM904=LTDIE_47_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM904
	.byte 2,35,16,0,7
	.asciz "_KeyCollection"

LDIFF_SYM905=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM905
LTDIE_49_POINTER:

	.byte 13
LDIFF_SYM906=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM906
LTDIE_49_REFERENCE:

	.byte 14
LDIFF_SYM907=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM907
LTDIE_50:

	.byte 5
	.asciz "_ValueCollection"

	.byte 24,16
LDIFF_SYM908=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM908
	.byte 2,35,0,6
	.asciz "_dictionary"

LDIFF_SYM909=LTDIE_47_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM909
	.byte 2,35,16,0,7
	.asciz "_ValueCollection"

LDIFF_SYM910=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM910
LTDIE_50_POINTER:

	.byte 13
LDIFF_SYM911=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM911
LTDIE_50_REFERENCE:

	.byte 14
LDIFF_SYM912=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM912
LTDIE_47:

	.byte 5
	.asciz "System_Collections_Generic_Dictionary`2"

	.byte 72,16
LDIFF_SYM913=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM913
	.byte 2,35,0,6
	.asciz "_buckets"

LDIFF_SYM914=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM914
	.byte 2,35,16,6
	.asciz "_entries"

LDIFF_SYM915=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM915
	.byte 2,35,24,6
	.asciz "_count"

LDIFF_SYM916=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM916
	.byte 2,35,56,6
	.asciz "_freeList"

LDIFF_SYM917=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM917
	.byte 2,35,60,6
	.asciz "_freeCount"

LDIFF_SYM918=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM918
	.byte 2,35,64,6
	.asciz "_version"

LDIFF_SYM919=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM919
	.byte 2,35,68,6
	.asciz "_comparer"

LDIFF_SYM920=LTDIE_48_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM920
	.byte 2,35,32,6
	.asciz "_keys"

LDIFF_SYM921=LTDIE_49_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM921
	.byte 2,35,40,6
	.asciz "_values"

LDIFF_SYM922=LTDIE_50_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM922
	.byte 2,35,48,0,7
	.asciz "System_Collections_Generic_Dictionary`2"

LDIFF_SYM923=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM923
LTDIE_47_POINTER:

	.byte 13
LDIFF_SYM924=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM924
LTDIE_47_REFERENCE:

	.byte 14
LDIFF_SYM925=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM925
LTDIE_51:

	.byte 17
	.asciz "System_Runtime_Serialization_IFormatterConverter"

	.byte 16,7
	.asciz "System_Runtime_Serialization_IFormatterConverter"

LDIFF_SYM926=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM926
LTDIE_51_POINTER:

	.byte 13
LDIFF_SYM927=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM927
LTDIE_51_REFERENCE:

	.byte 14
LDIFF_SYM928=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM928
LTDIE_46:

	.byte 5
	.asciz "System_Runtime_Serialization_SerializationInfo"

	.byte 88,16
LDIFF_SYM929=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM929
	.byte 2,35,0,6
	.asciz "m_members"

LDIFF_SYM930=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM930
	.byte 2,35,16,6
	.asciz "m_data"

LDIFF_SYM931=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM931
	.byte 2,35,24,6
	.asciz "m_types"

LDIFF_SYM932=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM932
	.byte 2,35,32,6
	.asciz "m_nameToIndex"

LDIFF_SYM933=LTDIE_47_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM933
	.byte 2,35,40,6
	.asciz "m_currMember"

LDIFF_SYM934=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM934
	.byte 2,35,80,6
	.asciz "m_converter"

LDIFF_SYM935=LTDIE_51_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM935
	.byte 2,35,48,6
	.asciz "m_fullTypeName"

LDIFF_SYM936=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM936
	.byte 2,35,56,6
	.asciz "m_assemName"

LDIFF_SYM937=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM937
	.byte 2,35,64,6
	.asciz "objectType"

LDIFF_SYM938=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM938
	.byte 2,35,72,6
	.asciz "isFullTypeNameSetExplicit"

LDIFF_SYM939=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM939
	.byte 2,35,84,6
	.asciz "isAssemblyNameSetExplicit"

LDIFF_SYM940=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM940
	.byte 2,35,85,6
	.asciz "requireSameTokenInPartialTrust"

LDIFF_SYM941=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM941
	.byte 2,35,86,0,7
	.asciz "System_Runtime_Serialization_SerializationInfo"

LDIFF_SYM942=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM942
LTDIE_46_POINTER:

	.byte 13
LDIFF_SYM943=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM943
LTDIE_46_REFERENCE:

	.byte 14
LDIFF_SYM944=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM944
LTDIE_53:

	.byte 5
	.asciz "System_Reflection_TypeInfo"

	.byte 24,16
LDIFF_SYM945=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM945
	.byte 2,35,0,0,7
	.asciz "System_Reflection_TypeInfo"

LDIFF_SYM946=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM946
LTDIE_53_POINTER:

	.byte 13
LDIFF_SYM947=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM947
LTDIE_53_REFERENCE:

	.byte 14
LDIFF_SYM948=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM948
LTDIE_57:

	.byte 5
	.asciz "System_Reflection_ConstructorInfo"

	.byte 16,16
LDIFF_SYM949=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM949
	.byte 2,35,0,0,7
	.asciz "System_Reflection_ConstructorInfo"

LDIFF_SYM950=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM950
LTDIE_57_POINTER:

	.byte 13
LDIFF_SYM951=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM951
LTDIE_57_REFERENCE:

	.byte 14
LDIFF_SYM952=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM952
LTDIE_56:

	.byte 5
	.asciz "System_Reflection_RuntimeConstructorInfo"

	.byte 16,16
LDIFF_SYM953=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM953
	.byte 2,35,0,0,7
	.asciz "System_Reflection_RuntimeConstructorInfo"

LDIFF_SYM954=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM954
LTDIE_56_POINTER:

	.byte 13
LDIFF_SYM955=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM955
LTDIE_56_REFERENCE:

	.byte 14
LDIFF_SYM956=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM956
LTDIE_55:

	.byte 5
	.asciz "System_Reflection_MonoCMethod"

	.byte 40,16
LDIFF_SYM957=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM957
	.byte 2,35,0,6
	.asciz "mhandle"

LDIFF_SYM958=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM958
	.byte 2,35,16,6
	.asciz "name"

LDIFF_SYM959=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM959
	.byte 2,35,24,6
	.asciz "reftype"

LDIFF_SYM960=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM960
	.byte 2,35,32,0,7
	.asciz "System_Reflection_MonoCMethod"

LDIFF_SYM961=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM961
LTDIE_55_POINTER:

	.byte 13
LDIFF_SYM962=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM962
LTDIE_55_REFERENCE:

	.byte 14
LDIFF_SYM963=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM963
LTDIE_54:

	.byte 5
	.asciz "System_MonoTypeInfo"

	.byte 32,16
LDIFF_SYM964=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM964
	.byte 2,35,0,6
	.asciz "full_name"

LDIFF_SYM965=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM965
	.byte 2,35,16,6
	.asciz "default_ctor"

LDIFF_SYM966=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM966
	.byte 2,35,24,0,7
	.asciz "System_MonoTypeInfo"

LDIFF_SYM967=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM967
LTDIE_54_POINTER:

	.byte 13
LDIFF_SYM968=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM968
LTDIE_54_REFERENCE:

	.byte 14
LDIFF_SYM969=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM969
LTDIE_52:

	.byte 5
	.asciz "System_RuntimeType"

	.byte 48,16
LDIFF_SYM970=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM970
	.byte 2,35,0,6
	.asciz "type_info"

LDIFF_SYM971=LTDIE_54_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM971
	.byte 2,35,24,6
	.asciz "GenericCache"

LDIFF_SYM972=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM972
	.byte 2,35,32,6
	.asciz "m_serializationCtor"

LDIFF_SYM973=LTDIE_56_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM973
	.byte 2,35,40,0,7
	.asciz "System_RuntimeType"

LDIFF_SYM974=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM974
LTDIE_52_POINTER:

	.byte 13
LDIFF_SYM975=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM975
LTDIE_52_REFERENCE:

	.byte 14
LDIFF_SYM976=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM976
LTDIE_58:

	.byte 5
	.asciz "System_EventHandler`1"

	.byte 112,16
LDIFF_SYM977=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM977
	.byte 2,35,0,0,7
	.asciz "System_EventHandler`1"

LDIFF_SYM978=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM978
LTDIE_58_POINTER:

	.byte 13
LDIFF_SYM979=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM979
LTDIE_58_REFERENCE:

	.byte 14
LDIFF_SYM980=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM980
LTDIE_44:

	.byte 5
	.asciz "System_Runtime_Serialization_SafeSerializationManager"

	.byte 56,16
LDIFF_SYM981=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM981
	.byte 2,35,0,6
	.asciz "m_serializedStates"

LDIFF_SYM982=LTDIE_45_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM982
	.byte 2,35,16,6
	.asciz "m_savedSerializationInfo"

LDIFF_SYM983=LTDIE_46_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM983
	.byte 2,35,24,6
	.asciz "m_realObject"

LDIFF_SYM984=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM984
	.byte 2,35,32,6
	.asciz "m_realType"

LDIFF_SYM985=LTDIE_52_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM985
	.byte 2,35,40,6
	.asciz "SerializeObjectState"

LDIFF_SYM986=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM986
	.byte 2,35,48,0,7
	.asciz "System_Runtime_Serialization_SafeSerializationManager"

LDIFF_SYM987=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM987
LTDIE_44_POINTER:

	.byte 13
LDIFF_SYM988=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM988
LTDIE_44_REFERENCE:

	.byte 14
LDIFF_SYM989=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM989
LTDIE_42:

	.byte 5
	.asciz "System_Exception"

	.byte 136,1,16
LDIFF_SYM990=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM990
	.byte 2,35,0,6
	.asciz "_className"

LDIFF_SYM991=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM991
	.byte 2,35,16,6
	.asciz "_message"

LDIFF_SYM992=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM992
	.byte 2,35,24,6
	.asciz "_data"

LDIFF_SYM993=LTDIE_43_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM993
	.byte 2,35,32,6
	.asciz "_innerException"

LDIFF_SYM994=LTDIE_42_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM994
	.byte 2,35,40,6
	.asciz "_helpURL"

LDIFF_SYM995=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM995
	.byte 2,35,48,6
	.asciz "_stackTrace"

LDIFF_SYM996=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM996
	.byte 2,35,56,6
	.asciz "_stackTraceString"

LDIFF_SYM997=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM997
	.byte 2,35,64,6
	.asciz "_remoteStackTraceString"

LDIFF_SYM998=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM998
	.byte 2,35,72,6
	.asciz "_remoteStackIndex"

LDIFF_SYM999=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM999
	.byte 2,35,80,6
	.asciz "_dynamicMethods"

LDIFF_SYM1000=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM1000
	.byte 2,35,88,6
	.asciz "_HResult"

LDIFF_SYM1001=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1001
	.byte 2,35,96,6
	.asciz "_source"

LDIFF_SYM1002=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM1002
	.byte 2,35,104,6
	.asciz "_safeSerializationManager"

LDIFF_SYM1003=LTDIE_44_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1003
	.byte 2,35,112,6
	.asciz "captured_traces"

LDIFF_SYM1004=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1004
	.byte 2,35,120,6
	.asciz "native_trace_ips"

LDIFF_SYM1005=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM1005
	.byte 3,35,128,1,0,7
	.asciz "System_Exception"

LDIFF_SYM1006=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1006
LTDIE_42_POINTER:

	.byte 13
LDIFF_SYM1007=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1007
LTDIE_42_REFERENCE:

	.byte 14
LDIFF_SYM1008=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM1008
	.byte 2
	.asciz "(wrapper_native-to-managed)_ObjCRuntime.Trampolines/SDMSLogHandler:Invoke"
	.asciz "wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint"

	.byte 0,0
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
	.quad Lme_ab

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM1009=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1009
	.byte 2,141,40,3
	.asciz "param1"

LDIFF_SYM1010=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1010
	.byte 2,141,48,3
	.asciz "param2"

LDIFF_SYM1011=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM1011
	.byte 2,141,56,3
	.asciz "param3"

LDIFF_SYM1012=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1012
	.byte 3,141,192,0,3
	.asciz "param4"

LDIFF_SYM1013=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1013
	.byte 3,141,200,0,3
	.asciz "param5"

LDIFF_SYM1014=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM1014
	.byte 3,141,208,0,11
	.asciz "V_0"

LDIFF_SYM1015=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1015
	.byte 3,141,240,0,11
	.asciz "V_1"

LDIFF_SYM1016=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1016
	.byte 3,141,248,0,11
	.asciz "V_2"

LDIFF_SYM1017=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1017
	.byte 3,141,128,1,11
	.asciz "V_3"

LDIFF_SYM1018=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM1018
	.byte 3,141,136,1,11
	.asciz "V_4"

LDIFF_SYM1019=LTDIE_42_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1019
	.byte 3,141,144,1,11
	.asciz "V_5"

LDIFF_SYM1020=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1020
	.byte 3,141,152,1,11
	.asciz "V_6"

LDIFF_SYM1021=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1021
	.byte 3,141,160,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM1022=Lfde135_end - Lfde135_start
	.long LDIFF_SYM1022
Lfde135_start:

	.long 0
	.align 3
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint

LDIFF_SYM1023=Lme_ab - wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogHandler_Invoke_intptr_intptr_System_nuint_intptr_intptr_uint
	.long LDIFF_SYM1023
	.long 0
	.byte 12,31,0,68,14,192,1,157,24,158,23,68,13,29,68,151,22,152,21,68,154,20
	.align 3
Lfde135_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper_native-to-managed)_ObjCRuntime.Trampolines/SDMSLogMessageProvider:Invoke"
	.asciz "wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr"

	.byte 0,0
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
	.quad Lme_ac

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM1024=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1024
	.byte 2,141,48,11
	.asciz "V_0"

LDIFF_SYM1025=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1025
	.byte 3,141,208,0,11
	.asciz "V_1"

LDIFF_SYM1026=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1026
	.byte 3,141,216,0,11
	.asciz "V_2"

LDIFF_SYM1027=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM1027
	.byte 3,141,224,0,11
	.asciz "V_3"

LDIFF_SYM1028=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1028
	.byte 1,104,11
	.asciz "V_4"

LDIFF_SYM1029=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM1029
	.byte 3,141,232,0,11
	.asciz "V_5"

LDIFF_SYM1030=LTDIE_42_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM1030
	.byte 3,141,240,0,11
	.asciz "V_6"

LDIFF_SYM1031=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1031
	.byte 3,141,248,0,11
	.asciz "V_7"

LDIFF_SYM1032=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM1032
	.byte 3,141,128,1,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM1033=Lfde136_end - Lfde136_start
	.long LDIFF_SYM1033
Lfde136_start:

	.long 0
	.align 3
	.quad wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr

LDIFF_SYM1034=Lme_ac - wrapper_native_to_managed_ObjCRuntime_Trampolines_SDMSLogMessageProvider_Invoke_intptr
	.long LDIFF_SYM1034
	.long 0
	.byte 12,31,0,68,14,160,1,157,20,158,19,68,13,29,68,147,18,148,17,68,150,16,68,152,15
	.align 3
Lfde136_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.text
	.align 3
mem_end:
