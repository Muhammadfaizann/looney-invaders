#define DEBUG 1
#include <xamarin/xamarin.h>
#include "registrar.h"
extern "C" {
static id native_to_managed_trampoline_1 (id self, SEL _cmd, MonoMethod **managed_method_ptr, bool* call_super, uint32_t token_ref)
{
	uint8_t flags = NSObjectFlagsNativeRef;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	bool has_nsobject = xamarin_has_nsobject (self, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	if (has_nsobject) {
		*call_super = true;
		goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	mthis = mono_object_new (mono_domain_get (), mono_method_get_class (managed_method));
	xamarin_set_nsobject_handle (mthis, self);
	xamarin_set_nsobject_flags (mthis, flags);
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);
	xamarin_create_managed_ref (self, mthis, true);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return self;
}


static void native_to_managed_trampoline_2 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_3 (id self, SEL _cmd, MonoMethod **managed_method_ptr, void * p0, uint32_t token_ref)
{
	void * a0 = p0;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = &a0;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_4 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSNotification * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_5 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSTimer * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_6 (id self, SEL _cmd, MonoMethod **managed_method_ptr, SKPaymentQueue * p0, NSArray * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	if (p1) {
		NSArray *arr = (NSArray *) p1;
		xamarin_check_objc_type (p1, [NSArray class], _cmd, self, 1, managed_method);
		MonoClass *e_class;
		MonoArray *marr;
		MonoType *p;
		int j;
		p = xamarin_get_parameter_type (managed_method, 1);
		e_class = mono_class_get_element_class (mono_class_from_mono_type (p));
		marr = mono_array_new (mono_domain_get (), e_class, [arr count]);
		for (j = 0; j < [arr count]; j++) {
			NSObject *nobj = [arr objectAtIndex: j];
			MonoObject *mobj1 = NULL;
			if (nobj) {
				mobj1 = xamarin_get_managed_object_for_ptr_fast (nobj, &exception_gchandle);
				if (exception_gchandle != 0) goto exception_handling;
				xamarin_verify_parameter (mobj1, _cmd, self, nobj, 1, e_class, managed_method);
			}
			mono_array_set (marr, MonoObject *, j, mobj1);
		}
		arg_ptrs [1] = marr;
	} else {
		arg_ptrs [1] = NULL;
	}

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static UIWindow * native_to_managed_trampoline_7 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	UIWindow * res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	if (!retval) {
		res = NULL;
	} else {
		id retobj;
		retobj = xamarin_get_nsobject_handle (retval);
		xamarin_framework_peer_lock ();
		[retobj retain];
		xamarin_framework_peer_unlock ();
		[retobj autorelease];
		mt_dummy_use (retval);
		res = retobj;
	}

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_8 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIWindow * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_9 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIApplication * p0, NSDictionary * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_10 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIApplication * p0, NSData * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_11 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIApplication * p0, NSError * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_12 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIApplication * p0, NSDictionary * p1, id p2, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [3];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;
	if (p2) {
		arg_ptrs [2] = (void *) xamarin_get_delegate_for_block_parameter (managed_method, 0x28704 /* System.Action`1<UIKit.UIBackgroundFetchResult> ObjCRuntime.Trampolines/NIDActionArity1V14::Create(System.IntPtr) */ , 2, p2, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	} else {
		arg_ptrs [2] = NULL;
	}

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_13 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIApplication * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static id native_to_managed_trampoline_14 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	id res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	if (!retval) {
		res = NULL;
	} else {
		id retobj;
		retobj = xamarin_get_nsobject_handle (retval);
		xamarin_framework_peer_lock ();
		[retobj retain];
		xamarin_framework_peer_unlock ();
		[retobj autorelease];
		mt_dummy_use (retval);
		res = retobj;
	}

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_15 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_16 (id self, SEL _cmd, MonoMethod **managed_method_ptr, BOOL p0, uint32_t token_ref)
{
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = &p0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_17 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIAlertView * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_18 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIAlertView * p0, NSInteger p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	arg_ptrs [1] = &p1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_19 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UIAlertView * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_20 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSObject * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, NULL, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static Class native_to_managed_trampoline_21 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	Class res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	retval = mono_runtime_invoke (managed_method, NULL, arg_ptrs, NULL);

	if (!retval) {
		res = NULL;
	} else {
		res = (Class) xamarin_get_handle_for_inativeobject (retval, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static id native_to_managed_trampoline_22 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSCoder * p0, bool* call_super, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	uint8_t flags = NSObjectFlagsNativeRef;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	bool has_nsobject = xamarin_has_nsobject (self, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	if (has_nsobject) {
		*call_super = true;
		goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mthis = mono_object_new (mono_domain_get (), mono_method_get_class (managed_method));
	xamarin_set_nsobject_handle (mthis, self);
	xamarin_set_nsobject_flags (mthis, flags);
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);
	xamarin_create_managed_ref (self, mthis, true);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return self;
}


static id native_to_managed_trampoline_23 (id self, SEL _cmd, MonoMethod **managed_method_ptr, CGRect p0, bool* call_super, uint32_t token_ref)
{
	uint8_t flags = NSObjectFlagsNativeRef;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	bool has_nsobject = xamarin_has_nsobject (self, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	if (has_nsobject) {
		*call_super = true;
		goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	arg_ptrs [0] = &p0;

	mthis = mono_object_new (mono_domain_get (), mono_method_get_class (managed_method));
	xamarin_set_nsobject_handle (mthis, self);
	xamarin_set_nsobject_flags (mthis, flags);
	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);
	xamarin_create_managed_ref (self, mthis, true);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return self;
}


static void native_to_managed_trampoline_24 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSSet * p0, UIEvent * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_25 (id self, SEL _cmd, MonoMethod **managed_method_ptr, UITextField * p0, NSRange p1, NSString * p2, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [3];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	arg_ptrs [1] = &p1;
	arg_ptrs [2] = p2 ? mono_string_new (mono_domain_get (), [p2 UTF8String]) : NULL;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_26 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSString * p0, uint32_t token_ref)
{
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = p0 ? mono_string_new (mono_domain_get (), [p0 UTF8String]) : NULL;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_27 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSInteger p0, uint32_t token_ref)
{
	long long nativeEnum0 = p0;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = &nativeEnum0;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static NSUInteger native_to_managed_trampoline_28 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	NSUInteger res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(NSUInteger *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static BOOL native_to_managed_trampoline_29 (id self, SEL _cmd, MonoMethod **managed_method_ptr, uint32_t token_ref)
{
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [0];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_30 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSInteger p0, uint32_t token_ref)
{
	long long nativeEnum0 = p0;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = &nativeEnum0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_31 (id self, SEL _cmd, MonoMethod **managed_method_ptr, CGSize p0, id p1, uint32_t token_ref)
{
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	arg_ptrs [0] = &p0;
	arg_ptrs [1] = xamarin_get_inative_object_static (p1, false, "UIKit.UIViewControllerTransitionCoordinatorWrapper, Xamarin.iOS", "UIKit.IUIViewControllerTransitionCoordinator, Xamarin.iOS", &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_32 (id self, SEL _cmd, MonoMethod **managed_method_ptr, NSObject * p0, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [1];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_33 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, NSError * p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_34 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, id p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static void native_to_managed_trampoline_35 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, struct trampoline_struct_ddi p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	arg_ptrs [1] = &p1;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}


static BOOL native_to_managed_trampoline_36 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, id p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	BOOL res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	res = *(BOOL *) mono_object_unbox ((MonoObject *) retval);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static NSArray * native_to_managed_trampoline_37 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, id p1, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	MonoObject *retval = NULL;
	guint32 exception_gchandle = 0;
	NSArray * res = {0};
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [2];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;

	retval = mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

	if (!retval) {
		res = NULL;
	} else {
		id retobj;
		retobj = xamarin_get_nsobject_handle (retval);
		xamarin_framework_peer_lock ();
		[retobj retain];
		xamarin_framework_peer_unlock ();
		[retobj autorelease];
		mt_dummy_use (retval);
		res = retobj;
	}

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return res;
}


static void native_to_managed_trampoline_38 (id self, SEL _cmd, MonoMethod **managed_method_ptr, id p0, id p1, NSError * p2, uint32_t token_ref)
{
	NSObject *nsobj0 = NULL;
	MonoObject *mobj0 = NULL;
	int32_t created0 = false;
	MonoType *paramtype0 = NULL;
	NSObject *nsobj1 = NULL;
	MonoObject *mobj1 = NULL;
	int32_t created1 = false;
	MonoType *paramtype1 = NULL;
	NSObject *nsobj2 = NULL;
	MonoObject *mobj2 = NULL;
	int32_t created2 = false;
	MonoType *paramtype2 = NULL;
	guint32 exception_gchandle = 0;
	MonoMethod *managed_method = *managed_method_ptr;
	void *arg_ptrs [3];
	MONO_ASSERT_GC_SAFE;
	MONO_THREAD_ATTACH;

	MonoObject *mthis = NULL;
	if (self) {
		mthis = xamarin_get_managed_object_for_ptr_fast (self, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
	}
	if (!managed_method) {
		MonoReflectionMethod *reflection_method = xamarin_get_method_from_token (token_ref, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		managed_method = xamarin_get_reflection_method_method (reflection_method);
		*managed_method_ptr = managed_method;
	}
	xamarin_check_for_gced_object (mthis, _cmd, self, managed_method, &exception_gchandle);
	if (exception_gchandle != 0) goto exception_handling;
	nsobj0 = (NSObject *) p0;
	if (nsobj0) {
		paramtype0 = xamarin_get_parameter_type (managed_method, 0);
		mobj0 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj0, false, paramtype0, &created0, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj0, _cmd, self, nsobj0, 0, mono_class_from_mono_type (paramtype0), managed_method);
	}
	arg_ptrs [0] = mobj0;
	nsobj1 = (NSObject *) p1;
	if (nsobj1) {
		paramtype1 = xamarin_get_parameter_type (managed_method, 1);
		mobj1 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj1, false, paramtype1, &created1, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj1, _cmd, self, nsobj1, 1, mono_class_from_mono_type (paramtype1), managed_method);
	}
	arg_ptrs [1] = mobj1;
	nsobj2 = (NSObject *) p2;
	if (nsobj2) {
		paramtype2 = xamarin_get_parameter_type (managed_method, 2);
		mobj2 = xamarin_get_nsobject_with_type_for_ptr_created (nsobj2, false, paramtype2, &created2, _cmd, managed_method, &exception_gchandle);
		if (exception_gchandle != 0) goto exception_handling;
		xamarin_verify_parameter (mobj2, _cmd, self, nsobj2, 2, mono_class_from_mono_type (paramtype2), managed_method);
	}
	arg_ptrs [2] = mobj2;

	mono_runtime_invoke (managed_method, mthis, arg_ptrs, NULL);

exception_handling:;
	MONO_THREAD_DETACH;
	if (exception_gchandle != 0)
		xamarin_process_managed_exception_gchandle (exception_gchandle);
	return;
}




#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation SKPaymentTransactionObserver {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2B104);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation UIApplicationDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x5ED04);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop

@interface UIKit_UIControlEventProxy : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) BridgeSelector;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation UIKit_UIControlEventProxy {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) BridgeSelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x50904);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation UITextFieldDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x64504);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop

@interface Foundation_InternalNSNotificationHandler : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) post:(NSNotification *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation Foundation_InternalNSNotificationHandler {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) post:(NSNotification *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_4 (self, _cmd, &managed_method, p0, 0x76B04);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface Foundation_NSDispatcher : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) xamarinApplySelector;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Foundation_NSDispatcher {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x7F804);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x7F704);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@interface __MonoMac_NSActionDispatcher : Foundation_NSDispatcher {
}
	-(void) xamarinApplySelector;
@end

@implementation __MonoMac_NSActionDispatcher {
}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x7FB04);
	}
@end

@interface __MonoMac_NSSynchronizationContextDispatcher : Foundation_NSDispatcher {
}
	-(void) xamarinApplySelector;
@end

@implementation __MonoMac_NSSynchronizationContextDispatcher {
}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x7FD04);
	}
@end

@interface __Xamarin_NSTimerActionDispatcher : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) xamarinFireSelector:(NSTimer *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation __Xamarin_NSTimerActionDispatcher {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) xamarinFireSelector:(NSTimer *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_5 (self, _cmd, &managed_method, p0, 0x7FF04);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface Foundation_NSAsyncDispatcher : Foundation_NSDispatcher {
}
	-(void) xamarinApplySelector;
	-(id) init;
@end

@implementation Foundation_NSAsyncDispatcher {
}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x80204);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x80104);
		if (call_super && rv) {
			struct objc_super super = {  rv, [Foundation_NSDispatcher class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@interface __MonoMac_NSAsyncActionDispatcher : Foundation_NSAsyncDispatcher {
}
	-(void) xamarinApplySelector;
@end

@implementation __MonoMac_NSAsyncActionDispatcher {
}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x80404);
	}
@end

@interface __MonoMac_NSAsyncSynchronizationContextDispatcher : Foundation_NSAsyncDispatcher {
}
	-(void) xamarinApplySelector;
@end

@implementation __MonoMac_NSAsyncSynchronizationContextDispatcher {
}

	-(void) xamarinApplySelector
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x80604);
	}
@end

@interface CC_Mobile_Purchases_CustomPaymentObserver : NSObject<SKPaymentTransactionObserver> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) paymentQueue:(SKPaymentQueue *)p0 updatedTransactions:(NSArray *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation CC_Mobile_Purchases_CustomPaymentObserver {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) paymentQueue:(SKPaymentQueue *)p0 updatedTransactions:(NSArray *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_6 (self, _cmd, &managed_method, p0, p1, 0x300);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x400);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation AppDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(UIWindow *) window
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_7 (self, _cmd, &managed_method, 0x31E00);
	}

	-(void) setWindow:(UIWindow *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_8 (self, _cmd, &managed_method, p0, 0x31F00);
	}

	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_9 (self, _cmd, &managed_method, p0, p1, 0x32000);
	}

	-(void) application:(UIApplication *)p0 didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_10 (self, _cmd, &managed_method, p0, p1, 0x32100);
	}

	-(void) application:(UIApplication *)p0 didFailToRegisterForRemoteNotificationsWithError:(NSError *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_11 (self, _cmd, &managed_method, p0, p1, 0x32200);
	}

	-(void) application:(UIApplication *)p0 didReceiveRemoteNotification:(NSDictionary *)p1 fetchCompletionHandler:(id)p2
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_12 (self, _cmd, &managed_method, p0, p1, p2, 0x32300);
	}

	-(void) applicationWillResignActive:(UIApplication *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_13 (self, _cmd, &managed_method, p0, 0x32400);
	}

	-(void) applicationDidEnterBackground:(UIApplication *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_13 (self, _cmd, &managed_method, p0, 0x32500);
	}

	-(void) applicationWillEnterForeground:(UIApplication *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_13 (self, _cmd, &managed_method, p0, 0x32600);
	}

	-(void) applicationDidBecomeActive:(UIApplication *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_13 (self, _cmd, &managed_method, p0, 0x32700);
	}

	-(void) applicationWillTerminate:(UIApplication *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_13 (self, _cmd, &managed_method, p0, 0x32800);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x32C00);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation ViewController {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(id) GameView
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_14 (self, _cmd, &managed_method, 0x35100);
	}

	-(void) setGameView:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x35200);
	}

	-(void) viewDidLoad
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x33000);
	}

	-(void) viewWillDisappear:(BOOL)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_16 (self, _cmd, &managed_method, p0, 0x33600);
	}

	-(void) viewDidAppear:(BOOL)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_16 (self, _cmd, &managed_method, p0, 0x33700);
	}

	-(void) didReceiveMemoryWarning
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x33800);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface UIKit_UIAlertView__UIAlertViewDelegate : NSObject<UIAlertViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) alertViewCancel:(UIAlertView *)p0;
	-(void) alertView:(UIAlertView *)p0 clickedButtonAtIndex:(NSInteger)p1;
	-(void) alertView:(UIAlertView *)p0 didDismissWithButtonIndex:(NSInteger)p1;
	-(void) didPresentAlertView:(UIAlertView *)p0;
	-(BOOL) alertViewShouldEnableFirstOtherButton:(UIAlertView *)p0;
	-(void) alertView:(UIAlertView *)p0 willDismissWithButtonIndex:(NSInteger)p1;
	-(void) willPresentAlertView:(UIAlertView *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation UIKit_UIAlertView__UIAlertViewDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) alertViewCancel:(UIAlertView *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_17 (self, _cmd, &managed_method, p0, 0x4D504);
	}

	-(void) alertView:(UIAlertView *)p0 clickedButtonAtIndex:(NSInteger)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_18 (self, _cmd, &managed_method, p0, p1, 0x4D604);
	}

	-(void) alertView:(UIAlertView *)p0 didDismissWithButtonIndex:(NSInteger)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_18 (self, _cmd, &managed_method, p0, p1, 0x4D704);
	}

	-(void) didPresentAlertView:(UIAlertView *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_17 (self, _cmd, &managed_method, p0, 0x4D804);
	}

	-(BOOL) alertViewShouldEnableFirstOtherButton:(UIAlertView *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_19 (self, _cmd, &managed_method, p0, 0x4D904);
	}

	-(void) alertView:(UIAlertView *)p0 willDismissWithButtonIndex:(NSInteger)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_18 (self, _cmd, &managed_method, p0, p1, 0x4DA04);
	}

	-(void) willPresentAlertView:(UIAlertView *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_17 (self, _cmd, &managed_method, p0, 0x4DB04);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@implementation UIKit_UIView_UIViewAppearance {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface __NSObject_Disposer : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	+(void) drain:(NSObject *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation __NSObject_Disposer {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	+(void) drain:(NSObject *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_20 (self, _cmd, &managed_method, p0, 0x87C04);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x87A04);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation OpenTK_Platform_iPhoneOS_iPhoneOSGameView {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	+(Class) layerClass
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_21 (self, _cmd, &managed_method, 0x20214);
	}

	-(void) layoutSubviews
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x23E14);
	}

	-(void) willMoveToWindow:(UIWindow *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_8 (self, _cmd, &managed_method, p0, 0x24A14);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) initWithCoder:(NSCoder *)p0
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_22 (self, _cmd, &managed_method, p0, &call_super, 0x20014);
		if (call_super && rv) {
			struct objc_super super = {  rv, [UIView class] };
			rv = ((id (*)(objc_super*, SEL, NSCoder *)) objc_msgSendSuper) (&super, @selector (initWithCoder:), p0);
		}
		return rv;
	}

	-(id) initWithFrame:(CGRect)p0
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_23 (self, _cmd, &managed_method, p0, &call_super, 0x20114);
		if (call_super && rv) {
			struct objc_super super = {  rv, [UIView class] };
			rv = ((id (*)(objc_super*, SEL, CGRect)) objc_msgSendSuper) (&super, @selector (initWithFrame:), p0);
		}
		return rv;
	}
