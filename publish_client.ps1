docker build . -t docker-repo.binaryevents.de/showpage-client-blazor --no-cache -f Client\Dockerfile
if($?){
	docker push docker-repo.binaryevents.de/showpage-client-blazor
}