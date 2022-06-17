import { App } from 'vue'
import { Context, ServiceProvider } from '@/core'
import { useMarkdown } from './markdown'
import { useDebounce } from './debounce'

export class PluginContext extends Context
{
    constructor()
    {
        super()
    }

    public load(app: App<Element>, serviceProvider: ServiceProvider): App<Element> 
    {
        app = useMarkdown(app)
        app = useDebounce(app)

        return app
    }
}