@end

@implementation CCGameView {
}

	-(void) layoutSubviews
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x30B0E);
	}

	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x3170E);
	}

	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x3180E);
	}

	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x3190E);
	}

	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x31A0E);
	}

	-(id) initWithCoder:(NSCoder *)p0
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_22 (self, _cmd, &managed_method, p0, &call_super, 0x3030E);
		if (call_super && rv) {
			struct objc_super super = {  rv, [OpenTK_Platform_iPhoneOS_iPhoneOSGameView class] };
			rv = ((id (*)(objc_super*, SEL, NSCoder *)) objc_msgSendSuper) (&super, @selector (initWithCoder:), p0);
		}
		return rv;
	}
@end

@implementation CocosSharp_IMEKeyboardImpl_HiddenInputDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(BOOL) textField:(UITextField *)p0 shouldChangeCharactersInRange:(NSRange)p1 replacementString:(NSString *)p2
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_25 (self, _cmd, &managed_method, p0, p1, p2, 0x3600E);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x3610E);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@interface CocosSharp_IMEKeyboardImpl_HiddenInput : UITextField {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) insertText:(NSString *)p0;
	-(void) deleteBackward;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation CocosSharp_IMEKeyboardImpl_HiddenInput {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) insertText:(NSString *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_26 (self, _cmd, &managed_method, p0, 0x3690E);
	}

	-(void) deleteBackward
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x36A0E);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface Microsoft_Xna_Framework_iOSGameViewController : UIViewController {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) loadView;
	-(BOOL) shouldAutorotateToInterfaceOrientation:(NSInteger)p0;
	-(NSUInteger) supportedInterfaceOrientations;
	-(BOOL) shouldAutorotate;
	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0;
	-(BOOL) prefersStatusBarHidden;
	-(void) viewWillTransitionToSize:(CGSize)p0 withTransitionCoordinator:(id)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation Microsoft_Xna_Framework_iOSGameViewController {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) loadView
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x71E10);
	}

	-(BOOL) shouldAutorotateToInterfaceOrientation:(NSInteger)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_27 (self, _cmd, &managed_method, p0, 0x72010);
	}

	-(NSUInteger) supportedInterfaceOrientations
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_28 (self, _cmd, &managed_method, 0x72110);
	}

	-(BOOL) shouldAutorotate
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_29 (self, _cmd, &managed_method, 0x72210);
	}

	-(void) didRotateFromInterfaceOrientation:(NSInteger)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_30 (self, _cmd, &managed_method, p0, 0x72310);
	}

	-(BOOL) prefersStatusBarHidden
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_29 (self, _cmd, &managed_method, 0x72410);
	}

	-(void) viewWillTransitionToSize:(CGSize)p0 withTransitionCoordinator:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_31 (self, _cmd, &managed_method, p0, p1, 0x72510);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface iOSGameView : UIView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	+(Class) layerClass;
	-(BOOL) canBecomeFirstResponder;
	-(void) doTick;
	-(void) layoutSubviews;
	-(void) didMoveToWindow;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation iOSGameView {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	+(Class) layerClass
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_21 (self, _cmd, &managed_method, 0x72F10);
	}

	-(BOOL) canBecomeFirstResponder
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_29 (self, _cmd, &managed_method, 0x73010);
	}

	-(void) doTick
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x73410);
	}

	-(void) layoutSubviews
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x73910);
	}

	-(void) didMoveToWindow
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x73A10);
	}

	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x73E10);
	}

	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x73F10);
	}

	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x74010);
	}

	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_24 (self, _cmd, &managed_method, p0, p1, 0x74110);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end

@interface OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) runIteration:(NSObject *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@implementation OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) runIteration:(NSObject *)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_32 (self, _cmd, &managed_method, p0, 0x1FA14);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}
@end







#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADAdLoaderDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0xDE16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADAdNetworkExtras {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0xE916);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADAdSizeDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0xF616);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADAppEventDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0xFB16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADAudioVideoManagerDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x11916);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADBannerViewDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x16316);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop





#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADCustomEventBannerDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x19916);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop




#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADCustomEventInterstitialDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1C016);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADCustomEventNativeAd {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1D516);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADCustomEventNativeAdDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1E216);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop




#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADDebugOptionsViewControllerDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x20216);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADDefaultInAppPurchaseDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x21416);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop





#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADInAppPurchaseDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x27D16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADInterstitialDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2AB16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation Google_MobileAds_MediatedNativeAd {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2BA16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADMediatedNativeAdDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2C016);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADMediatedNativeAppInstallAd {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2E716);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADMediatedNativeContentAd {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x30616);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop





#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADNativeAdDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x34F16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop






#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADNativeAppInstallAdLoaderDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x38816);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADNativeContentAdLoaderDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x3C716);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADNativeCustomTemplateAdLoaderDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x3F516);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADNativeExpressAdViewDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x43216);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADRewardBasedVideoAdDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x44216);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADSwipeableBannerViewDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x48116);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation GADVideoControllerDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x4A716);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation DFPBannerAdLoaderDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x4EF16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop




#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation DFPCustomRenderedBannerViewDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x50F16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation DFPCustomRenderedInterstitialDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x51616);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop


@interface Google_MobileAds_RewardBasedVideoAd__RewardBasedVideoAdDelegate : NSObject<GADRewardBasedVideoAdDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) rewardBasedVideoAdDidClose:(id)p0;
	-(void) rewardBasedVideoAd:(id)p0 didFailToLoadWithError:(NSError *)p1;
	-(void) rewardBasedVideoAdDidOpen:(id)p0;
	-(void) rewardBasedVideoAdDidReceiveAd:(id)p0;
	-(void) rewardBasedVideoAd:(id)p0 didRewardUserWithReward:(id)p1;
	-(void) rewardBasedVideoAdDidStartPlaying:(id)p0;
	-(void) rewardBasedVideoAdWillLeaveApplication:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_RewardBasedVideoAd__RewardBasedVideoAdDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) rewardBasedVideoAdDidClose:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0xBB16);
	}

	-(void) rewardBasedVideoAd:(id)p0 didFailToLoadWithError:(NSError *)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_33 (self, _cmd, &managed_method, p0, p1, 0xBC16);
	}

	-(void) rewardBasedVideoAdDidOpen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0xBD16);
	}

	-(void) rewardBasedVideoAdDidReceiveAd:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0xBE16);
	}

	-(void) rewardBasedVideoAd:(id)p0 didRewardUserWithReward:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0xBF16);
	}

	-(void) rewardBasedVideoAdDidStartPlaying:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0xC016);
	}

	-(void) rewardBasedVideoAdWillLeaveApplication:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0xC116);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0xBA16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end


