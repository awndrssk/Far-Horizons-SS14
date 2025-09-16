
using Content.Shared.CartridgeLoader;
using Content.Shared.CartridgeLoader.Cartridges;
using Robust.Shared.Log;

namespace Content.Server.CartridgeLoader.Cartridges;

public sealed class Polls1984CartridgeSystem : EntitySystem
{
    [Dependency] private readonly CartridgeLoaderSystem _cartridge = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<Polls1984CartridgeComponent, CartridgeAddedEvent>(OnAdded);
        SubscribeLocalEvent<Polls1984CartridgeComponent, CartridgeRemovedEvent>(OnRemoved);
    }

    private void OnAdded(Entity<Polls1984CartridgeComponent> ent, ref CartridgeAddedEvent args)
    {

        Log.Info($"[Polls1984] Program inserted into loader={ToPrettyString(args.Loader)}");

    }

    private void OnRemoved(Entity<Polls1984CartridgeComponent> ent, ref CartridgeRemovedEvent args)
    {

        if (!_cartridge.HasProgram<Polls1984CartridgeComponent>(args.Loader))
        {
            Log.Info($"[Polls1984] Program fully removed from loader={ToPrettyString(args.Loader)}");

        }
    }
}
