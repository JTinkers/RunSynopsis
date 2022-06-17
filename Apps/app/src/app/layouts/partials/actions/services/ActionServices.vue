<template>
    <ServicesPanel :show='showPanel'/>
    <Action :action='action'/>
</template>

<script lang='ts'>
    export default
    {
        inheritAttrs: false
    }
</script>

<script lang='ts' setup>
    import { ref, useAttrs } from 'vue'
    import { IAction } from '../IAction'
    import Action from '../Action.vue'
    import ServicesPanel from './ServicesPanel.vue'

    const showPanel = ref(false)

    const action: IAction = useAttrs().action as IAction
    action.onClick = (() => showPanel.value = !showPanel.value)
    action.isActive = (() => showPanel.value)
</script>