<template>
    <section id='cookie-policy-index'>
        <div id='header'>
            <h4 v-text='"Cookie Policy"'/>
            <p id='message' v-text='message'/>
        </div>
        <Panel id='cookies'>
            <div class='header' v-text='"Name"'/>
            <div class='header' v-text='"Type"'/>
            <div class='header' v-text='"Purpose"'/>
            <template v-for='{ name, type, purpose } in cookies' :key='name'>
                <span class='name' v-text='name'/>
                <span class='type' v-text='type'/>
                <p class='purpose' v-text='purpose'/>
            </template>
        </Panel>
        <span id='revised-at' v-text='revisedAt'/>
    </section>
</template>

<script lang='ts' setup>
    import { ref, computed } from 'vue'
    import { ICookieInfo } from './ICookieInfo'
    import { CookieType } from './CookieType'
    import { format, formatDistance } from 'date-fns'

    const message = `To ensure the website works as intended, Gezorb has to store a few cookies on your device.
    A list of the aforementioned cookies and their purpose can be found below.`

    const cookies = ref<Array<ICookieInfo>>(
    [
        {
            name: 'AUTH_TOKEN',
            type: CookieType.FirstParty,
            purpose: 'Used to identify a signed-in user',
        },
        {
            name: 'DEVICE_IDENTIFIER',
            type: CookieType.FirstParty,
            purpose: 'Used to distinguish between users that aren\'t signed-in'
        }
    ])

    const revisedAt = computed(() =>
    {
        const date = new Date('2022-05-29T19:48')

        const formattedDate = format(date, 'MMMM do, yyyy - h:ma')

        const phrase = formatDistance(date, new Date(), 
        { 
            addSuffix: true
        })

        return `Last revised at ${formattedDate} (${phrase})`
    })
</script>

<style lang='scss' scoped>
    #cookie-policy-index
    {
        display: flex;
        flex-grow: 1;
        flex-direction: column;
        grid-row-gap: 32px;
        padding: 32px;
    }

    #header
    {
        display: flex;
        flex-direction: column;
        grid-row-gap: 16px;
    }

    #message
    {
        white-space: pre-line;
    }

    #cookies
    {
        display: grid;
        align-items: center;
        padding: 16px;
        grid-template-columns: repeat(3, 1fr);
        grid-auto-rows: 1fr;
    }

    #revised-at
    {
        display: flex;
        color: scale-color($background, $lightness: -40%);
        font-size: 14px;
        font-family: $font-family-primary;
        margin-left: auto;
    }

    .header
    {
        font-size: 13px;
        font-weight: 800;
        font-family: $font-family-primary;
        padding: 4px;
    }

    .name, .type, .purpose
    {
        font-size: 13px;
        font-family: $font-family-primary;
        padding: 4px;
    }
</style>