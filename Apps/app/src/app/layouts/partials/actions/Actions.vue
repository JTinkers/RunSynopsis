<template>
    <div id='actions'>
        <Component v-for='action in visibleActions'
            :is='action.component ?? Action'
            :key='action.label'
            :action='action'
        />
    </div>
</template>

<script lang='ts' setup>
    import { computed, shallowRef } from 'vue'
    import { useRouter } from 'vue-router'
    import { IAction } from './IAction'
    import Action from './Action.vue'
    import ActionServices from './services/ActionServices.vue'
    import ActionContact from './contact/ActionContact.vue'

    const router = useRouter()

    const actions = shallowRef<Array<IAction>>(
    [
        {
            label: 'Posts',
            icon: 'feed',
            iconClass: 'material-symbols-outlined',
            isActive: () => router.currentRoute.value.name == 'posts-index',
            onClick: () => router.push({ name: 'posts-index' }),
            isVisible: () => true
        },
        {
            label: 'Articles',
            icon: 'auto_stories',
            iconClass: 'material-symbols-outlined',
            isActive: () => router.currentRoute.value.name == 'articles-index',
            onClick: () => router.push({ name: 'articles-index' }),
            isVisible: () => true
        },
        {
            label: 'Status',
            icon: 'monitor_heart',
            iconClass: 'material-symbols-outlined',
            component: ActionServices,
            isVisible: () => true
        },
        {
            label: 'Contact',
            icon: 'mail',
            iconClass: 'material-symbols-outlined',
            component: ActionContact,
            isVisible: () => true
        }
    ])

    const visibleActions = computed(() =>
    {
        return actions.value.filter(x => x.isVisible())
    })
</script>

<style lang='scss' scoped>
    #actions
    {
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        border-top: 1px solid scale-color($background, $lightness: -5%);
    }
</style>