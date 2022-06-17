import { ServiceProvider } from './ServiceProvider'
import { Context } from './Context'
import { ContextLoader } from './ContextLoader'
import { App } from 'vue'

export { ServiceProvider, Context, ContextLoader }

let contextLoader: ContextLoader

export function useService<T>(service: string): T
{
    return contextLoader.serviceProvider.resolve<T>(service)
}

export function createContextLoader(app: App<Element>): ContextLoader
{
    if (contextLoader != null)
        throw new Error('ContextLoader was already created. There can be only one instance of it')

    contextLoader = new ContextLoader(app)

    return contextLoader
}