// Copyright (c) 2012-2021 Wojciech Figat. All rights reserved.

using System.IO;
using Flax.Build;
using Flax.Build.NativeCpp;

/// <summary>
/// https://github.com/xiph/vorbis
/// </summary>
public class vorbis : DepsModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        LicenseType = LicenseTypes.Custom;
        LicenseFilePath = "COPYING";
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        var depsRoot = options.DepsFolder;
        switch (options.Platform.Target)
        {
        case TargetPlatform.Windows:
        case TargetPlatform.UWP:
        case TargetPlatform.XboxOne:
        case TargetPlatform.XboxScarlett:
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbis_static.lib"));
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbisfile_static.lib"));
            options.OptionalDependencyFiles.Add(Path.Combine(depsRoot, "libvorbis_static.pdb"));
            options.OptionalDependencyFiles.Add(Path.Combine(depsRoot, "libvorbisfile.pdb"));
            break;
        case TargetPlatform.Linux:
        case TargetPlatform.Android:
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbis.a"));
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbisenc.a"));
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbisfile.a"));
            break;
        case TargetPlatform.PS4:
            options.OutputFiles.Add(Path.Combine(depsRoot, "libvorbis.a"));
            break;
        default: throw new InvalidPlatformException(options.Platform.Target);
        }
    }
}