@implementation Google_MobileAds_AdChoicesView_AdChoicesViewAppearance {
}
@end


@interface Google_MobileAds_AudioVideoManager__AudioVideoManagerDelegate : NSObject<GADAudioVideoManagerDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) audioVideoManagerDidPauseAllVideo:(id)p0;
	-(void) audioVideoManagerDidStopPlayingAudio:(id)p0;
	-(void) audioVideoManagerWillPlayAudio:(id)p0;
	-(void) audioVideoManagerWillPlayVideo:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_AudioVideoManager__AudioVideoManagerDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) audioVideoManagerDidPauseAllVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x11416);
	}

	-(void) audioVideoManagerDidStopPlayingAudio:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x11516);
	}

	-(void) audioVideoManagerWillPlayAudio:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x11616);
	}

	-(void) audioVideoManagerWillPlayVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x11716);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x11316);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end


@interface Google_MobileAds_BannerView__BannerViewDelegate : NSObject<GADBannerViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) adViewDidDismissScreen:(id)p0;
	-(void) adView:(id)p0 didFailToReceiveAdWithError:(id)p1;
	-(void) adViewDidReceiveAd:(id)p0;
	-(void) adViewWillDismissScreen:(id)p0;
	-(void) adViewWillLeaveApplication:(id)p0;
	-(void) adViewWillPresentScreen:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_BannerView__BannerViewDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) adViewDidDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x15416);
	}

	-(void) adView:(id)p0 didFailToReceiveAdWithError:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x15516);
	}

	-(void) adViewDidReceiveAd:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x15616);
	}

	-(void) adViewWillDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x15716);
	}

	-(void) adViewWillLeaveApplication:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x15816);
	}

	-(void) adViewWillPresentScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x15916);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x15316);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@interface Google_MobileAds_BannerView__AdSizeDelegate : NSObject<GADAdSizeDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) adView:(id)p0 willChangeAdSizeTo:(struct trampoline_struct_ddi)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_BannerView__AdSizeDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) adView:(id)p0 willChangeAdSizeTo:(struct trampoline_struct_ddi)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_35 (self, _cmd, &managed_method, p0, p1, 0x15B16);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x15A16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation Google_MobileAds_BannerView_BannerViewAppearance {
}
@end


@interface Google_MobileAds_Interstitial__InterstitialDelegate : NSObject<GADInterstitialDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) interstitialDidDismissScreen:(id)p0;
	-(void) interstitialDidFailToPresentScreen:(id)p0;
	-(void) interstitial:(id)p0 didFailToReceiveAdWithError:(id)p1;
	-(void) interstitialDidReceiveAd:(id)p0;
	-(void) interstitialWillDismissScreen:(id)p0;
	-(void) interstitialWillLeaveApplication:(id)p0;
	-(void) interstitialWillPresentScreen:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_Interstitial__InterstitialDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) interstitialDidDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A116);
	}

	-(void) interstitialDidFailToPresentScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A216);
	}

	-(void) interstitial:(id)p0 didFailToReceiveAdWithError:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x2A316);
	}

	-(void) interstitialDidReceiveAd:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A416);
	}

	-(void) interstitialWillDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A516);
	}

	-(void) interstitialWillLeaveApplication:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A616);
	}

	-(void) interstitialWillPresentScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x2A716);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x2A016);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end


@interface Google_MobileAds_NativeAd__NativeAdDelegate : NSObject<GADNativeAdDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) nativeAdDidDismissScreen:(id)p0;
	-(void) nativeAdDidRecordClick:(id)p0;
	-(void) nativeAdDidRecordImpression:(id)p0;
	-(void) nativeAdWillDismissScreen:(id)p0;
	-(void) nativeAdWillLeaveApplication:(id)p0;
	-(void) nativeAdWillPresentScreen:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_NativeAd__NativeAdDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) nativeAdDidDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34816);
	}

	-(void) nativeAdDidRecordClick:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34916);
	}

	-(void) nativeAdDidRecordImpression:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34A16);
	}

	-(void) nativeAdWillDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34B16);
	}

	-(void) nativeAdWillLeaveApplication:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34C16);
	}

	-(void) nativeAdWillPresentScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x34D16);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x34716);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation Google_MobileAds_NativeAppInstallAdView_NativeAppInstallAdViewAppearance {
}
@end


@implementation Google_MobileAds_NativeContentAdView_NativeContentAdViewAppearance {
}
@end


@interface Google_MobileAds_NativeExpressAdView__NativeExpressAdViewDelegate : NSObject<GADNativeExpressAdViewDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) nativeExpressAdViewDidDismissScreen:(id)p0;
	-(void) nativeExpressAdView:(id)p0 didFailToReceiveAdWithError:(id)p1;
	-(void) nativeExpressAdViewDidReceiveAd:(id)p0;
	-(void) nativeExpressAdViewWillDismissScreen:(id)p0;
	-(void) nativeExpressAdViewWillLeaveApplication:(id)p0;
	-(void) nativeExpressAdViewWillPresentScreen:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_NativeExpressAdView__NativeExpressAdViewDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) nativeExpressAdViewDidDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x42816);
	}

	-(void) nativeExpressAdView:(id)p0 didFailToReceiveAdWithError:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x42916);
	}

	-(void) nativeExpressAdViewDidReceiveAd:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x42A16);
	}

	-(void) nativeExpressAdViewWillDismissScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x42B16);
	}

	-(void) nativeExpressAdViewWillLeaveApplication:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x42C16);
	}

	-(void) nativeExpressAdViewWillPresentScreen:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x42D16);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x42716);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation Google_MobileAds_NativeExpressAdView_NativeExpressAdViewAppearance {
}
@end


@implementation Google_MobileAds_SearchBannerView_SearchBannerViewAppearance {
}
@end


@interface Google_MobileAds_VideoController__VideoControllerDelegate : NSObject<GADVideoControllerDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) videoControllerDidEndVideoPlayback:(id)p0;
	-(void) videoControllerDidMuteVideo:(id)p0;
	-(void) videoControllerDidPauseVideo:(id)p0;
	-(void) videoControllerDidPlayVideo:(id)p0;
	-(void) videoControllerDidUnmuteVideo:(id)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_VideoController__VideoControllerDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) videoControllerDidEndVideoPlayback:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x4A116);
	}

	-(void) videoControllerDidMuteVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x4A216);
	}

	-(void) videoControllerDidPauseVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x4A316);
	}

	-(void) videoControllerDidPlayVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x4A416);
	}

	-(void) videoControllerDidUnmuteVideo:(id)p0
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_15 (self, _cmd, &managed_method, p0, 0x4A516);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x4A016);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end


@interface Google_MobileAds_DoubleClick_BannerView__AdSizeDelegate : NSObject<GADAdSizeDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) adView:(id)p0 willChangeAdSizeTo:(struct trampoline_struct_ddi)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_DoubleClick_BannerView__AdSizeDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) adView:(id)p0 willChangeAdSizeTo:(struct trampoline_struct_ddi)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_35 (self, _cmd, &managed_method, p0, p1, 0x4E716);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x4E616);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end

@implementation Google_MobileAds_DoubleClick_BannerView_BannerViewAppearance {
}
@end


@interface Google_MobileAds_DoubleClick_Interstitial__CustomRenderedInterstitialDelegate : NSObject<DFPCustomRenderedInterstitialDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) interstitial:(id)p0 didReceiveCustomRenderedAd:(id)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Google_MobileAds_DoubleClick_Interstitial__CustomRenderedInterstitialDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) interstitial:(id)p0 didReceiveCustomRenderedAd:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x52B16);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x52A16);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation MSPushDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1422);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop

@implementation Microsoft_AppCenter_Push_iOS_PushDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) push:(id)p0 didReceivePushNotification:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0xE20);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1120);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end




#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation MSCrashesDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x3326);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop

@interface Microsoft_AppCenter_Crashes_Crashes_CrashesDelegate : NSObject<MSCrashesDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) crashes:(id)p0 shouldProcessErrorReport:(id)p1;
	-(NSArray *) attachmentsWithCrashes:(id)p0 forErrorReport:(id)p1;
	-(void) crashes:(id)p0 willSendErrorReport:(id)p1;
	-(void) crashes:(id)p0 didSucceedSendingErrorReport:(id)p1;
	-(void) crashes:(id)p0 didFailSendingErrorReport:(id)p1 withError:(NSError *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@implementation Microsoft_AppCenter_Crashes_Crashes_CrashesDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(BOOL) crashes:(id)p0 shouldProcessErrorReport:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_36 (self, _cmd, &managed_method, p0, p1, 0x5524);
	}

	-(NSArray *) attachmentsWithCrashes:(id)p0 forErrorReport:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_37 (self, _cmd, &managed_method, p0, p1, 0x5624);
	}

	-(void) crashes:(id)p0 willSendErrorReport:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x5724);
	}

	-(void) crashes:(id)p0 didSucceedSendingErrorReport:(id)p1
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_34 (self, _cmd, &managed_method, p0, p1, 0x5824);
	}

	-(void) crashes:(id)p0 didFailSendingErrorReport:(id)p1 withError:(NSError *)p2
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_38 (self, _cmd, &managed_method, p0, p1, p2, 0x5924);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x5A24);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end



#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation MSCrashHandlerSetupDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x3C26);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop








@implementation Microsoft_AppCenter_Crashes_iOS_Bindings_CrashesInitializationDelegate {
	XamarinObject __monoObjectGCHandle;
}
	-(void) release
	{
		xamarin_release_trampoline (self, _cmd);
	}

	-(id) retain
	{
		return xamarin_retain_trampoline (self, _cmd);
	}

	-(int) xamarinGetGCHandle
	{
		return __monoObjectGCHandle.gc_handle;
	}

	-(void) xamarinSetGCHandle: (int) gc_handle
	{
		__monoObjectGCHandle.gc_handle = gc_handle;
		__monoObjectGCHandle.native_object = self;
	}


	-(void) willSetUpCrashHandlers
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x1F26);
	}

	-(void) didSetUpCrashHandlers
	{
		static MonoMethod *managed_method = NULL;
		native_to_managed_trampoline_2 (self, _cmd, &managed_method, 0x2026);
	}

	-(BOOL) shouldEnableUncaughtExceptionHandler
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_29 (self, _cmd, &managed_method, 0x2126);
	}

	-(BOOL) conformsToProtocol:(void *)p0
	{
		static MonoMethod *managed_method = NULL;
		return native_to_managed_trampoline_3 (self, _cmd, &managed_method, p0, 0x85004);
	}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x1E26);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end







#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation MSService {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x6428);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop





#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wprotocol"
#pragma clang diagnostic ignored "-Wobjc-protocol-property-synthesis"
#pragma clang diagnostic ignored "-Wobjc-property-implementation"
@implementation MSAnalyticsDelegate {
}

	-(id) init
	{
		static MonoMethod *managed_method = NULL;
		bool call_super = false;
		id rv = native_to_managed_trampoline_1 (self, _cmd, &managed_method, &call_super, 0x132E);
		if (call_super && rv) {
			struct objc_super super = {  rv, [NSObject class] };
			rv = ((id (*)(objc_super*, SEL)) objc_msgSendSuper) (&super, @selector (init));
		}
		return rv;
	}
