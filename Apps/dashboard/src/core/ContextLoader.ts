import { App } from 'vue'
import { Context, ServiceProvider } from '.'

export class ContextLoader
{
    private _app: App<Element>;
    private _serviceProvider: ServiceProvider;

    public get app(): App<Element>
    {
        return this._app
    }

    public get serviceProvider(): ServiceProvider
    {
        return this._serviceProvider
    }

    constructor(app: App<Element>)
    {
        this._app = app
        this._serviceProvider = new ServiceProvider()
    }

    public load(context: Context): this
    {
        this._app = context.load(this._app, this._serviceProvider)

        return this
    }
}