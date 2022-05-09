using System.Collections.Generic;

class ModData
{
    public static Dictionary<string, HashSet<string>> VersionData = new Dictionary<string, HashSet<string>>
    {
        ["Current"] = new HashSet<string>
        {
            "System.Collections.*, mscorlib",
            "System.Collections.Generic.*, System.Core",
            "System.Collections.Generic.*, System",
            "System.Collections.Generic.*, mscorlib",
            "System.Text.*, mscorlib",
            "System.Text.RegularExpressions.*, System",
            "System.Globalization.*, mscorlib",
            "System.Linq.*, System.Core",
            "System.Collections.Concurrent.*, System",
            "System.Collections.Concurrent.*, mscorlib",
            "System.Timers.*, System",
            "System.Diagnostics.TraceEventType+*, System",
            "System.Reflection.AssemblyProductAttribute+*, mscorlib",
            "System.Reflection.AssemblyDescriptionAttribute+*, mscorlib",
            "System.Reflection.AssemblyConfigurationAttribute+*, mscorlib",
            "System.Reflection.AssemblyCompanyAttribute+*, mscorlib",
            "System.Reflection.AssemblyCultureAttribute+*, mscorlib",
            "System.Reflection.AssemblyVersionAttribute+*, mscorlib",
            "System.Reflection.AssemblyFileVersionAttribute+*, mscorlib",
            "System.Reflection.AssemblyCopyrightAttribute+*, mscorlib",
            "System.Reflection.AssemblyTrademarkAttribute+*, mscorlib",
            "System.Reflection.AssemblyTitleAttribute+*, mscorlib",
            "System.Runtime.InteropServices.ComVisibleAttribute+*, mscorlib",
            "System.ComponentModel.DefaultValueAttribute+*, System",
            "System.SerializableAttribute+*, mscorlib",
            "System.Runtime.InteropServices.GuidAttribute+*, mscorlib",
            "System.Runtime.InteropServices.StructLayoutAttribute+*, mscorlib",
            "System.Runtime.InteropServices.LayoutKind+*, mscorlib",
            "System.Guid+*, mscorlib",
            "object+*, mscorlib",
            "System.IDisposable+*, mscorlib",
            "string+*, mscorlib",
            "System.StringComparison+*, mscorlib",
            "System.Math+*, mscorlib",
            "System.Enum+*, mscorlib",
            "int+*, mscorlib",
            "short+*, mscorlib",
            "long+*, mscorlib",
            "uint+*, mscorlib",
            "ushort+*, mscorlib",
            "ulong+*, mscorlib",
            "double+*, mscorlib",
            "float+*, mscorlib",
            "bool+*, mscorlib",
            "char+*, mscorlib",
            "byte+*, mscorlib",
            "sbyte+*, mscorlib",
            "decimal+*, mscorlib",
            "System.DateTime+*, mscorlib",
            "System.TimeSpan+*, mscorlib",
            "System.Array+*, mscorlib",
            "System.Xml.Serialization.XmlElementAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlAttributeAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlArrayAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlArrayItemAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlAnyAttributeAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlAnyElementAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlAnyElementAttributes+*, System.Xml",
            "System.Xml.Serialization.XmlArrayItemAttributes+*, System.Xml",
            "System.Xml.Serialization.XmlAttributeEventArgs+*, System.Xml",
            "System.Xml.Serialization.XmlAttributeOverrides+*, System.Xml",
            "System.Xml.Serialization.XmlAttributes+*, System.Xml",
            "System.Xml.Serialization.XmlChoiceIdentifierAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlElementAttributes+*, System.Xml",
            "System.Xml.Serialization.XmlElementEventArgs+*, System.Xml",
            "System.Xml.Serialization.XmlEnumAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlIgnoreAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlIncludeAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlRootAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlTextAttribute+*, System.Xml",
            "System.Xml.Serialization.XmlTypeAttribute+*, System.Xml",
            "System.Runtime.CompilerServices.RuntimeHelpers+*, mscorlib",
            "System.IO.BinaryReader+*, mscorlib",
            "System.IO.BinaryWriter+*, mscorlib",
            "System.NullReferenceException+*, mscorlib",
            "System.ArgumentException+*, mscorlib",
            "System.ArgumentNullException+*, mscorlib",
            "System.InvalidOperationException+*, mscorlib",
            "System.FormatException+*, mscorlib",
            "System.Exception+*, mscorlib",
            "System.DivideByZeroException+*, mscorlib",
            "System.InvalidCastException+*, mscorlib",
            "System.IO.FileNotFoundException+*, mscorlib",
            "System.NotSupportedException+*, mscorlib",
            "System.Nullable<T>+*, mscorlib",
            "System.StringComparer+*, mscorlib",
            "System.IEquatable<T>+*, mscorlib",
            "System.IComparable+*, mscorlib",
            "System.IComparable<T>+*, mscorlib",
            "System.BitConverter+*, mscorlib",
            "System.FlagsAttribute+*, mscorlib",
            "System.IO.Path+*, mscorlib",
            "System.Random+*, mscorlib",
            "System.Convert+*, mscorlib",
            "System.StringSplitOptions+*, mscorlib",
            "System.DateTimeKind+*, mscorlib",
            "System.MidpointRounding+*, mscorlib",
            "System.EventArgs+*, mscorlib",
            "System.Buffer+*, mscorlib",
            "System.ComponentModel.INotifyPropertyChanging+*, System",
            "System.ComponentModel.PropertyChangingEventHandler+*, System",
            "System.ComponentModel.PropertyChangingEventArgs+*, System",
            "System.ComponentModel.INotifyPropertyChanged+*, System",
            "System.ComponentModel.PropertyChangedEventHandler+*, System",
            "System.ComponentModel.PropertyChangedEventArgs+*, System",
            "System.IO.Stream+*, mscorlib",
            "System.IO.TextWriter+*, mscorlib",
            "System.IO.TextReader+*, mscorlib",
            "System.Reflection.MemberInfo, mscorlib",
            "System.Reflection.MemberInfo.Name, mscorlib",
            "System.Type, mscorlib",
            "System.Type.FullName, mscorlib",
            "System.Type.GetTypeFromHandle(System.RuntimeTypeHandle), mscorlib",
            "System.Type.GetFields(System.Reflection.BindingFlags), mscorlib",
            "System.Type.IsEquivalentTo(System.Type), mscorlib",
            "System.Type.operator ==(System.Type, System.Type), mscorlib",
            "System.Type.ToString(), mscorlib",
            "System.ValueType, mscorlib",
            "System.ValueType.Equals(object), mscorlib",
            "System.ValueType.GetHashCode(), mscorlib",
            "System.ValueType.ToString(), mscorlib",
            "System.Environment, mscorlib",
            "System.Environment.CurrentManagedThreadId, mscorlib",
            "System.Environment.NewLine, mscorlib",
            "System.Environment.ProcessorCount, mscorlib",
            "System.RuntimeType, mscorlib",
            "System.RuntimeType.operator !=(System.RuntimeType, System.RuntimeType), mscorlib",
            "System.RuntimeType.GetFields(System.Reflection.BindingFlags), mscorlib",
            "System.Delegate, mscorlib",
            "System.Delegate.Combine(System.Delegate, System.Delegate), mscorlib",
            "System.Delegate.DynamicInvoke(params object[]), mscorlib",
            "System.Delegate.Equals(object), mscorlib",
            "System.Delegate.GetHashCode(), mscorlib",
            "System.Delegate.Combine(params System.Delegate[]), mscorlib",
            "System.Delegate.GetInvocationList(), mscorlib",
            "System.Delegate.Remove(System.Delegate, System.Delegate), mscorlib",
            "System.Delegate.RemoveAll(System.Delegate, System.Delegate), mscorlib",
            "System.Delegate.Clone(), mscorlib",
            "System.Delegate.operator ==(System.Delegate, System.Delegate), mscorlib",
            "System.Delegate.operator !=(System.Delegate, System.Delegate), mscorlib",
            "System.Delegate.GetObjectData(System.Runtime.Serialization.SerializationInfo, System.Runtime.Serialization.StreamingContext), mscorlib",
            "System.Delegate.Method, mscorlib",
            "System.Delegate.Target, mscorlib",
            "System.Action+*, mscorlib",
            "System.Action<T>+*, mscorlib",
            "System.Action<T1, T2>+*, mscorlib",
            "System.Action<T1, T2, T3>+*, mscorlib",
            "System.Action<T1, T2, T3, T4>+*, mscorlib",
            "System.Action<T1, T2, T3, T4, T5>+*, mscorlib",
            "System.Action<T1, T2, T3, T4, T5, T6>+*, mscorlib",
            "System.Action<T1, T2, T3, T4, T5, T6, T7>+*, mscorlib",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8>+*, mscorlib",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>+*, System.Core",
            "System.Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>+*, System.Core",
            "System.Func<TResult>+*, mscorlib",
            "System.Func<T, TResult>+*, mscorlib",
            "System.Func<T1, T2, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, T5, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, T5, T6, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>+*, mscorlib",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>+*, System.Core",
            "System.Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>+*, System.Core",
            "SpaceEngineers.Game.ModAPI.Ingame.*, SpaceEngineers.Game",
            "SpaceEngineers.Game.ModAPI.Ingame.*, SpaceEngineers.ObjectBuilders",
            "SpaceEngineers.Game.ModAPI.*, SpaceEngineers.Game",
            "SpaceEngineers.Game.Definitions.SafeZone.*, SpaceEngineers.Game",
            "Sandbox.Game.Entities.MyCubeBuilder, Sandbox.Game",
            "Sandbox.Game.Entities.MyCubeBuilder.Static, Sandbox.Game",
            "Sandbox.Game.Entities.MyCubeBuilder.CubeBuilderState, Sandbox.Game",
            "Sandbox.Game.Entities.Cube.CubeBuilder.MyCubeBuilderState, Sandbox.Game",
            "Sandbox.Game.Entities.Cube.CubeBuilder.MyCubeBuilderState.CurrentBlockDefinition, Sandbox.Game",
            "Sandbox.Game.Gui.MyHud, Sandbox.Game",
            "Sandbox.Game.Gui.MyHud.BlockInfo, Sandbox.Game",
            "Sandbox.Game.Gui.MyHudBlockInfo+*, Sandbox.Game",
            "Sandbox.Game.Gui.MyHudBlockInfo.ComponentInfo+*, Sandbox.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.MyObjectBuilder_CubeBuilderDefinition+*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.MyPlacementSettings+*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.MyGridPlacementSettings+*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.SnapMode+*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.VoxelPlacementMode+*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.SessionComponents.VoxelPlacementSettings+*, VRage.Game",
            "System.Collections.Generic.*, VRage.Library",
            "VRage.Game.ModAPI.Ingame.*, VRage.Game",
            "VRage.Game.ModAPI.Ingame.Utilities.*, VRage.Game",
            "Sandbox.ModAPI.Ingame.*, Sandbox.Common",
            "VRageMath.*, VRage.Math",
            "VRage.Game.GUI.TextPanel.*, VRage.Game",
            "Sandbox.ModAPI.*, Sandbox.Game",
            "Sandbox.ModAPI.Interfaces.*, Sandbox.Common",
            "Sandbox.ModAPI.Interfaces.Terminal.*, Sandbox.Common",
            "VRage.Game.ModAPI.*, VRage.Game",
            "Sandbox.ModAPI.*, Sandbox.Common",
            "VRage.Game.ModAPI.Interfaces.*, VRage.Game",
            "VRage.ModAPI.*, VRage.Game",
            "VRage.Game.Entity.*, VRage.Game",
            "Sandbox.Game.Entities.*, Sandbox.Game",
            "VRage.Game.*, VRage.Game",
            "VRage.Game.ObjectBuilders.Definitions.*, VRage.Game",
            "Sandbox.Common.ObjectBuilders.*, SpaceEngineers.ObjectBuilders",
            "Sandbox.Common.ObjectBuilders.Definitions.*, VRage.Game",
            "Sandbox.Common.ObjectBuilders.Definitions.*, SpaceEngineers.ObjectBuilders",
            "VRage.Game.ObjectBuilders.ComponentSystem.*, VRage.Game",
            "VRage.ObjectBuilders.*, VRage.Game",
            "VRage.Game.Components.*, VRage.Game",
            "Sandbox.Game.EntityComponents.*, Sandbox.Game",
            "Sandbox.Game.Entities.Character.Components.*, Sandbox.Game",
            "VRage.Game.Entity.UseObject.*, VRage.Game",
            "VRage.Game.ModAPI.*, VRage.Render",
            "Sandbox.Game.GameSystems.TextSurfaceScripts.*, Sandbox.Game",
            "ObjectBuilders.SafeZone.*, SpaceEngineers.ObjectBuilders",
            "VRage.Game.Definitions.SessionComponents.*, VRage.Game",
            "VRage.Game.Definitions.*, VRage.Game",
            "VRage.Game.Definitions.Reputation.*, VRage.Game",
            "Sandbox.Definitions.GUI.*, Sandbox.Game",
            "VRageRender.MyBillboard.BlendTypeEnum+*, VRage.Render",
            "VRageRender.MyBillboard.LocalTypeEnum+*, VRage.Render",
            "VRageRender.MyBillboard+*, VRage.Render",
            "VRageRender.MyTriangleBillboard+*, VRage.Render",
            "VRageRender.Messages.MyDecalPositionUpdate+*, VRage.Render",
            "VRageRender.MyDecalRenderInfo+*, VRage.Render",
            "VRageRender.MyDecalBindingInfo+*, VRage.Render",
            "VRageRender.MyDecalFlags+*, VRage.Render",
            "VRage.Game.ObjectBuilders.*, VRage.Game",
            "Sandbox.Game.*, Sandbox.Game",
            "Sandbox.Game.Components.*, Sandbox.Game",
            "Sandbox.Game.WorldEnvironment.*, Sandbox.Game",
            "VRage.*, VRage",
            "Sandbox.Definitions.*, Sandbox.Game",
            "VRage.*, VRage.Library",
            "VRage.Collections.*, VRage.Library",
            "VRage.Voxels.*, VRage",
            "VRage.Utils.*, VRage",
            "VRage.Utils.*, VRage.Library",
            "VRage.Library.Utils.*, VRage.Library",
            "Sandbox.Game.Lights.*, Sandbox.Game",
            "Sandbox.ModAPI.Weapons.*, Sandbox.Game",
            "Sandbox.ModAPI.Contracts.*, Sandbox.Game",
            "Sandbox.Engine.Utils.MySpectatorCameraController, Sandbox.Game",
            "Sandbox.Engine.Utils.MySpectatorCameraController.IsLightOn, Sandbox.Game",
            "Sandbox.Game.Gui.TerminalActionExtensions+*, Sandbox.Game",
            "Sandbox.ModAPI.Interfaces.ITerminalAction+*, Sandbox.Common",
            "Sandbox.ModAPI.Interfaces.ITerminalProperty+*, Sandbox.Common",
            "Sandbox.ModAPI.Interfaces.ITerminalProperty<TValue>+*, Sandbox.Common",
            "Sandbox.ModAPI.Interfaces.TerminalPropertyExtensions+*, Sandbox.Common",
            "Sandbox.Game.Localization.MySpaceTexts+*, Sandbox.Game",
            "System.Text.StringBuilderExtensions_Format+*, VRage.Library",
            "VRage.MyFixedPoint+*, VRage.Library",
            "VRage.MyTuple+*, VRage.Library",
            "VRage.MyTuple<T1>+*, VRage.Library",
            "VRage.MyTuple<T1, T2>+*, VRage.Library",
            "VRage.MyTuple<T1, T2, T3>+*, VRage.Library",
            "VRage.MyTuple<T1, T2, T3, T4>+*, VRage.Library",
            "VRage.MyTuple<T1, T2, T3, T4, T5>+*, VRage.Library",
            "VRage.MyTuple<T1, T2, T3, T4, T5, T6>+*, VRage.Library",
            "VRage.MyTupleComparer<T1, T2>+*, VRage.Library",
            "VRage.MyTupleComparer<T1, T2, T3>+*, VRage.Library",
            "VRage.MyTexts.MyLanguageDescription+*, VRage",
            "VRage.MyLanguagesEnum+*, VRage",
            "VRage.ModAPI.*, VRage.Input",
            "VRage.Input.MyInputExtensions+*, Sandbox.Game",
            "VRage.Input.MyKeys+*, VRage.Input",
            "VRage.Input.MyJoystickAxesEnum+*, VRage",
            "VRage.Input.MyJoystickButtonsEnum+*, VRage.Input",
            "VRage.Input.MyMouseButtonsEnum+*, VRage.Input",
            "VRage.Input.MySharedButtonsEnum+*, VRage.Input",
            "VRage.Input.MyGuiControlTypeEnum+*, VRage.Input",
            "VRage.Input.MyGuiInputDeviceEnum+*, VRage.Input",
            "VRage.Input.MyControlStateType+*, VRage.Input",
            "VRage.Input.MyControlType+*, VRage.Input",
            "VRage.Input.IMyControllerControl+*, VRage.Input",
            "VRage.Game.Components.MyComponentContainer, VRage.Game",
            "VRage.Game.Components.MyComponentContainer.TryGet<T>(out T), VRage.Game",
            "VRage.Game.Components.MyComponentContainer.Has<T>(), VRage.Game",
            "VRage.Game.Components.MyComponentContainer.Get<T>(), VRage.Game",
            "VRage.Game.Components.MyComponentContainer.TryGet(System.Type, out VRage.Game.Components.MyComponentBase), VRage.Game",
            "Sandbox.Engine.Physics.MyPhysicsHelper+*, Sandbox.Game",
            "Sandbox.Engine.Physics.MyPhysics.CollisionLayers+*, Sandbox.Game",
            "VRageRender.MyLodTypeEnum+*, VRage.Render",
            "VRageRender.MyShadowsSettings+*, VRage.Render",
            "VRageRender.MyPostprocessSettings+*, VRage.Render",
            "VRageRender.Messages.MyHBAOData+*, VRage.Render",
            "VRageRender.MySSAOSettings+*, VRage.Render",
            "VRageRender.MyEnvironmentLightData+*, VRage.Render",
            "VRageRender.MyEnvironmentData+*, VRage.Render",
            "VRageRender.MyPostprocessSettings.Layout+*, VRage.Render",
            "VRageRender.MySSAOSettings.Layout+*, VRage.Render",
            "VRageRender.MyShadowsSettings.Struct+*, VRage.Render",
            "VRageRender.MyShadowsSettings.Cascade+*, VRage.Render",
            "VRageRender.Messages.MyTextureChange+*, VRage.Render",
            "VRageRender.Import.MyMeshDrawTechnique+*, VRage.Render",
            "VRage.Game.Models.MyIntersectionResultLineTriangleEx+*, VRage.Game",
            "VRage.Game.Models.MyIntersectionResultLineTriangle+*, VRage.Game",
            "VRageRender.Lights.MyGlareTypeEnum+*, VRage.Render",
            "VRage.Serialization.SerializableDictionary<T, U>+*, VRage.Library",
            "Sandbox.Game.Weapons.MyToolBase+*, Sandbox.Game",
            "Sandbox.Game.Weapons.MyGunBase+*, Sandbox.Game",
            "Sandbox.Game.Weapons.MyAmmoBase+*, Sandbox.Game",
            "System.Diagnostics.Stopwatch+*, System",
            "System.Diagnostics.ConditionalAttribute+*, mscorlib",
            "System.Version+*, mscorlib",
            "System.ObsoleteAttribute+*, mscorlib",
            "ParallelTasks.IWork+*, VRage.Library",
            "ParallelTasks.Task+*, VRage.Library",
            "ParallelTasks.WorkOptions+*, VRage.Library",
            "VRage.Library.Threading.SpinLock+*, VRage.Library",
            "VRage.Library.Threading.SpinLockRef+*, VRage.Library",
            "System.Threading.Monitor+*, mscorlib",
            "System.Threading.AutoResetEvent+*, mscorlib",
            "System.Threading.ManualResetEvent+*, mscorlib",
            "System.Threading.Interlocked+*, mscorlib",
            "ProtoBuf.ProtoMemberAttribute+*, ProtoBuf.Net.Core",
            "ProtoBuf.ProtoContractAttribute+*, ProtoBuf.Net.Core",
            "ProtoBuf.ProtoIncludeAttribute+*, ProtoBuf.Net.Core",
            "ProtoBuf.ProtoIgnoreAttribute+*, ProtoBuf.Net.Core",
            "ProtoBuf.ProtoEnumAttribute+*, ProtoBuf.Net.Core",
            "ProtoBuf.MemberSerializationOptions+*, ProtoBuf.Net.Core",
            "ProtoBuf.DataFormat+*, ProtoBuf.Net.Core",
            "ParallelTasks.WorkData, VRage.Library",
            "ParallelTasks.WorkData.FlagAsFailed(), VRage.Library",
            "System.ArrayExtensions, VRage.Library",
            "System.ArrayExtensions.Contains<T>(T[], T), VRage.Library",
            "VRage.Game.ModAPI.Ingame.MyPhysicalInventoryItemExtensions_ModAPI+*, Sandbox.Game",
            "System.Collections.Immutable.*, System.Collections.Immutable",
            "VRage.Game.ModAPI.Network.*, VRage.Game",
            "VRage.Sync.SyncDirection.BothWays+*, VRage",
            "VRage.Sync.SyncDirection.FromServer+*, VRage",
            "VRage.Sync.SyncExtensions+*, VRage",
            "VRage.Network.IMyEventProxy+*, VRage",

        },
    };
    public static Dictionary<string, HashSet<string>> VersionBlackData = new Dictionary<string, HashSet<string>>
    {
        ["Current"] = new HashSet<string>
        {
        },
    };
}
