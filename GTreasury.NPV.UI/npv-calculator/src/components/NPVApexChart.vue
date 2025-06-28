<template>
    <div>
        <apexchart type="line" height="350" :options="chartOptions" :series="series"></apexchart>
    </div>
</template>

<script setup>
import { defineProps, toRefs } from 'vue'
import VueApexCharts from 'vue3-apexcharts'
import apexNPVChartOptions from '../schemas/apexNPVChartOptions.js'
import apexNPVChartSeries from '../schemas/apexNPVChartSeries.js'

const props = defineProps({
    netPresentValueResults: {
        type: Object
    }
})

// const internalProps = toRefs(props)

const chartOptions = apexNPVChartOptions;
// chartOptions.title += internalProps.netPresentValueResults.netPresentValue

const series = apexNPVChartSeries

</script>

<style>

</style>
