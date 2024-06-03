
First

```
dotnet tool restore
```

Run this in `PackSubgraph
```
dotnet fusion subgraph config set http --url http://localhost:7001 -c PackSubgraph.fsp
```

and this in `ProductSubgraph
```
dotnet fusion subgraph config set http --url http://localhost:7002 -c ProductSubgraph.fsp
```

Then run this in terminal for `PackSubgraph` and `ProductSubgraph`

```
dotnet run -- schema export --output schema.graphql
```

Run this in the solution root

```
dotnet fusion subgraph pack -w ./PackSubgraph 
dotnet fusion subgraph pack -w ./ProductSubgraph 
dotnet fusion compose -p ./FusionGateway/gateway  -s ./PackSubgraph 
dotnet fusion compose -p ./FusionGateway/gateway  -s ./ProductSubgraph 
```