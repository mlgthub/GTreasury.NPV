<template>
    <Chart
        v-if="netPresentValueResults.arrangedChartData"
        :size="{ width: 500, height: 400 }"
        :data="chartData"
        :margin="margin"
        :direction="direction">

        <template #layers>
            <Grid strokeDasharray="2,2" />
            <Line :dataKeys="['year', 'presentValue']" />
        </template>

    </Chart>
    <div>
        <label>Total Cash Inflow:</label>
        <p> {{ netPresentValueResults.totalCashInflow }} </p>
    </div>
    <div>
        <label>Net Present Value:</label>
        <p> {{ netPresentValueResults.netPresentValue }} </p>
    </div>
    <svg-icon is="search"></svg-icon>
<svg-icon is="hamburger" color="green"></svg-icon>
<svg-icon is="notification" color="blue"></svg-icon>
</template>

<script setup>
import { ref, defineProps, computed } from 'vue'
import { Chart, Grid, Line } from 'vue3-charts'

const props = defineProps({
    netPresentValueResults: {
        type: Object
    }
})
console.log(props.netPresentValueResults.arrangedChartData)
const direction = ref('horizontal')
const margin = ref({
    left: 0,
    top: 20,
    right: 20,
    bottom: 0
})

</script>

<style>
  svg-icon svg { width: 90px;background: khaki;cursor: pointer }
  svg-icon:hover path { stroke: black }
</style>
