<template>
    <div class='service'>
        <div class='header'>
            <span class='name' v-text='name'/>
            <span class='response-time' v-text='"rt: " + responseTime'/>
        </div>
        <span class='status' 
            :class='className' 
            v-text='label'
        />
    </div>
</template>

<script lang='ts' setup>
    import { computed, PropType, reactive } from 'vue'
    import { IServiceHealth } from '@/core/domain/api'

    const props = defineProps(
    {
        service:
        {
            type: Object as PropType<IServiceHealth>,
            required: true
        }
    })

    const { name, isAlive } = reactive(props.service)

    const className = computed(() =>
    {
        return isAlive ? 'online' : 'offline'
    })

    const label = computed(() =>
    {
        return isAlive ? 'Operational' : 'Faulted'
    })

    const responseTime = computed(() =>
    {
        return props.service.responseTime + 'ms'
    })
</script>

<style lang='scss' scoped>
    .service
    {
        display: flex;
        grid-row-gap: 8px;
        flex-direction: column;
        background: scale-color($background, $lightness: -2.5%);
        border-radius: 3px;
        padding: 8px;
        font-family: $font-family-secondary;
    }

    .header
    {
        display: flex;
        align-items: center;
    }

    .name
    {
        align-self: center;
        font-size: 12px;
        font-weight: 500;
    }

    .response-time
    {
        margin-left: auto;
        font-size: 12px;
    }

    .status
    {
        display: flex;
        justify-content: center;
        flex-grow: 1;
        padding: 4px;
        border-radius: 3px;
        font-size: 9px;
        font-weight: 600;
        text-transform: uppercase;
        letter-spacing: 3px;

        &.online
        {
            color: scale-color($green, $lightness: -60%);
            background: scale-color($green, $lightness: 25%);
        }

        &.offline
        {
            color: scale-color($red, $lightness: -60%);
            background: scale-color($red, $lightness: 25%);
        }
    }
</style>