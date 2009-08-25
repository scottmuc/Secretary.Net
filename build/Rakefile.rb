# Rakefile.rb
require 'rubygems'      
require 'ftools'
require 'fileutils'

COMPILE_TARGET = "debug"
CLR_VERSION = "v3.5"

props = { :archive => "buildartifacts" }

task :default=>[:compile]

desc "Creates the artifacts workspace"
task :init do
  Dir.mkdir props[:archive] unless File.directory? props[:archive]
end

desc "Cleans up all artifacts"
task :clean do
  FileUtils.remove_dir props[:archive] if File.directory? props[:archive]
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => '../Secretary.sln', :clrversion => CLR_VERSION, :target => 'Clean'
end

desc "Compiles the app"
task :compile => [:clean] do
  MSBuildRunner.compile :compilemode => COMPILE_TARGET, :solutionfile => '../Secretary.sln', :clrversion => CLR_VERSION  
end

class MSBuildRunner
  def self.compile(attributes)
    version = attributes.fetch(:clrversion, 'v3.5')
    compileTarget = attributes.fetch(:compilemode, 'debug')
    solutionFile = attributes[:solutionfile]
    buildTarget = attributes.fetch(:target, 'Rebuild')
		
    frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', version)
    msbuildFile = File.join(frameworkDir, 'msbuild.exe')
		
    sh "#{msbuildFile} #{solutionFile} /nologo /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{compileTarget} /t:#{buildTarget}"
  end
end
