docker build . -t docker-repo.binaryevents.de/showpage-api-server --no-cache -f Api\Dockerfile
if($?){
	docker push docker-repo.binaryevents.de/showpage-api-server
}