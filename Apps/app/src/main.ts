import '@/app/assets/scss/main.scss'
import App from '@/app/App.vue'
import { createApp } from 'vue'
import { createContextLoader } from '@/core'
import { RouterContext, RouteRecordRaw } from '@/core/domain/router'
import { ApiContext } from '@/core/application/api'
import { PluginContext } from '@/core/domain/plugins'
import { CookieContext } from '@/core/application/cookies'

const routes: Array<RouteRecordRaw> = 
[
    {
        path: '/',
        name: 'home',
        redirect: { name: 'posts-index' }
    },
    {
        path: '/posts',
        name: 'posts-index',
        component: () => import('@/app/views/posts/index/Index.vue')
    },
    {
        path: '/articles',
        name: 'articles-index',
        component: () => import('@/app/views/articles/index/Index.vue')
    },   
    {
        path: '/posts/view/:id/:slug',
        name: 'posts-view',
        component: () => import('@/app/views/posts/view/Index.vue'),
    },
    {
        path: '/articles/view/:id/:slug',
        name: 'articles-view',
        component: () => import('@/app/views/articles/view/Index.vue'),
    },
    {
        path: '/cookie-policy',
        name: 'cookie-policy',
        component: () => import('@/app/views/cookies/Index.vue')
    },
    {
        path: '/privacy-policy',
        name: 'privacy-policy',
        redirect: { name: 'home' }
    },
    {
        path: '/our-cause',
        name: 'our-cause',
        component: () => import('@/app/views/our-cause/Index.vue')
    },
]

routes.push(    
    {
        path: '/playground/controls',
        name: 'playground-controls',
        component: () => import('@/app/_playground/Controls.vue')
    },    
    {
        path: '/playground/form',
        name: 'playground-form',
        component: () => import('@/app/_playground/Form.vue')
    }
)

const app = createContextLoader(createApp(App))
    .load(new RouterContext(routes))
    .load(new ApiContext())
    .load(new PluginContext())
    .load(new CookieContext())
    .app

const componentsContext = require.context('@/app/components', true, /\w+\.vue(?<!_.*)/)
componentsContext.keys().forEach((path: any) => 
{    
    const component = componentsContext(path)
    const name = path.match(/(\w+)\.vue/)[1]

    app.component(name, component.default)
})

app.mount('#app')