import { App } from 'vue'
import 
{ 
    useRoute,
    useRouter,
    createRouter,
    RouteRecordRaw,
    RouterView,
    createWebHistory
} from 'vue-router'
import { Context, ServiceProvider } from '@/core'

export class RouterContext extends Context
{
    private _routes: Array<RouteRecordRaw> = []

    constructor(routes: Array<RouteRecordRaw>)
    {
        super()
        
        this._routes = routes
    }

    public load(app: App<Element>, serviceProvider: ServiceProvider): App<Element> 
    {
        const router = createRouter(
        {
            history: createWebHistory(),
            routes: this._routes
        })

        return app.use(router)
    }
}

export { useRoute, useRouter, RouterView }
export type { RouteRecordRaw }