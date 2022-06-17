<template>
    <div id='container' v-if='show'>
        <Panel id='services'>
            <span id='title'>Status</span>
            <p id='description' v-text='description'/>
            <AsyncLoader>
                <Transition name='fade'
                    mode='out-in' 
                    appear
                >
                    <ServicesAsync/>
                </Transition>
            </AsyncLoader>
        </Panel>
    </div>
</template>

<script lang='ts' setup>
    import ServicesAsync from './ServicesAsync.vue'

    const description = 'Health status of the services'

    defineProps(
    {
        show: 
        {
            type: Boolean,
            default: false
        }
    })
</script>

<style lang='scss' scoped>
    #container
    {
        position: relative;
        display: flex;
        margin-left: auto;
    }

    #services
    {
        display: flex;
        min-width: 260px;
        flex-direction: column;
        position: absolute;
        background: $background;
        padding: 16px;
        z-index: 1000;
        font-family: $font-family-secondary;
        box-shadow: rgba(0, 0, 0, 0.1) 0px 8px 32px 0px;
        clip-path: inset(-100px -100px -100px 0px);
        border-top-left-radius: 0;
        border-bottom-left-radius: 0;
    }

    #title
    {
        font-size: 14px;
        font-weight: 500;
        margin-bottom: 4px;
    }

    #description
    {
        font-size: 12px;
        margin-bottom: 4px;
    }

    :deep(.indicator)
    {
        margin-top: 16px;
    }
</style>