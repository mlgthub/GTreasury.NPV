<template>
    <h1>NPV Calculator Dashboard</h1>
    <NPVForm @npv-result="receiveNPVResultFromForm"/>
    <button @click="handleClick">Click Me</button>
</template>

<script>
import NPVForm from '../components/NPVForm.vue'

export default{
    name: 'NPVCalculatorDashboard',
    components: { NPVForm },
    setup(){
        const receiveNPVResultFromForm = (data) => {
            console.log('emit reached here')
            console.log(data); //Data from the child
        }
    }
}
</script>

<style>

</style>