@end
#pragma clang diagnostic pop




	static MTClassMap __xamarin_class_map [] = {
		{ NULL, 0x15B04 /* #0 'NSObject' => 'Foundation.NSObject, Xamarin.iOS' */ },
		{ NULL, 0x7704 /* #1 'SKPaymentTransactionObserver' => 'StoreKit.SKPaymentTransactionObserver, Xamarin.iOS' */ },
		{ NULL, 0xF904 /* #2 'UIApplicationDelegate' => 'UIKit.UIApplicationDelegate, Xamarin.iOS' */ },
		{ NULL, 0x10E04 /* #3 'UIResponder' => 'UIKit.UIResponder, Xamarin.iOS' */ },
		{ NULL, 0xE904 /* #4 'UIViewController' => 'UIKit.UIViewController, Xamarin.iOS' */ },
		{ NULL, 0x7604 /* #5 'SKPayment' => 'StoreKit.SKPayment, Xamarin.iOS' */ },
		{ NULL, 0x7804 /* #6 'SKPaymentQueue' => 'StoreKit.SKPaymentQueue, Xamarin.iOS' */ },
		{ NULL, 0x7904 /* #7 'SKPaymentTransaction' => 'StoreKit.SKPaymentTransaction, Xamarin.iOS' */ },
		{ NULL, 0x7F04 /* #8 'EAGLContext' => 'OpenGLES.EAGLContext, Xamarin.iOS' */ },
		{ NULL, 0x8304 /* #9 'EAGLSharegroup' => 'OpenGLES.EAGLSharegroup, Xamarin.iOS' */ },
		{ NULL, 0x8804 /* #10 'MPMediaEntity' => 'MediaPlayer.MPMediaEntity, Xamarin.iOS' */ },
		{ NULL, 0x8404 /* #11 'MPMediaItem' => 'MediaPlayer.MPMediaItem, Xamarin.iOS' */ },
		{ NULL, 0x8504 /* #12 'MPMediaItemArtwork' => 'MediaPlayer.MPMediaItemArtwork, Xamarin.iOS' */ },
		{ NULL, 0x8604 /* #13 'MPMediaQuery' => 'MediaPlayer.MPMediaQuery, Xamarin.iOS' */ },
		{ NULL, 0x8704 /* #14 'MPMoviePlayerController' => 'MediaPlayer.MPMoviePlayerController, Xamarin.iOS' */ },
		{ NULL, 0x8904 /* #15 'MPMediaItemCollection' => 'MediaPlayer.MPMediaItemCollection, Xamarin.iOS' */ },
		{ NULL, 0x8D04 /* #16 'MPMoviePlayerViewController' => 'MediaPlayer.MPMoviePlayerViewController, Xamarin.iOS' */ },
		{ NULL, 0x9D04 /* #17 'CMLogItem' => 'CoreMotion.CMLogItem, Xamarin.iOS' */ },
		{ NULL, 0x9504 /* #18 'CMAccelerometerData' => 'CoreMotion.CMAccelerometerData, Xamarin.iOS' */ },
		{ NULL, 0x9B04 /* #19 'CMAttitude' => 'CoreMotion.CMAttitude, Xamarin.iOS' */ },
		{ NULL, 0x9C04 /* #20 'CMDeviceMotion' => 'CoreMotion.CMDeviceMotion, Xamarin.iOS' */ },
		{ NULL, 0x9E04 /* #21 'CMMotionManager' => 'CoreMotion.CMMotionManager, Xamarin.iOS' */ },
		{ NULL, 0xB304 /* #22 'CALayer' => 'CoreAnimation.CALayer, Xamarin.iOS' */ },
		{ NULL, 0xB404 /* #23 'CADisplayLink' => 'CoreAnimation.CADisplayLink, Xamarin.iOS' */ },
		{ NULL, 0xB504 /* #24 'CALayerDelegate' => 'CoreAnimation.CALayerDelegate, Xamarin.iOS' */ },
		{ NULL, 0xB704 /* #25 'CAEAGLLayer' => 'CoreAnimation.CAEAGLLayer, Xamarin.iOS' */ },
		{ NULL, 0xD104 /* #26 'UIPresentationController' => 'UIKit.UIPresentationController, Xamarin.iOS' */ },
		{ NULL, 0xD204 /* #27 'UIActivityViewController' => 'UIKit.UIActivityViewController, Xamarin.iOS' */ },
		{ NULL, 0xD504 /* #28 'UIAppearance' => 'UIKit.UIAppearance, Xamarin.iOS' */ },
		{ NULL, 0xD704 /* #29 'UIApplication' => 'UIKit.UIApplication, Xamarin.iOS' */ },
		{ NULL, 0xD804 /* #30 'UIColor' => 'UIKit.UIColor, Xamarin.iOS' */ },
		{ NULL, 0xD904 /* #31 'UIKit_UIControlEventProxy' => 'UIKit.UIControlEventProxy, Xamarin.iOS' */ },
		{ NULL, 0xE604 /* #32 'UIView' => 'UIKit.UIView, Xamarin.iOS' */ },
		{ NULL, 0xDA04 /* #33 'UIControl' => 'UIKit.UIControl, Xamarin.iOS' */ },
		{ NULL, 0xDB04 /* #34 'UIDevice' => 'UIKit.UIDevice, Xamarin.iOS' */ },
		{ NULL, 0xDC04 /* #35 'UIEvent' => 'UIKit.UIEvent, Xamarin.iOS' */ },
		{ NULL, 0xDD04 /* #36 'UIFont' => 'UIKit.UIFont, Xamarin.iOS' */ },
		{ NULL, 0xDF04 /* #37 'UIImage' => 'UIKit.UIImage, Xamarin.iOS' */ },
		{ NULL, 0xE204 /* #38 'UIPopoverPresentationController' => 'UIKit.UIPopoverPresentationController, Xamarin.iOS' */ },
		{ NULL, 0xE304 /* #39 'UIScreen' => 'UIKit.UIScreen, Xamarin.iOS' */ },
		{ NULL, 0xE404 /* #40 'UITextField' => 'UIKit.UITextField, Xamarin.iOS' */ },
		{ NULL, 0xE504 /* #41 'UITraitCollection' => 'UIKit.UITraitCollection, Xamarin.iOS' */ },
		{ NULL, 0xEB04 /* #42 'UIWindow' => 'UIKit.UIWindow, Xamarin.iOS' */ },
		{ NULL, 0xF004 /* #43 'NSParagraphStyle' => 'UIKit.NSParagraphStyle, Xamarin.iOS' */ },
		{ NULL, 0xEF04 /* #44 'NSMutableParagraphStyle' => 'UIKit.NSMutableParagraphStyle, Xamarin.iOS' */ },
		{ NULL, 0xF204 /* #45 'UIActivity' => 'UIKit.UIActivity, Xamarin.iOS' */ },
		{ NULL, 0x11704 /* #46 'UITextFieldDelegate' => 'UIKit.UITextFieldDelegate, Xamarin.iOS' */ },
		{ NULL, 0x11B04 /* #47 'UITouch' => 'UIKit.UITouch, Xamarin.iOS' */ },
		{ NULL, 0x11E04 /* #48 'UIUserNotificationSettings' => 'UIKit.UIUserNotificationSettings, Xamarin.iOS' */ },
		{ NULL, 0x12704 /* #49 'NSArray' => 'Foundation.NSArray, Xamarin.iOS' */ },
		{ NULL, 0x12804 /* #50 'NSAttributedString' => 'Foundation.NSAttributedString, Xamarin.iOS' */ },
		{ NULL, 0x12904 /* #51 'NSBundle' => 'Foundation.NSBundle, Xamarin.iOS' */ },
		{ NULL, 0x12A04 /* #52 'NSCoder' => 'Foundation.NSCoder, Xamarin.iOS' */ },
		{ NULL, 0x12E04 /* #53 'NSDate' => 'Foundation.NSDate, Xamarin.iOS' */ },
		{ NULL, 0x13304 /* #54 'NSMutableArray' => 'Foundation.NSMutableArray, Xamarin.iOS' */ },
		{ NULL, 0x13904 /* #55 'Foundation_InternalNSNotificationHandler' => 'Foundation.InternalNSNotificationHandler, Xamarin.iOS' */ },
		{ NULL, 0x13D04 /* #56 'NSNull' => 'Foundation.NSNull, Xamarin.iOS' */ },
		{ NULL, 0x13E04 /* #57 'NSRunLoop' => 'Foundation.NSRunLoop, Xamarin.iOS' */ },
		{ NULL, 0x14204 /* #58 'NSString' => 'Foundation.NSString, Xamarin.iOS' */ },
		{ NULL, 0x14304 /* #59 'NSTimer' => 'Foundation.NSTimer, Xamarin.iOS' */ },
		{ NULL, 0x14404 /* #60 'NSURL' => 'Foundation.NSUrl, Xamarin.iOS' */ },
		{ NULL, 0x14604 /* #61 'NSUserDefaults' => 'Foundation.NSUserDefaults, Xamarin.iOS' */ },
		{ NULL, 0x14704 /* #62 'NSUUID' => 'Foundation.NSUuid, Xamarin.iOS' */ },
		{ NULL, 0x15004 /* #63 'Foundation_NSDispatcher' => 'Foundation.NSDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15104 /* #64 '__MonoMac_NSActionDispatcher' => 'Foundation.NSActionDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15204 /* #65 '__MonoMac_NSSynchronizationContextDispatcher' => 'Foundation.NSSynchronizationContextDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15304 /* #66 '__Xamarin_NSTimerActionDispatcher' => 'Foundation.NSTimerActionDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15404 /* #67 'Foundation_NSAsyncDispatcher' => 'Foundation.NSAsyncDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15504 /* #68 '__MonoMac_NSAsyncActionDispatcher' => 'Foundation.NSAsyncActionDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15604 /* #69 '__MonoMac_NSAsyncSynchronizationContextDispatcher' => 'Foundation.NSAsyncSynchronizationContextDispatcher, Xamarin.iOS' */ },
		{ NULL, 0x15704 /* #70 'NSAutoreleasePool' => 'Foundation.NSAutoreleasePool, Xamarin.iOS' */ },
		{ NULL, 0x15804 /* #71 'NSError' => 'Foundation.NSError, Xamarin.iOS' */ },
		{ NULL, 0x16004 /* #72 'NSValue' => 'Foundation.NSValue, Xamarin.iOS' */ },
		{ NULL, 0x15904 /* #73 'NSNumber' => 'Foundation.NSNumber, Xamarin.iOS' */ },
		{ NULL, 0x16704 /* #74 'NSDecimalNumber' => 'Foundation.NSDecimalNumber, Xamarin.iOS' */ },
		{ NULL, 0x16804 /* #75 'NSEnumerator' => 'Foundation.NSEnumerator, Xamarin.iOS' */ },
		{ NULL, 0x16904 /* #76 'NSException' => 'Foundation.NSException, Xamarin.iOS' */ },
		{ NULL, 0x16C04 /* #77 'NSNotification' => 'Foundation.NSNotification, Xamarin.iOS' */ },
		{ NULL, 0x16F04 /* #78 'NSOperationQueue' => 'Foundation.NSOperationQueue, Xamarin.iOS' */ },
		{ NULL, 0x17004 /* #79 'NSProcessInfo' => 'Foundation.NSProcessInfo, Xamarin.iOS' */ },
		{ NULL, 0x17204 /* #80 'NSStringDrawingContext' => 'Foundation.NSStringDrawingContext, Xamarin.iOS' */ },
		{ NULL, 0x17D04 /* #81 'AVAudioPlayer' => 'AVFoundation.AVAudioPlayer, Xamarin.iOS' */ },
		{ NULL, 0x18104 /* #82 'AVPlayer' => 'AVFoundation.AVPlayer, Xamarin.iOS' */ },
		{ NULL, 0xD304 /* #83 'UIAlertView' => 'UIKit.UIAlertView, Xamarin.iOS' */ },
		{ NULL, 0x12B04 /* #84 'NSData' => 'Foundation.NSData, Xamarin.iOS' */ },
		{ NULL, 0x12F04 /* #85 'NSDictionary' => 'Foundation.NSDictionary, Xamarin.iOS' */ },
		{ NULL, 0x13404 /* #86 'NSMutableData' => 'Foundation.NSMutableData, Xamarin.iOS' */ },
		{ NULL, 0x13704 /* #87 'NSMutableDictionary' => 'Foundation.NSMutableDictionary, Xamarin.iOS' */ },
		{ NULL, 0x13A04 /* #88 'NSNotificationCenter' => 'Foundation.NSNotificationCenter, Xamarin.iOS' */ },
		{ NULL, 0x14004 /* #89 'NSSet' => 'Foundation.NSSet, Xamarin.iOS' */ },
		{ NULL, 0x17E04 /* #90 'AVAudioSession' => 'AVFoundation.AVAudioSession, Xamarin.iOS' */ },
		{ NULL, 0x18204 /* #91 'AVPlayerItem' => 'AVFoundation.AVPlayerItem, Xamarin.iOS' */ },
		{ NULL, 0x200 /* #92 'CC_Mobile_Purchases_CustomPaymentObserver' => 'CC.Mobile.Purchases.CustomPaymentObserver, LooneyInvadersiOS' */ },
		{ NULL, 0x5700 /* #93 'AppDelegate' => 'LooneyInvaders.iOS.AppDelegate, LooneyInvadersiOS' */ },
		{ NULL, 0x5900 /* #94 'ViewController' => 'LooneyInvaders.iOS.ViewController, LooneyInvadersiOS' */ },
		{ NULL, 0xD404 /* #95 'UIKit_UIAlertView__UIAlertViewDelegate' => 'UIKit.UIAlertView+_UIAlertViewDelegate, Xamarin.iOS' */ },
		{ NULL, 0xE704 /* #96 'UIKit_UIView_UIViewAppearance' => 'UIKit.UIView+UIViewAppearance, Xamarin.iOS' */ },
		{ NULL, 0x15D04 /* #97 '__NSObject_Disposer' => 'Foundation.NSObject+NSObject_Disposer, Xamarin.iOS' */ },
		{ NULL, 0x6614 /* #98 'OpenTK_Platform_iPhoneOS_iPhoneOSGameView' => 'OpenTK.Platform.iPhoneOS.iPhoneOSGameView, OpenTK-1.0' */ },
		{ NULL, 0x480E /* #99 'CCGameView' => 'CocosSharp.CCGameView, CocosSharp' */ },
		{ NULL, 0x4E0E /* #100 'CocosSharp_IMEKeyboardImpl_HiddenInputDelegate' => 'CocosSharp.IMEKeyboardImpl+HiddenInputDelegate, CocosSharp' */ },
		{ NULL, 0x4F0E /* #101 'CocosSharp_IMEKeyboardImpl_HiddenInput' => 'CocosSharp.IMEKeyboardImpl+HiddenInput, CocosSharp' */ },
		{ NULL, 0x7510 /* #102 'Microsoft_Xna_Framework_iOSGameViewController' => 'Microsoft.Xna.Framework.iOSGameViewController, MonoGame.Framework' */ },
		{ NULL, 0x7810 /* #103 'iOSGameView' => 'Microsoft.Xna.Framework.iOSGameView, MonoGame.Framework' */ },
		{ NULL, 0x6414 /* #104 'OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource' => 'OpenTK.Platform.iPhoneOS.CADisplayLinkTimeSource, OpenTK-1.0' */ },
		{ NULL, 0x7316 /* #105 'GADNativeAd' => 'Google.MobileAds.NativeAd, Google.MobileAds' */ },
		{ NULL, 0xE16 /* #106 'GADNativeCustomTemplateAd' => 'Google.MobileAds.NativeCustomTemplateAd, Google.MobileAds' */ },
		{ NULL, 0xF16 /* #107 'GADRequest' => 'Google.MobileAds.Request, Google.MobileAds' */ },
		{ NULL, 0x1016 /* #108 'GADRequestError' => 'Google.MobileAds.RequestError, Google.MobileAds' */ },
		{ NULL, 0x1C16 /* #109 'GADAdLoader' => 'Google.MobileAds.AdLoader, Google.MobileAds' */ },
		{ NULL, 0x1F16 /* #110 'GADAdLoaderDelegate' => 'Google.MobileAds.AdLoaderDelegate, Google.MobileAds' */ },
		{ NULL, 0x2016 /* #111 'GADAdLoaderOptions' => 'Google.MobileAds.AdLoaderOptions, Google.MobileAds' */ },
		{ NULL, 0x2316 /* #112 'GADAdNetworkExtras' => 'Google.MobileAds.AdNetworkExtras, Google.MobileAds' */ },
		{ NULL, 0x2416 /* #113 'GADAdReward' => 'Google.MobileAds.AdReward, Google.MobileAds' */ },
		{ NULL, 0x2716 /* #114 'GADAdSizeDelegate' => 'Google.MobileAds.AdSizeDelegate, Google.MobileAds' */ },
		{ NULL, 0x2A16 /* #115 'GADAppEventDelegate' => 'Google.MobileAds.AppEventDelegate, Google.MobileAds' */ },
		{ NULL, 0x2F16 /* #116 'GADAudioVideoManagerDelegate' => 'Google.MobileAds.AudioVideoManagerDelegate, Google.MobileAds' */ },
		{ NULL, 0x3816 /* #117 'GADBannerViewDelegate' => 'Google.MobileAds.BannerViewDelegate, Google.MobileAds' */ },
		{ NULL, 0x3916 /* #118 'GADCorrelator' => 'Google.MobileAds.Correlator, Google.MobileAds' */ },
		{ NULL, 0x3A16 /* #119 'GADCorrelatorAdLoaderOptions' => 'Google.MobileAds.CorrelatorAdLoaderOptions, Google.MobileAds' */ },
		{ NULL, 0x4016 /* #120 'GADCustomEventBannerDelegate' => 'Google.MobileAds.CustomEventBannerDelegate, Google.MobileAds' */ },
		{ NULL, 0x4116 /* #121 'GADCustomEventExtras' => 'Google.MobileAds.CustomEventExtras, Google.MobileAds' */ },
		{ NULL, 0x4716 /* #122 'GADCustomEventInterstitialDelegate' => 'Google.MobileAds.CustomEventInterstitialDelegate, Google.MobileAds' */ },
		{ NULL, 0x4A16 /* #123 'GADCustomEventNativeAd' => 'Google.MobileAds.CustomEventNativeAd, Google.MobileAds' */ },
		{ NULL, 0x4D16 /* #124 'GADCustomEventNativeAdDelegate' => 'Google.MobileAds.CustomEventNativeAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x4E16 /* #125 'GADCustomEventRequest' => 'Google.MobileAds.CustomEventRequest, Google.MobileAds' */ },
		{ NULL, 0x4F16 /* #126 'GADDebugOptionsViewController' => 'Google.MobileAds.DebugOptionsViewController, Google.MobileAds' */ },
		{ NULL, 0x5216 /* #127 'GADDebugOptionsViewControllerDelegate' => 'Google.MobileAds.DebugOptionsViewControllerDelegate, Google.MobileAds' */ },
		{ NULL, 0x5316 /* #128 'GADDefaultInAppPurchase' => 'Google.MobileAds.DefaultInAppPurchase, Google.MobileAds' */ },
		{ NULL, 0x5616 /* #129 'GADDefaultInAppPurchaseDelegate' => 'Google.MobileAds.DefaultInAppPurchaseDelegate, Google.MobileAds' */ },
		{ NULL, 0x5716 /* #130 'GADDynamicHeightSearchRequest' => 'Google.MobileAds.DynamicHeightSearchRequest, Google.MobileAds' */ },
		{ NULL, 0x5816 /* #131 'GADExtras' => 'Google.MobileAds.Extras, Google.MobileAds' */ },
		{ NULL, 0x5916 /* #132 'GADInAppPurchase' => 'Google.MobileAds.InAppPurchase, Google.MobileAds' */ },
		{ NULL, 0x5C16 /* #133 'GADInAppPurchaseDelegate' => 'Google.MobileAds.InAppPurchaseDelegate, Google.MobileAds' */ },
		{ NULL, 0x6216 /* #134 'GADInterstitialDelegate' => 'Google.MobileAds.InterstitialDelegate, Google.MobileAds' */ },
		{ NULL, 0x6516 /* #135 'Google_MobileAds_MediatedNativeAd' => 'Google.MobileAds.MediatedNativeAd, Google.MobileAds' */ },
		{ NULL, 0x6816 /* #136 'GADMediatedNativeAdDelegate' => 'Google.MobileAds.MediatedNativeAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x6916 /* #137 'GADMediatedNativeAdNotificationSource' => 'Google.MobileAds.MediatedNativeAdNotificationSource, Google.MobileAds' */ },
		{ NULL, 0x6C16 /* #138 'GADMediatedNativeAppInstallAd' => 'Google.MobileAds.MediatedNativeAppInstallAd, Google.MobileAds' */ },
		{ NULL, 0x6F16 /* #139 'GADMediatedNativeContentAd' => 'Google.MobileAds.MediatedNativeContentAd, Google.MobileAds' */ },
		{ NULL, 0x7016 /* #140 'GADMediaView' => 'Google.MobileAds.MediaView, Google.MobileAds' */ },
		{ NULL, 0x7116 /* #141 'GADMobileAds' => 'Google.MobileAds.MobileAds, Google.MobileAds' */ },
		{ NULL, 0x7216 /* #142 'GADMultipleAdsAdLoaderOptions' => 'Google.MobileAds.MultipleAdsAdLoaderOptions, Google.MobileAds' */ },
		{ NULL, 0x7716 /* #143 'GADNativeAdDelegate' => 'Google.MobileAds.NativeAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x7816 /* #144 'GADNativeAdImage' => 'Google.MobileAds.NativeAdImage, Google.MobileAds' */ },
		{ NULL, 0x7916 /* #145 'GADNativeAdImageAdLoaderOptions' => 'Google.MobileAds.NativeAdImageAdLoaderOptions, Google.MobileAds' */ },
		{ NULL, 0x7A16 /* #146 'GADNativeAdViewAdOptions' => 'Google.MobileAds.NativeAdViewAdOptions, Google.MobileAds' */ },
		{ NULL, 0x7B16 /* #147 'GADNativeAppInstallAd' => 'Google.MobileAds.NativeAppInstallAd, Google.MobileAds' */ },
		{ NULL, 0x7E16 /* #148 'GADNativeAppInstallAdLoaderDelegate' => 'Google.MobileAds.NativeAppInstallAdLoaderDelegate, Google.MobileAds' */ },
		{ NULL, 0x8116 /* #149 'GADNativeContentAd' => 'Google.MobileAds.NativeContentAd, Google.MobileAds' */ },
		{ NULL, 0x8416 /* #150 'GADNativeContentAdLoaderDelegate' => 'Google.MobileAds.NativeContentAdLoaderDelegate, Google.MobileAds' */ },
		{ NULL, 0x8916 /* #151 'GADNativeCustomTemplateAdLoaderDelegate' => 'Google.MobileAds.NativeCustomTemplateAdLoaderDelegate, Google.MobileAds' */ },
		{ NULL, 0x9016 /* #152 'GADNativeExpressAdViewDelegate' => 'Google.MobileAds.NativeExpressAdViewDelegate, Google.MobileAds' */ },
		{ NULL, 0x9516 /* #153 'GADRewardBasedVideoAdDelegate' => 'Google.MobileAds.RewardBasedVideoAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x9816 /* #154 'GADSearchRequest' => 'Google.MobileAds.SearchRequest, Google.MobileAds' */ },
		{ NULL, 0x9B16 /* #155 'GADSwipeableBannerViewDelegate' => 'Google.MobileAds.SwipeableBannerViewDelegate, Google.MobileAds' */ },
		{ NULL, 0xA016 /* #156 'GADVideoControllerDelegate' => 'Google.MobileAds.VideoControllerDelegate, Google.MobileAds' */ },
		{ NULL, 0xA116 /* #157 'GADVideoOptions' => 'Google.MobileAds.VideoOptions, Google.MobileAds' */ },
		{ NULL, 0xA816 /* #158 'DFPBannerAdLoaderDelegate' => 'Google.MobileAds.DoubleClick.BannerAdLoaderDelegate, Google.MobileAds' */ },
		{ NULL, 0xA916 /* #159 'DFPBannerViewOptions' => 'Google.MobileAds.DoubleClick.BannerViewOptions, Google.MobileAds' */ },
		{ NULL, 0xAA16 /* #160 'DFPCustomRenderedAd' => 'Google.MobileAds.DoubleClick.CustomRenderedAd, Google.MobileAds' */ },
		{ NULL, 0xAD16 /* #161 'DFPCustomRenderedBannerViewDelegate' => 'Google.MobileAds.DoubleClick.CustomRenderedBannerViewDelegate, Google.MobileAds' */ },
		{ NULL, 0xB016 /* #162 'DFPCustomRenderedInterstitialDelegate' => 'Google.MobileAds.DoubleClick.CustomRenderedInterstitialDelegate, Google.MobileAds' */ },
		{ NULL, 0xB416 /* #163 'DFPRequest' => 'Google.MobileAds.DoubleClick.Request, Google.MobileAds' */ },
		{ NULL, 0x1216 /* #164 'Google_MobileAds_RewardBasedVideoAd__RewardBasedVideoAdDelegate' => 'Google.MobileAds.RewardBasedVideoAd+_RewardBasedVideoAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x1116 /* #165 'GADRewardBasedVideoAd' => 'Google.MobileAds.RewardBasedVideoAd, Google.MobileAds' */ },
		{ NULL, 0x1B16 /* #166 'Google_MobileAds_AdChoicesView_AdChoicesViewAppearance' => 'Google.MobileAds.AdChoicesView+AdChoicesViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x1A16 /* #167 'GADAdChoicesView' => 'Google.MobileAds.AdChoicesView, Google.MobileAds' */ },
		{ NULL, 0x2C16 /* #168 'Google_MobileAds_AudioVideoManager__AudioVideoManagerDelegate' => 'Google.MobileAds.AudioVideoManager+_AudioVideoManagerDelegate, Google.MobileAds' */ },
		{ NULL, 0x2B16 /* #169 'GADAudioVideoManager' => 'Google.MobileAds.AudioVideoManager, Google.MobileAds' */ },
		{ NULL, 0x3116 /* #170 'Google_MobileAds_BannerView__BannerViewDelegate' => 'Google.MobileAds.BannerView+_BannerViewDelegate, Google.MobileAds' */ },
		{ NULL, 0x3216 /* #171 'Google_MobileAds_BannerView__AdSizeDelegate' => 'Google.MobileAds.BannerView+_AdSizeDelegate, Google.MobileAds' */ },
		{ NULL, 0x3316 /* #172 'Google_MobileAds_BannerView_BannerViewAppearance' => 'Google.MobileAds.BannerView+BannerViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x3016 /* #173 'GADBannerView' => 'Google.MobileAds.BannerView, Google.MobileAds' */ },
		{ NULL, 0x5E16 /* #174 'Google_MobileAds_Interstitial__InterstitialDelegate' => 'Google.MobileAds.Interstitial+_InterstitialDelegate, Google.MobileAds' */ },
		{ NULL, 0x5D16 /* #175 'GADInterstitial' => 'Google.MobileAds.Interstitial, Google.MobileAds' */ },
		{ NULL, 0x7416 /* #176 'Google_MobileAds_NativeAd__NativeAdDelegate' => 'Google.MobileAds.NativeAd+_NativeAdDelegate, Google.MobileAds' */ },
		{ NULL, 0x8016 /* #177 'Google_MobileAds_NativeAppInstallAdView_NativeAppInstallAdViewAppearance' => 'Google.MobileAds.NativeAppInstallAdView+NativeAppInstallAdViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x7F16 /* #178 'GADNativeAppInstallAdView' => 'Google.MobileAds.NativeAppInstallAdView, Google.MobileAds' */ },
		{ NULL, 0x8616 /* #179 'Google_MobileAds_NativeContentAdView_NativeContentAdViewAppearance' => 'Google.MobileAds.NativeContentAdView+NativeContentAdViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x8516 /* #180 'GADNativeContentAdView' => 'Google.MobileAds.NativeContentAdView, Google.MobileAds' */ },
		{ NULL, 0x8B16 /* #181 'Google_MobileAds_NativeExpressAdView__NativeExpressAdViewDelegate' => 'Google.MobileAds.NativeExpressAdView+_NativeExpressAdViewDelegate, Google.MobileAds' */ },
		{ NULL, 0x8C16 /* #182 'Google_MobileAds_NativeExpressAdView_NativeExpressAdViewAppearance' => 'Google.MobileAds.NativeExpressAdView+NativeExpressAdViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x8A16 /* #183 'GADNativeExpressAdView' => 'Google.MobileAds.NativeExpressAdView, Google.MobileAds' */ },
		{ NULL, 0x9716 /* #184 'Google_MobileAds_SearchBannerView_SearchBannerViewAppearance' => 'Google.MobileAds.SearchBannerView+SearchBannerViewAppearance, Google.MobileAds' */ },
		{ NULL, 0x9616 /* #185 'GADSearchBannerView' => 'Google.MobileAds.SearchBannerView, Google.MobileAds' */ },
		{ NULL, 0x9D16 /* #186 'Google_MobileAds_VideoController__VideoControllerDelegate' => 'Google.MobileAds.VideoController+_VideoControllerDelegate, Google.MobileAds' */ },
		{ NULL, 0x9C16 /* #187 'GADVideoController' => 'Google.MobileAds.VideoController, Google.MobileAds' */ },
		{ NULL, 0xA416 /* #188 'Google_MobileAds_DoubleClick_BannerView__AdSizeDelegate' => 'Google.MobileAds.DoubleClick.BannerView+_AdSizeDelegate, Google.MobileAds' */ },
		{ NULL, 0xA516 /* #189 'Google_MobileAds_DoubleClick_BannerView_BannerViewAppearance' => 'Google.MobileAds.DoubleClick.BannerView+BannerViewAppearance, Google.MobileAds' */ },
		{ NULL, 0xA316 /* #190 'DFPBannerView' => 'Google.MobileAds.DoubleClick.BannerView, Google.MobileAds' */ },
		{ NULL, 0xB216 /* #191 'Google_MobileAds_DoubleClick_Interstitial__CustomRenderedInterstitialDelegate' => 'Google.MobileAds.DoubleClick.Interstitial+_CustomRenderedInterstitialDelegate, Google.MobileAds' */ },
		{ NULL, 0xB116 /* #192 'DFPInterstitial' => 'Google.MobileAds.DoubleClick.Interstitial, Google.MobileAds' */ },
		{ NULL, 0x622 /* #193 'MSPushDelegate' => 'Microsoft.AppCenter.Push.iOS.Bindings.MSPushDelegate, Microsoft.AppCenter.Push.iOS.Bindings' */ },
		{ NULL, 0x420 /* #194 'Microsoft_AppCenter_Push_iOS_PushDelegate' => 'Microsoft.AppCenter.Push.iOS.PushDelegate, Microsoft.AppCenter.Push' */ },
		{ NULL, 0x322 /* #195 'MSPush' => 'Microsoft.AppCenter.Push.iOS.Bindings.MSPush, Microsoft.AppCenter.Push.iOS.Bindings' */ },
		{ NULL, 0x722 /* #196 'MSPushNotification' => 'Microsoft.AppCenter.Push.iOS.Bindings.MSPushNotification, Microsoft.AppCenter.Push.iOS.Bindings' */ },
		{ NULL, 0xD26 /* #197 'MSCrashesDelegate' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSCrashesDelegate, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1524 /* #198 'Microsoft_AppCenter_Crashes_Crashes_CrashesDelegate' => 'Microsoft.AppCenter.Crashes.Crashes+CrashesDelegate, Microsoft.AppCenter.Crashes' */ },
		{ NULL, 0xA26 /* #199 'MSCrashes' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSCrashes, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1026 /* #200 'MSCrashHandlerSetupDelegate' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSCrashHandlerSetupDelegate, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1126 /* #201 'MSErrorAttachmentLog' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSErrorAttachmentLog, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1226 /* #202 'MSErrorReport' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSErrorReport, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1326 /* #203 'MSException' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSException, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1426 /* #204 'MSStackFrame' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSStackFrame, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1526 /* #205 'MSWrapperCrashesHelper' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSWrapperCrashesHelper, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1626 /* #206 'MSWrapperException' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSWrapperException, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x1726 /* #207 'MSWrapperExceptionManager' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.MSWrapperExceptionManager, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0x726 /* #208 'Microsoft_AppCenter_Crashes_iOS_Bindings_CrashesInitializationDelegate' => 'Microsoft.AppCenter.Crashes.iOS.Bindings.CrashesInitializationDelegate, Microsoft.AppCenter.Crashes.iOS.Bindings' */ },
		{ NULL, 0xB28 /* #209 'MSAppCenter' => 'Microsoft.AppCenter.iOS.Bindings.MSAppCenter, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0xC28 /* #210 'MSCustomProperties' => 'Microsoft.AppCenter.iOS.Bindings.MSCustomProperties, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0x1428 /* #211 'MSWrapperSdk' => 'Microsoft.AppCenter.iOS.Bindings.MSWrapperSdk, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0xD28 /* #212 'MSDevice' => 'Microsoft.AppCenter.iOS.Bindings.MSDevice, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0xE28 /* #213 'MSLogger' => 'Microsoft.AppCenter.iOS.Bindings.MSLogger, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0x1128 /* #214 'MSService' => 'Microsoft.AppCenter.iOS.Bindings.MSService, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0x1228 /* #215 'MSServiceAbstract' => 'Microsoft.AppCenter.iOS.Bindings.MSServiceAbstract, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0x1328 /* #216 'MSWrapperLogger' => 'Microsoft.AppCenter.iOS.Bindings.MSWrapperLogger, Microsoft.AppCenter.iOS.Bindings' */ },
		{ NULL, 0x32E /* #217 'MSAnalytics' => 'Microsoft.AppCenter.Analytics.iOS.Bindings.MSAnalytics, Microsoft.AppCenter.Analytics.iOS.Bindings' */ },
		{ NULL, 0x62E /* #218 'MSAnalyticsDelegate' => 'Microsoft.AppCenter.Analytics.iOS.Bindings.MSAnalyticsDelegate, Microsoft.AppCenter.Analytics.iOS.Bindings' */ },
		{ NULL, 0x82E /* #219 'MSLogWithProperties' => 'Microsoft.AppCenter.Analytics.iOS.Bindings.MSLogWithProperties, Microsoft.AppCenter.Analytics.iOS.Bindings' */ },
		{ NULL, 0x72E /* #220 'MSEventLog' => 'Microsoft.AppCenter.Analytics.iOS.Bindings.MSEventLog, Microsoft.AppCenter.Analytics.iOS.Bindings' */ },
		{ NULL, 0x92E /* #221 'MSPageLog' => 'Microsoft.AppCenter.Analytics.iOS.Bindings.MSPageLog, Microsoft.AppCenter.Analytics.iOS.Bindings' */ },
		{ NULL, 0 },
	};

	static const MTManagedClassMap __xamarin_skipped_map [] = {
		{ 0x13104, 85 /* 'Foundation.NSDictionary`2' => 'Foundation.NSDictionary' */ },
	};

	static const char *__xamarin_registration_assemblies []= {
		"LooneyInvadersiOS", 
		"mscorlib", 
		"Xamarin.iOS", 
		"System", 
		"Mono.Security", 
		"System.Xml", 
		"System.Core", 
		"CocosSharp", 
		"MonoGame.Framework", 
		"System.Runtime.Serialization", 
		"OpenTK-1.0", 
		"Google.MobileAds", 
		"App42_CSHARP_SDK_2.3", 
		"Plugin.Settings", 
		"Plugin.Connectivity", 
		"Plugin.Connectivity.Abstractions", 
		"Microsoft.AppCenter.Push", 
		"Microsoft.AppCenter.Push.iOS.Bindings", 
		"Microsoft.AppCenter.Crashes", 
		"Microsoft.AppCenter.Crashes.iOS.Bindings", 
		"Microsoft.AppCenter.iOS.Bindings", 
		"Microsoft.AppCenter", 
		"Microsoft.AppCenter.Analytics", 
		"Microsoft.AppCenter.Analytics.iOS.Bindings"
	};

	static const MTProtocolWrapperMap __xamarin_protocol_wrapper_map [] = {
		{ 0x422 /* Microsoft.AppCenter.Push.iOS.Bindings.IMSPushDelegate */, 0x522 /* MSPushDelegateWrapper */ },
		{ 0x42E /* Microsoft.AppCenter.Analytics.iOS.Bindings.IMSAnalyticsDelegate */, 0x52E /* MSAnalyticsDelegateWrapper */ },
		{ 0xB26 /* Microsoft.AppCenter.Crashes.iOS.Bindings.IMSCrashesDelegate */, 0xC26 /* MSCrashesDelegateWrapper */ },
		{ 0xE26 /* Microsoft.AppCenter.Crashes.iOS.Bindings.IMSCrashHandlerSetupDelegate */, 0xF26 /* MSCrashHandlerSetupDelegateWrapper */ },
		{ 0xF28 /* Microsoft.AppCenter.iOS.Bindings.IMSService */, 0x1028 /* MSServiceWrapper */ },
		{ 0x1D16 /* Google.MobileAds.IAdLoaderDelegate */, 0x1E16 /* AdLoaderDelegateWrapper */ },
		{ 0x2116 /* Google.MobileAds.IAdNetworkExtras */, 0x2216 /* AdNetworkExtrasWrapper */ },
		{ 0x2516 /* Google.MobileAds.IAdSizeDelegate */, 0x2616 /* AdSizeDelegateWrapper */ },
		{ 0x2816 /* Google.MobileAds.IAppEventDelegate */, 0x2916 /* AppEventDelegateWrapper */ },
		{ 0x2D16 /* Google.MobileAds.IAudioVideoManagerDelegate */, 0x2E16 /* AudioVideoManagerDelegateWrapper */ },
		{ 0x3616 /* Google.MobileAds.IBannerViewDelegate */, 0x3716 /* BannerViewDelegateWrapper */ },
		{ 0x3B16 /* Google.MobileAds.ICustomEventBanner */, 0x3C16 /* CustomEventBannerWrapper */ },
		{ 0x3E16 /* Google.MobileAds.ICustomEventBannerDelegate */, 0x3F16 /* CustomEventBannerDelegateWrapper */ },
		{ 0x4216 /* Google.MobileAds.ICustomEventInterstitial */, 0x4316 /* CustomEventInterstitialWrapper */ },
		{ 0x4516 /* Google.MobileAds.ICustomEventInterstitialDelegate */, 0x4616 /* CustomEventInterstitialDelegateWrapper */ },
		{ 0x4816 /* Google.MobileAds.ICustomEventNativeAd */, 0x4916 /* CustomEventNativeAdWrapper */ },
		{ 0x4B16 /* Google.MobileAds.ICustomEventNativeAdDelegate */, 0x4C16 /* CustomEventNativeAdDelegateWrapper */ },
		{ 0x5016 /* Google.MobileAds.IDebugOptionsViewControllerDelegate */, 0x5116 /* DebugOptionsViewControllerDelegateWrapper */ },
		{ 0x5416 /* Google.MobileAds.IDefaultInAppPurchaseDelegate */, 0x5516 /* DefaultInAppPurchaseDelegateWrapper */ },
		{ 0x5A16 /* Google.MobileAds.IInAppPurchaseDelegate */, 0x5B16 /* InAppPurchaseDelegateWrapper */ },
		{ 0x6016 /* Google.MobileAds.IInterstitialDelegate */, 0x6116 /* InterstitialDelegateWrapper */ },
		{ 0x6316 /* Google.MobileAds.IMediatedNativeAd */, 0x6416 /* MediatedNativeAdWrapper */ },
		{ 0x6616 /* Google.MobileAds.IMediatedNativeAdDelegate */, 0x6716 /* MediatedNativeAdDelegateWrapper */ },
		{ 0x6A16 /* Google.MobileAds.IMediatedNativeAppInstallAd */, 0x6B16 /* MediatedNativeAppInstallAdWrapper */ },
		{ 0x6D16 /* Google.MobileAds.IMediatedNativeContentAd */, 0x6E16 /* MediatedNativeContentAdWrapper */ },
		{ 0x7516 /* Google.MobileAds.INativeAdDelegate */, 0x7616 /* NativeAdDelegateWrapper */ },
		{ 0x7A04 /* StoreKit.ISKPaymentTransactionObserver */, 0x7B04 /* SKPaymentTransactionObserverWrapper */ },
		{ 0x7C16 /* Google.MobileAds.INativeAppInstallAdLoaderDelegate */, 0x7D16 /* NativeAppInstallAdLoaderDelegateWrapper */ },
		{ 0x8104 /* OpenGLES.IEAGLDrawable */, 0x8204 /* EAGLDrawableWrapper */ },
		{ 0x8216 /* Google.MobileAds.INativeContentAdLoaderDelegate */, 0x8316 /* NativeContentAdLoaderDelegateWrapper */ },
		{ 0x8716 /* Google.MobileAds.INativeCustomTemplateAdLoaderDelegate */, 0x8816 /* NativeCustomTemplateAdLoaderDelegateWrapper */ },
		{ 0x8A04 /* MediaPlayer.IMPMediaPlayback */, 0x8B04 /* MPMediaPlaybackWrapper */ },
		{ 0x8E16 /* Google.MobileAds.INativeExpressAdViewDelegate */, 0x8F16 /* NativeExpressAdViewDelegateWrapper */ },
		{ 0x9316 /* Google.MobileAds.IRewardBasedVideoAdDelegate */, 0x9416 /* RewardBasedVideoAdDelegateWrapper */ },
		{ 0x9916 /* Google.MobileAds.ISwipeableBannerViewDelegate */, 0x9A16 /* SwipeableBannerViewDelegateWrapper */ },
		{ 0x9E16 /* Google.MobileAds.IVideoControllerDelegate */, 0x9F16 /* VideoControllerDelegateWrapper */ },
		{ 0xA616 /* Google.MobileAds.DoubleClick.IBannerAdLoaderDelegate */, 0xA716 /* BannerAdLoaderDelegateWrapper */ },
		{ 0xAB16 /* Google.MobileAds.DoubleClick.ICustomRenderedBannerViewDelegate */, 0xAC16 /* CustomRenderedBannerViewDelegateWrapper */ },
		{ 0xAE16 /* Google.MobileAds.DoubleClick.ICustomRenderedInterstitialDelegate */, 0xAF16 /* CustomRenderedInterstitialDelegateWrapper */ },
		{ 0xF304 /* UIKit.IUIAlertViewDelegate */, 0xF404 /* UIAlertViewDelegateWrapper */ },
		{ 0xF604 /* UIKit.IUIApplicationDelegate */, 0xF804 /* UIApplicationDelegateWrapper */ },
		{ 0xFB04 /* UIKit.IUIContentContainer */, 0xFC04 /* UIContentContainerWrapper */ },
		{ 0xFE04 /* UIKit.IUICoordinateSpace */, 0xFF04 /* UICoordinateSpaceWrapper */ },
		{ 0x10104 /* UIKit.IUIDynamicItem */, 0x10204 /* UIDynamicItemWrapper */ },
		{ 0x10904 /* UIKit.IUIKeyInput */, 0x10A04 /* UIKeyInputWrapper */ },
		{ 0x11504 /* UIKit.IUITextFieldDelegate */, 0x11604 /* UITextFieldDelegateWrapper */ },
		{ 0x11804 /* UIKit.IUITextInputTraits */, 0x11904 /* UITextInputTraitsWrapper */ },
		{ 0x12204 /* UIKit.IUIViewControllerTransitionCoordinator */, 0x12304 /* UIViewControllerTransitionCoordinatorWrapper */ },
		{ 0x12404 /* UIKit.IUIViewControllerTransitionCoordinatorContext */, 0x12504 /* UIViewControllerTransitionCoordinatorContextWrapper */ },
		{ 0x16504 /* Foundation.INSCopying */, 0x16604 /* NSCopyingWrapper */ },
		{ 0x16A04 /* Foundation.INSMutableCopying */, 0x16B04 /* NSMutableCopyingWrapper */ },
		{ 0x16D04 /* Foundation.INSObjectProtocol */, 0x16E04 /* NSObjectProtocolWrapper */ },
	};

	static struct MTRegistrationMap __xamarin_registration_map = {
		__xamarin_registration_assemblies,
		__xamarin_class_map,
		NULL,
		__xamarin_skipped_map,
		__xamarin_protocol_wrapper_map,
		{ NULL, NULL },
		24,
		222,
		130,
		0,
		1,
		52,
		0
	};

