export class ServiceProvider 
{
    private _services = new Map<string, unknown>();

    public resolve<T>(service: string): T 
    {
        if (!this._services.has(service))
            throw new Error(`Service ${service} doesn't exist in the registry and couldn't be resolved`)

        return this._services.get(service) as T
    }

    public register(service: string, implementation: unknown): void 
    {
        this._services.set(service, implementation)
    }
}