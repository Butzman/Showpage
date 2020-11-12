docker build . -t docker-repo.binaryevents.de/showpage-identity-server --no-cache -f IdentityServer\Dockerfile
if($?){
	docker push docker-repo.binaryevents.de/showpage-identity-server
}