void xamarin_create_classes () {
	__xamarin_class_map [0].handle = objc_getClass ("NSObject");
	__xamarin_class_map [1].handle = objc_getClass ("SKPaymentTransactionObserver");
	__xamarin_class_map [2].handle = objc_getClass ("UIApplicationDelegate");
	__xamarin_class_map [3].handle = objc_getClass ("UIResponder");
	__xamarin_class_map [4].handle = objc_getClass ("UIViewController");
	__xamarin_class_map [5].handle = objc_getClass ("SKPayment");
	__xamarin_class_map [6].handle = objc_getClass ("SKPaymentQueue");
	__xamarin_class_map [7].handle = objc_getClass ("SKPaymentTransaction");
	__xamarin_class_map [8].handle = objc_getClass ("EAGLContext");
	__xamarin_class_map [9].handle = objc_getClass ("EAGLSharegroup");
	__xamarin_class_map [10].handle = objc_getClass ("MPMediaEntity");
	__xamarin_class_map [11].handle = objc_getClass ("MPMediaItem");
	__xamarin_class_map [12].handle = objc_getClass ("MPMediaItemArtwork");
	__xamarin_class_map [13].handle = objc_getClass ("MPMediaQuery");
	__xamarin_class_map [14].handle = objc_getClass ("MPMoviePlayerController");
	__xamarin_class_map [15].handle = objc_getClass ("MPMediaItemCollection");
	__xamarin_class_map [16].handle = objc_getClass ("MPMoviePlayerViewController");
	__xamarin_class_map [17].handle = objc_getClass ("CMLogItem");
	__xamarin_class_map [18].handle = objc_getClass ("CMAccelerometerData");
	__xamarin_class_map [19].handle = objc_getClass ("CMAttitude");
	__xamarin_class_map [20].handle = objc_getClass ("CMDeviceMotion");
	__xamarin_class_map [21].handle = objc_getClass ("CMMotionManager");
	__xamarin_class_map [22].handle = objc_getClass ("CALayer");
	__xamarin_class_map [23].handle = objc_getClass ("CADisplayLink");
	__xamarin_class_map [24].handle = objc_getClass ("CALayerDelegate");
	__xamarin_class_map [25].handle = objc_getClass ("CAEAGLLayer");
	__xamarin_class_map [26].handle = objc_getClass ("UIPresentationController");
	__xamarin_class_map [27].handle = objc_getClass ("UIActivityViewController");
	__xamarin_class_map [28].handle = objc_getClass ("UIAppearance");
	__xamarin_class_map [29].handle = objc_getClass ("UIApplication");
	__xamarin_class_map [30].handle = objc_getClass ("UIColor");
	__xamarin_class_map [31].handle = objc_getClass ("UIKit_UIControlEventProxy");
	__xamarin_class_map [32].handle = objc_getClass ("UIView");
	__xamarin_class_map [33].handle = objc_getClass ("UIControl");
	__xamarin_class_map [34].handle = objc_getClass ("UIDevice");
	__xamarin_class_map [35].handle = objc_getClass ("UIEvent");
	__xamarin_class_map [36].handle = objc_getClass ("UIFont");
	__xamarin_class_map [37].handle = objc_getClass ("UIImage");
	__xamarin_class_map [38].handle = objc_getClass ("UIPopoverPresentationController");
	__xamarin_class_map [39].handle = objc_getClass ("UIScreen");
	__xamarin_class_map [40].handle = objc_getClass ("UITextField");
	__xamarin_class_map [41].handle = objc_getClass ("UITraitCollection");
	__xamarin_class_map [42].handle = objc_getClass ("UIWindow");
	__xamarin_class_map [43].handle = objc_getClass ("NSParagraphStyle");
	__xamarin_class_map [44].handle = objc_getClass ("NSMutableParagraphStyle");
	__xamarin_class_map [45].handle = objc_getClass ("UIActivity");
	__xamarin_class_map [46].handle = objc_getClass ("UITextFieldDelegate");
	__xamarin_class_map [47].handle = objc_getClass ("UITouch");
	__xamarin_class_map [48].handle = objc_getClass ("UIUserNotificationSettings");
	__xamarin_class_map [49].handle = objc_getClass ("NSArray");
	__xamarin_class_map [50].handle = objc_getClass ("NSAttributedString");
	__xamarin_class_map [51].handle = objc_getClass ("NSBundle");
	__xamarin_class_map [52].handle = objc_getClass ("NSCoder");
	__xamarin_class_map [53].handle = objc_getClass ("NSDate");
	__xamarin_class_map [54].handle = objc_getClass ("NSMutableArray");
	__xamarin_class_map [55].handle = objc_getClass ("Foundation_InternalNSNotificationHandler");
	__xamarin_class_map [56].handle = objc_getClass ("NSNull");
	__xamarin_class_map [57].handle = objc_getClass ("NSRunLoop");
	__xamarin_class_map [58].handle = objc_getClass ("NSString");
	__xamarin_class_map [59].handle = objc_getClass ("NSTimer");
	__xamarin_class_map [60].handle = objc_getClass ("NSURL");
	__xamarin_class_map [61].handle = objc_getClass ("NSUserDefaults");
	__xamarin_class_map [62].handle = objc_getClass ("NSUUID");
	__xamarin_class_map [63].handle = objc_getClass ("Foundation_NSDispatcher");
	__xamarin_class_map [64].handle = objc_getClass ("__MonoMac_NSActionDispatcher");
	__xamarin_class_map [65].handle = objc_getClass ("__MonoMac_NSSynchronizationContextDispatcher");
	__xamarin_class_map [66].handle = objc_getClass ("__Xamarin_NSTimerActionDispatcher");
	__xamarin_class_map [67].handle = objc_getClass ("Foundation_NSAsyncDispatcher");
	__xamarin_class_map [68].handle = objc_getClass ("__MonoMac_NSAsyncActionDispatcher");
	__xamarin_class_map [69].handle = objc_getClass ("__MonoMac_NSAsyncSynchronizationContextDispatcher");
	__xamarin_class_map [70].handle = objc_getClass ("NSAutoreleasePool");
	__xamarin_class_map [71].handle = objc_getClass ("NSError");
	__xamarin_class_map [72].handle = objc_getClass ("NSValue");
	__xamarin_class_map [73].handle = objc_getClass ("NSNumber");
	__xamarin_class_map [74].handle = objc_getClass ("NSDecimalNumber");
	__xamarin_class_map [75].handle = objc_getClass ("NSEnumerator");
	__xamarin_class_map [76].handle = objc_getClass ("NSException");
	__xamarin_class_map [77].handle = objc_getClass ("NSNotification");
	__xamarin_class_map [78].handle = objc_getClass ("NSOperationQueue");
	__xamarin_class_map [79].handle = objc_getClass ("NSProcessInfo");
	__xamarin_class_map [80].handle = objc_getClass ("NSStringDrawingContext");
	__xamarin_class_map [81].handle = objc_getClass ("AVAudioPlayer");
	__xamarin_class_map [82].handle = objc_getClass ("AVPlayer");
	__xamarin_class_map [83].handle = objc_getClass ("UIAlertView");
	__xamarin_class_map [84].handle = objc_getClass ("NSData");
	__xamarin_class_map [85].handle = objc_getClass ("NSDictionary");
	__xamarin_class_map [86].handle = objc_getClass ("NSMutableData");
	__xamarin_class_map [87].handle = objc_getClass ("NSMutableDictionary");
	__xamarin_class_map [88].handle = objc_getClass ("NSNotificationCenter");
	__xamarin_class_map [89].handle = objc_getClass ("NSSet");
	__xamarin_class_map [90].handle = objc_getClass ("AVAudioSession");
	__xamarin_class_map [91].handle = objc_getClass ("AVPlayerItem");
	__xamarin_class_map [92].handle = [CC_Mobile_Purchases_CustomPaymentObserver class];
	__xamarin_class_map [93].handle = [AppDelegate class];
	__xamarin_class_map [94].handle = [ViewController class];
	__xamarin_class_map [95].handle = objc_getClass ("UIKit_UIAlertView__UIAlertViewDelegate");
	__xamarin_class_map [96].handle = objc_getClass ("UIKit_UIView_UIViewAppearance");
	__xamarin_class_map [97].handle = objc_getClass ("__NSObject_Disposer");
	__xamarin_class_map [98].handle = [OpenTK_Platform_iPhoneOS_iPhoneOSGameView class];
	__xamarin_class_map [99].handle = [CCGameView class];
	__xamarin_class_map [100].handle = [CocosSharp_IMEKeyboardImpl_HiddenInputDelegate class];
	__xamarin_class_map [101].handle = [CocosSharp_IMEKeyboardImpl_HiddenInput class];
	__xamarin_class_map [102].handle = [Microsoft_Xna_Framework_iOSGameViewController class];
	__xamarin_class_map [103].handle = [iOSGameView class];
	__xamarin_class_map [104].handle = [OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource class];
	__xamarin_class_map [105].handle = [GADNativeAd class];
	__xamarin_class_map [106].handle = [GADNativeCustomTemplateAd class];
	__xamarin_class_map [107].handle = [GADRequest class];
	__xamarin_class_map [108].handle = [GADRequestError class];
	__xamarin_class_map [109].handle = [GADAdLoader class];
	__xamarin_class_map [110].handle = [GADAdLoaderDelegate class];
	__xamarin_class_map [111].handle = [GADAdLoaderOptions class];
	__xamarin_class_map [112].handle = [GADAdNetworkExtras class];
	__xamarin_class_map [113].handle = [GADAdReward class];
	__xamarin_class_map [114].handle = [GADAdSizeDelegate class];
	__xamarin_class_map [115].handle = [GADAppEventDelegate class];
	__xamarin_class_map [116].handle = [GADAudioVideoManagerDelegate class];
	__xamarin_class_map [117].handle = [GADBannerViewDelegate class];
	__xamarin_class_map [118].handle = [GADCorrelator class];
	__xamarin_class_map [119].handle = [GADCorrelatorAdLoaderOptions class];
	__xamarin_class_map [120].handle = [GADCustomEventBannerDelegate class];
	__xamarin_class_map [121].handle = [GADCustomEventExtras class];
	__xamarin_class_map [122].handle = [GADCustomEventInterstitialDelegate class];
	__xamarin_class_map [123].handle = [GADCustomEventNativeAd class];
	__xamarin_class_map [124].handle = [GADCustomEventNativeAdDelegate class];
	__xamarin_class_map [125].handle = [GADCustomEventRequest class];
	__xamarin_class_map [126].handle = [GADDebugOptionsViewController class];
	__xamarin_class_map [127].handle = [GADDebugOptionsViewControllerDelegate class];
	__xamarin_class_map [128].handle = [GADDefaultInAppPurchase class];
	__xamarin_class_map [129].handle = [GADDefaultInAppPurchaseDelegate class];
	__xamarin_class_map [130].handle = [GADDynamicHeightSearchRequest class];
	__xamarin_class_map [131].handle = [GADExtras class];
	__xamarin_class_map [132].handle = [GADInAppPurchase class];
	__xamarin_class_map [133].handle = [GADInAppPurchaseDelegate class];
	__xamarin_class_map [134].handle = [GADInterstitialDelegate class];
	__xamarin_class_map [135].handle = [Google_MobileAds_MediatedNativeAd class];
	__xamarin_class_map [136].handle = [GADMediatedNativeAdDelegate class];
	__xamarin_class_map [137].handle = [GADMediatedNativeAdNotificationSource class];
	__xamarin_class_map [138].handle = [GADMediatedNativeAppInstallAd class];
	__xamarin_class_map [139].handle = [GADMediatedNativeContentAd class];
	__xamarin_class_map [140].handle = [GADMediaView class];
	__xamarin_class_map [141].handle = [GADMobileAds class];
	__xamarin_class_map [142].handle = [GADMultipleAdsAdLoaderOptions class];
	__xamarin_class_map [143].handle = [GADNativeAdDelegate class];
	__xamarin_class_map [144].handle = [GADNativeAdImage class];
	__xamarin_class_map [145].handle = [GADNativeAdImageAdLoaderOptions class];
	__xamarin_class_map [146].handle = [GADNativeAdViewAdOptions class];
	__xamarin_class_map [147].handle = [GADNativeAppInstallAd class];
	__xamarin_class_map [148].handle = [GADNativeAppInstallAdLoaderDelegate class];
	__xamarin_class_map [149].handle = [GADNativeContentAd class];
	__xamarin_class_map [150].handle = [GADNativeContentAdLoaderDelegate class];
	__xamarin_class_map [151].handle = [GADNativeCustomTemplateAdLoaderDelegate class];
	__xamarin_class_map [152].handle = [GADNativeExpressAdViewDelegate class];
	__xamarin_class_map [153].handle = [GADRewardBasedVideoAdDelegate class];
	__xamarin_class_map [154].handle = [GADSearchRequest class];
	__xamarin_class_map [155].handle = [GADSwipeableBannerViewDelegate class];
	__xamarin_class_map [156].handle = [GADVideoControllerDelegate class];
	__xamarin_class_map [157].handle = [GADVideoOptions class];
	__xamarin_class_map [158].handle = [DFPBannerAdLoaderDelegate class];
	__xamarin_class_map [159].handle = [DFPBannerViewOptions class];
	__xamarin_class_map [160].handle = [DFPCustomRenderedAd class];
	__xamarin_class_map [161].handle = [DFPCustomRenderedBannerViewDelegate class];
	__xamarin_class_map [162].handle = [DFPCustomRenderedInterstitialDelegate class];
	__xamarin_class_map [163].handle = [DFPRequest class];
	__xamarin_class_map [164].handle = [Google_MobileAds_RewardBasedVideoAd__RewardBasedVideoAdDelegate class];
	__xamarin_class_map [165].handle = [GADRewardBasedVideoAd class];
	__xamarin_class_map [166].handle = [Google_MobileAds_AdChoicesView_AdChoicesViewAppearance class];
	__xamarin_class_map [167].handle = [GADAdChoicesView class];
	__xamarin_class_map [168].handle = [Google_MobileAds_AudioVideoManager__AudioVideoManagerDelegate class];
	__xamarin_class_map [169].handle = [GADAudioVideoManager class];
	__xamarin_class_map [170].handle = [Google_MobileAds_BannerView__BannerViewDelegate class];
	__xamarin_class_map [171].handle = [Google_MobileAds_BannerView__AdSizeDelegate class];
	__xamarin_class_map [172].handle = [Google_MobileAds_BannerView_BannerViewAppearance class];
	__xamarin_class_map [173].handle = [GADBannerView class];
	__xamarin_class_map [174].handle = [Google_MobileAds_Interstitial__InterstitialDelegate class];
	__xamarin_class_map [175].handle = [GADInterstitial class];
	__xamarin_class_map [176].handle = [Google_MobileAds_NativeAd__NativeAdDelegate class];
	__xamarin_class_map [177].handle = [Google_MobileAds_NativeAppInstallAdView_NativeAppInstallAdViewAppearance class];
	__xamarin_class_map [178].handle = [GADNativeAppInstallAdView class];
	__xamarin_class_map [179].handle = [Google_MobileAds_NativeContentAdView_NativeContentAdViewAppearance class];
	__xamarin_class_map [180].handle = [GADNativeContentAdView class];
	__xamarin_class_map [181].handle = [Google_MobileAds_NativeExpressAdView__NativeExpressAdViewDelegate class];
	__xamarin_class_map [182].handle = [Google_MobileAds_NativeExpressAdView_NativeExpressAdViewAppearance class];
	__xamarin_class_map [183].handle = [GADNativeExpressAdView class];
	__xamarin_class_map [184].handle = [Google_MobileAds_SearchBannerView_SearchBannerViewAppearance class];
	__xamarin_class_map [185].handle = [GADSearchBannerView class];
	__xamarin_class_map [186].handle = [Google_MobileAds_VideoController__VideoControllerDelegate class];
	__xamarin_class_map [187].handle = [GADVideoController class];
	__xamarin_class_map [188].handle = [Google_MobileAds_DoubleClick_BannerView__AdSizeDelegate class];
	__xamarin_class_map [189].handle = [Google_MobileAds_DoubleClick_BannerView_BannerViewAppearance class];
	__xamarin_class_map [190].handle = [DFPBannerView class];
	__xamarin_class_map [191].handle = [Google_MobileAds_DoubleClick_Interstitial__CustomRenderedInterstitialDelegate class];
	__xamarin_class_map [192].handle = [DFPInterstitial class];
	__xamarin_class_map [193].handle = [MSPushDelegate class];
	__xamarin_class_map [194].handle = [Microsoft_AppCenter_Push_iOS_PushDelegate class];
	__xamarin_class_map [195].handle = [MSPush class];
	__xamarin_class_map [196].handle = [MSPushNotification class];
	__xamarin_class_map [197].handle = [MSCrashesDelegate class];
	__xamarin_class_map [198].handle = [Microsoft_AppCenter_Crashes_Crashes_CrashesDelegate class];
	__xamarin_class_map [199].handle = [MSCrashes class];
	__xamarin_class_map [200].handle = [MSCrashHandlerSetupDelegate class];
	__xamarin_class_map [201].handle = [MSErrorAttachmentLog class];
	__xamarin_class_map [202].handle = [MSErrorReport class];
	__xamarin_class_map [203].handle = [MSException class];
	__xamarin_class_map [204].handle = [MSStackFrame class];
	__xamarin_class_map [205].handle = [MSWrapperCrashesHelper class];
	__xamarin_class_map [206].handle = [MSWrapperException class];
	__xamarin_class_map [207].handle = [MSWrapperExceptionManager class];
	__xamarin_class_map [208].handle = [Microsoft_AppCenter_Crashes_iOS_Bindings_CrashesInitializationDelegate class];
	__xamarin_class_map [209].handle = [MSAppCenter class];
	__xamarin_class_map [210].handle = [MSCustomProperties class];
	__xamarin_class_map [211].handle = [MSWrapperSdk class];
	__xamarin_class_map [212].handle = [MSDevice class];
	__xamarin_class_map [213].handle = [MSLogger class];
	__xamarin_class_map [214].handle = [MSService class];
	__xamarin_class_map [215].handle = [MSServiceAbstract class];
	__xamarin_class_map [216].handle = [MSWrapperLogger class];
	__xamarin_class_map [217].handle = [MSAnalytics class];
	__xamarin_class_map [218].handle = [MSAnalyticsDelegate class];
	__xamarin_class_map [219].handle = [MSLogWithProperties class];
	__xamarin_class_map [220].handle = [MSEventLog class];
	__xamarin_class_map [221].handle = [MSPageLog class];
	xamarin_add_registration_map (&__xamarin_registration_map);
}


} /* extern "C" */
