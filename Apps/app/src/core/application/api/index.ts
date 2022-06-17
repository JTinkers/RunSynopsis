import { App } from 'vue';
import { Context, ServiceProvider } from '@/core'
import { ApiService } from './services/ApiService'
import { createClient } from '@urql/vue'
import urql from '@urql/vue'

export class ApiContext extends Context
{
    public load(app: App<Element>, serviceProvider: ServiceProvider): App<Element> 
    {
        const client = createClient(
        {
            url: 'https://192.168.31.57:7000/graphql/',
            fetchOptions:
            {
                keepalive: true,
                credentials: 'include'
            }
        })

        serviceProvider.register('IApiService', new ApiService(client))

        return app.use(urql, client)
    }
}