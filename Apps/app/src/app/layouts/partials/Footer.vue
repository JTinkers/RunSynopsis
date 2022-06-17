<template>
    <footer id='footer'>
        <div id='note'>
            <span v-text='"gezorb"'/>
            <span class='icon material-symbols-outlined' v-text='"terminal"'/>
            <span v-text='"2022"'/>
        </div>
    </footer>
</template>

<style lang='scss' scoped>
    #footer
    {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    #note
    {
        display: flex;
        grid-column-gap: 4px;
        align-items: center;
        font-size: 9px;
        font-family: $font-family-secondary;
        letter-spacing: 1px;
        text-transform: uppercase;
        transition: all 0.2s ease-in-out;
    }

    .icon
    {
        font-size: 20px;
        font-variation-settings:
            'FILL' 0,
            'wght' 200,
            'GRAD' 0,
            'opsz' 20;
    }
</style>