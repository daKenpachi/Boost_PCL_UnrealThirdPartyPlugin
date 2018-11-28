/* pcl_config.h. Generated by CMake for PCL. */

#define BUILD_RelWithDebInfo
/* PCL version information */
#define PCL_MAJOR_VERSION 1
#define PCL_MINOR_VERSION 9
#define PCL_REVISION_VERSION 1
#define PCL_DEV_VERSION 0
#define PCL_VERSION_PRETTY "1.9.1"
#define PCL_VERSION_CALC(MAJ, MIN, PATCH) (MAJ*100000+MIN*100+PATCH)
#define PCL_VERSION \
    PCL_VERSION_CALC(PCL_MAJOR_VERSION, PCL_MINOR_VERSION, PCL_REVISION_VERSION)
#define PCL_VERSION_COMPARE(OP, MAJ, MIN, PATCH) \
    (PCL_VERSION*10+PCL_DEV_VERSION OP PCL_VERSION_CALC(MAJ, MIN, PATCH)*10)

/* #undef HAVE_TBB */

/* #undef HAVE_OPENNI */

/* #undef HAVE_OPENNI2 */

/* #undef HAVE_QHULL */

/* #undef HAVE_QHULL_2011 */

#define HAVE_CUDA 1

/* #undef HAVE_FZAPI */

/* #undef HAVE_ENSENSO */

/* #undef HAVE_DAVIDSDK */

// SSE macros
/* #undef HAVE_POSIX_MEMALIGN */
/* #undef HAVE_MM_MALLOC */
#define HAVE_SSE4_2_EXTENSIONS
#define HAVE_SSE4_1_EXTENSIONS
#define HAVE_SSSE3_EXTENSIONS
#define HAVE_SSE3_EXTENSIONS
#define HAVE_SSE2_EXTENSIONS
#define HAVE_SSE_EXTENSIONS

/* #undef HAVE_PNG */

/* Precompile for a minimal set of point types instead of all. */
/* #undef PCL_ONLY_CORE_POINT_TYPES */

/* Do not precompile for any point types at all. */
/* #undef PCL_NO_PRECOMPILE */

#ifdef DISABLE_OPENNI
#undef HAVE_OPENNI
#endif

#ifdef DISABLE_OPENNI2
#undef HAVE_OPENNI2
#endif

#ifdef DISABLE_QHULL
#undef HAVE_QHULL
#endif

/* Verbosity level defined by user through ccmake. */
/* #undef VERBOSITY_LEVEL_ALWAYS */
/* #undef VERBOSITY_LEVEL_ERROR */
/* #undef VERBOSITY_LEVEL_WARN */
#define VERBOSITY_LEVEL_INFO
/* #undef VERBOSITY_LEVEL_DEBUG */
/* #undef VERBOSITY_LEVEL_VERBOSE */

/* Address the cases where on MacOS and OpenGL and GLUT are not frameworks */
/* #undef OPENGL_IS_A_FRAMEWORK */
/* #undef GLUT_IS_A_FRAMEWORK */

/* Version of OpenGL used by VTK as rendering backend */
#define VTK_RENDERING_BACKEND_OPENGL_VERSION 

