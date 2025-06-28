export default {
  chart: {
      height: 350,
      type: 'line',
      stacked: false
  },
  dataLabels: {
      enabled: false
  },
  stroke: {
      width: [1, 1, 4]
  },
  title: {
      text: 'NPV: $',
      align: 'left',
      offsetX: 110
  },
  xaxis: {
      categories: [],
  },
  yaxis: [
  {
    seriesName: 'Discount Rate',
    axisTicks: {
      show: true,
    },
    axisBorder: {
      show: true,
      color: '#008FFB'
    },
    labels: {
      style: {
        colors: '#008FFB',
      }
    },
    title: {
      text: "Discount Rate",
      style: {
        color: '#008FFB',
      }
    },
    tooltip: {
      enabled: true
    }
  },
  {
    seriesName: 'Present Values',
    opposite: true,
    axisTicks: {
      show: true,
    },
    axisBorder: {
      show: true,
      color: '#FEB019'
    },
    labels: {
      style: {
        colors: '#FEB019',
      },
    },
    title: {
      text: "Present Value",
      style: {
        color: '#FEB019',
      }
    }
  }],
  tooltip: {
    fixed: {
      enabled: true,
      position: 'topLeft', // topRight, topLeft, bottomRight, bottomLeft
      offsetY: 30,
      offsetX: 60
    },
  },
  legend: {
    horizontalAlign: 'left',
    offsetX: 40
  }
}
