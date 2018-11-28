
using System.IO;
using System;

namespace UnrealBuildTool.Rules
{
    public class PCL : ModuleRules
    {
        private string ModulePath
        {
            get { return ModuleDirectory; }
        }

        private string BinariesPath
        {
            get { return Path.GetFullPath(Path.Combine(ModulePath, "../Binaries/")); }
        }

        public PCL(ReadOnlyTargetRules Target) : base(Target)
        {
            // Tell Unreal that this Module only imports Third-Party-Assets
            Type = ModuleType.External;

            LoadPCL(Target);
        }

        public bool LoadPCL(ReadOnlyTargetRules Target)
        {
            bool isLibrarySupported = false;
            //bool bDebug = (Target.Configuration == UnrealTargetConfiguration.Debug && BuildConfiguration.bDebugBuildsActuallyUseDebugCRT);

            if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                isLibrarySupported = true;

                //string PlatformString = (Target.Platform == UnrealTargetPlatform.Win64) ? "x64" : "x86";

                // Explicitly name the used libraries
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_chrono-vc141-mt-1_64.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_date_time-vc141-mt-1_64.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_filesystem-vc141-mt-1_64.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_iostreams-vc141-mt-1_64.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_system-vc141-mt-1_64.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "Boost/lib/libboost_thread-vc141-mt-1_64.lib"));



                string PCLDirectory = Path.Combine(ModulePath, "PCL/bin/");
                string[] dlls = Directory.GetFiles(PCLDirectory, "*.dll");
                for (int i = 0; i < dlls.Length; i++)
                {
                    RuntimeDependencies.Add(new RuntimeDependency(Path.Combine(PCLDirectory, dlls[i])));
                }
                PCLDirectory = Path.Combine(ModulePath, "PCL/lib/");
				string[] libs = Directory.GetFiles(PCLDirectory, "*.lib");
                for (int i = 0; i < libs.Length; i++)
                {
                    PublicAdditionalLibraries.Add(Path.Combine(PCLDirectory, libs[i]));
                }


                //PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "FLANN/lib/flann_s.lib"));
                //PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "FLANN/lib/flann.lib"));
                PublicAdditionalLibraries.Add(Path.Combine(ModulePath, "FLANN/lib/flann_cpp_s.lib"));
            }

            if (isLibrarySupported)
            {
                PublicIncludePaths.Add(Path.Combine(ModulePath, "Eigen/eigen3"));
                PublicIncludePaths.Add(Path.Combine(ModulePath, "Boost/include/boost-1_64"));
                PublicIncludePaths.Add(Path.Combine(ModulePath, "PCL/include/pcl-1.9"));
                PublicIncludePaths.Add(Path.Combine(ModulePath, "FLANN/include"));
                PublicIncludePaths.Add(Path.Combine(ModulePath, "EFANNA/include"));
                //PublicIncludePaths.Add(Path.Combine(ModulePath, "VTK/include/vtk-8.0"));

                // Not sure if needed
                PublicDefinitions.Add("_CRT_SECURE_NO_WARNINGS");
                PublicDefinitions.Add("BOOST_DISABLE_ABI_HEADERS");
                //Definitions.Add("BOOST_NO_RTTI");

                // Needed configurations in order to run Boost
                bUseRTTI = true;
                bEnableExceptions = true;
                //bEnableUndefinedIdentifierWarnings = false;
            }

            PublicDefinitions.Add(string.Format("WITH_PCL_BINDING={0}", isLibrarySupported ? 1 : 0));
            PublicDefinitions.Add(string.Format("WITH_BOOST_BINDING={0}", isLibrarySupported ? 1 : 0));
            PublicDefinitions.Add(string.Format("WITH_FLANN_BINDING={0}", isLibrarySupported ? 1 : 0));

            //#ToDo: Überarbeiten !!

            return isLibrarySupported;
        }
    }
}
