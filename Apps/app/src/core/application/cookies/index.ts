import { App } from 'vue';
import { Context, ServiceProvider } from '@/core'
import { CookiePolicyService } from './services/CookiePolicyService'

export class CookieContext extends Context
{
    public load(app: App<Element>, serviceProvider: ServiceProvider): App<Element> 
    {
        serviceProvider.register('ICookiePolicyService', new CookiePolicyService())

        return app
    }
}