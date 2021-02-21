wget https://download.visualstudio.microsoft.com/download/pr/820db713-c9a5-466e-b72a-16f2f5ed00e2/628aa2a75f6aa270e77f4a83b3742fb8/dotnet-sdk-5.0.100-linux-x64.tar.gz            shift
            uncached_feed="$1"
            non_dynamic_parameters+=" $name "\""$1"\"""
            ;;
        --feed-credential|-[Ff]eed[Cc]redential)
            shift
            feed_credential="$1"
            non_dynamic_parameters+=" $name "\""$1"\"""
            ;;
        --runtime-id|-[Rr]untime[Ii]d)
            shift
            runtime_id="$1"
            non_dynamic_parameters+=" $name "\""$1"\"""
            say_warning "Use of --runtime-id is obsolete and should be limited to the versions below 2.1. To override architecture, use --architecture option instead. To override OS, use --os option instead."
            ;;
        --jsonfile|-[Jj][Ss]on[Ff]ile)
            shift
            json_file="$1"
            ;;
        --skip-non-versioned-files|-[Ss]kip[Nn]on[Vv]ersioned[Ff]iles)
            override_non_versioned_files=false
            non_dynamic_parameters+=" $name"
            ;;
        -?|--?|-h|--help|-[Hh]elp)
            script_name="$(basename "$0")"
            echo ".NET Tools Installer"
            echo "Usage: $script_name [-c|--channel <CHANNEL>] [-v|--version <VERSION>] [-p|--prefix <DESTINATION>]"
            echo "       $script_name -h|-?|--help"
            echo ""
            echo "$script_name is a simple command line interface for obtaining dotnet cli."
            echo ""
            echo "Options:"
            echo "  -c,--channel <CHANNEL>         Download from the channel specified, Defaults to \`$channel\`."
            echo "      -Channel"
            echo "          Possible values:"
            echo "          - Current - most current release"
            echo "          - LTS - most current supported release"
            echo "          - 2-part version in a format A.B - represents a specific release"
            echo "              examples: 2.0; 1.0"
            echo "          - Branch name"
            echo "              examples: release/2.0.0; Master"
            echo "          Note: The version parameter overrides the channel parameter."
            echo "  -v,--version <VERSION>         Use specific VERSION, Defaults to \`$version\`."
            echo "      -Version"
            echo "          Possible values:"
            echo "          - latest - most latest build on specific channel"
            echo "          - 3-part version in a format A.B.C - represents specific version of build"
            echo "              examples: 2.0.0-preview2-006120; 1.1.0"
            echo "  -i,--install-dir <DIR>             Install under specified location (see Install Location below)"
            echo "      -InstallDir"
            echo "  --architecture <ARCHITECTURE>      Architecture of dotnet binaries to be installed, Defaults to \`$architecture\`."
            echo "      --arch,-Architecture,-Arch"
            echo "          Possible values: x64, arm, and arm64"
            echo "  --os <system>                    Specifies operating system to be used when selecting the installer."
            echo "          Overrides the OS determination approach used by the script. Supported values: osx, linux, linux-musl, freebsd, rhel.6."
            echo "          In case any other value is provided, the platform will be determined by the script based on machine configuration."
            echo ""


mkdir dotnet
tar zxf dotnet-sdk-5.0.100-linux-x64.tar.gz -C /dotnet