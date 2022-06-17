<template>
    <Teleport to='body'>
        <Transition name='fade' 
            mode='out-in' 
            appear
        >
            <ContactDialog v-if='showDialog' v-model:show='showDialog'/>
        </Transition>
    </Teleport>
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
    import ContactDialog from './dialog/ContactDialog.vue'

    const showDialog = ref(false)

    const action = useAttrs().action as IAction
    action.onClick = (() => showDialog.value = true)
    action.isActive = (() => showDialog.value)
</script>