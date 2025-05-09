// Copyright © Spatial. All rights reserved.

using Spatial.Networking;

namespace Ignite.Contracts.Actions;

/// <summary>
/// A <see cref="ProtocolBuffer"/> for <see cref="NETCOMMAND.NC_ACT_NPCMENUOPEN_REQ"/>.
/// </summary>
public class PROTO_NC_ACT_NPCMENUOPEN_REQ : ProtocolBuffer
{
    /// <summary>
    /// The NPC's mob identification number.
    /// </summary>
    public ushort mobid;

    /// <summary>
    /// Deserialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Deserialize()
    {
        mobid = ReadUInt16();
    }

    /// <summary>
    /// Serialize the <see cref="ProtocolBuffer"/>.
    /// </summary>
    public override void Serialize()
    {
        Write(mobid);
    }
}
