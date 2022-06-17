<template>
    <Transition v-show='show'
        name='fade'
        mode='out-in' 
        appear
    >
        <div id='cookies'>
            <img id='icon' src='/images/cookie.svg'>
            <div id='description'>
                <span v-text='message'/>
                <div>
                    <span v-text='"See our "'/>
                    <router-link to='/cookie-policy' v-text='"cookie policy"'/>
                    <span v-text='" for more information"'/>
                </div>
            </div>
            <Button text='Close' @click='close'/>
        </div>
    </Transition>
</template>

<script lang='ts' setup>
    import { computed } from 'vue'
    import { ICookiePolicyService, CookiePolicyState } from '@/core/domain/cookies'
    import { useService } from '@/core'

    const service = useService<ICookiePolicyService>('ICookiePolicyService')
    const message = 'We use cookies to provide essential functionality'

    const show = computed(() => service.state == CookiePolicyState.Pending)

    function close()
    {
        service.state = CookiePolicyState.Accepted
    }
</script>

<style lang='scss' scoped>
    #cookies
    {
        display: grid;
        grid-column-gap: 16px;
        grid-template-columns: min-content 1fr min-content;
        grid-template-areas: 'icon description close';
        padding: 16px;
        border-radius: 5px;
        background: scale-color($background, $lightness: -5%);
        border-bottom: 2px solid scale-color($background, $lightness: -15%);
    }

    #icon
    {
        height: 32px;
        width: 32px;
    }

    #description
    {
        display: flex;
        white-space: nowrap;
        flex-direction: column;
        justify-content: space-between;
        grid-area: description;
        font-size: 13px;
        font-family: $font-family-primary;
        font-weight: 600;
        color: $foreground;

        a
        {
            font-weight: 800;
            color: scale-color($purple, $lightness: -20%);
            
            &:hover
            {
                color: $purple;
            }
        }
    }
</style>