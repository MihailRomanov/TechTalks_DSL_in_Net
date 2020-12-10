#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"SKB Kontur")]
[assembly: AssemblyProduct(@"NHModelingLanguage")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"SKBKontur.NHModelingLanguage.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100153D9A0881BEB1E1DD5FA8659A5CDF37A61CE4F6717D2146EA12EB6CB46C7252A08B841699A01F44FDBA933368FB2EC5A999554DBE0988A4CAA727F4D46794E3505253539A99883EB56682C3DD7A1EE1A9B7B102E28AA8E0BF575EC5C0CC6AA377F3ABF55D1589E89FFF97D32E88BE725D281134D2D26CCF7E8ECA13C4B8AFBF")]