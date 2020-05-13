import './Map.css'
import React, { Component } from 'react';
import ReactMapboxGl, { GeoJSONLayer, Layer, Feature } from 'react-mapbox-gl'


const TruckMap = ReactMapboxGl({
  accessToken:
    process.env.REACT_APP_mapboxAPIKey
})

export default class Map extends Component {


  constructor(props) {
    super(props)
    this.state = {
      lng: -80.843,
      lat: 35.2271,
      zoom: 13,
      markers: this.props.markers
    }
  }
  async componentDidUpdate() {
    if (this.props.markers !== this.state.markers) {
      await this.setState({
        markers: this.props.markers,
        lng: this.props.markers[0].coordinates.lng,
        lat: this.props.markers[0].coordinates.lat
      })
      console.log(this.state.markers)
    }
  }

  render() {

    return (
      this.state.markers ?
        <TruckMap
          style="mapbox://styles/mapbox/light-v9"
          containerStyle={{
            height: '100%',
            width: '100%'
          }}
          center={[this.state.lng, this.state.lat]}
          zoom={[this.state.zoom]}>

          {this.state.markers.map(marker => {
            return (
              <Layer
                type="symbol"
                key={marker.properties.truckId}
                id={`marker_${marker.properties.truckId}`}
                layout={{
                  "icon-image": "marker-15",
                  "icon-allow-overlap": true,
                  "text-field": marker.properties.name,
                  "text-font": ["Open Sans Bold", "Arial Unicode MS Bold"],
                  "text-size": 11,
                  "text-transform": "uppercase",
                  "text-letter-spacing": 0.05,
                  "text-offset": [0, 1.5]
                }}>
                <Feature
                  
                  coordinates={[marker.coordinates.lng, marker.coordinates.lat]}
                  properties={marker.properties}
                  onClick={() => {
                    alert("this truck is " + marker.properties.name)
                  }}
                />
              </Layer>
            )
          })}


        </TruckMap>

        : <h1>Map Loading</h1>);
  }
}

